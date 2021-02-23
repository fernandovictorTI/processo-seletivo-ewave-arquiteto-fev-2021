using FavoDeMel.Domain.Command.Produto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class ProdutoCommandHandler : 
        IRequestHandler<CriarProdutoCommand, Guid>
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediator _mediator;

        public ProdutoCommandHandler(
            IProdutoRepository produtoRepository,
            IMediator mediator)
        {
            _produtoRepository = produtoRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Produto(request.Nome, request.Valor);

            if (_produtoRepository.PossuiProdutoCadastrado(produto))
                produto.AddNotification("Produto.Nome", "O produto ja esta cadastrado no banco.");

            if (produto.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = produto.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            _produtoRepository.Add(produto);

            return await Task.FromResult(produto.Id);
        }
    }
}
