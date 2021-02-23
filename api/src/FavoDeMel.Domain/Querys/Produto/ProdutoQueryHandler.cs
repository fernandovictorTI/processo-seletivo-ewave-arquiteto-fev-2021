using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Produto.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Querys.Produto
{
    public class ProdutoQueryHandler :
        IRequestHandler<ObterProdutosQuery, IEnumerable<ProdutoDto>>,
        IRequestHandler<ObterProdutoQuery, ProdutoDto>
    {
        private readonly IProdutoDapper _produtoDapper;
        private readonly IMediator _mediator;
        private readonly IProdutoRepository _produtoRepository;        

        public ProdutoQueryHandler(
            IProdutoDapper produtoDapper,
            IMediator mediator,
            IProdutoRepository produtoRepository
            )
        {
            _produtoDapper = produtoDapper;
            _mediator = mediator;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<ProdutoDto>> Handle(ObterProdutosQuery request, CancellationToken cancellationToken)
        {
            if (request.Pagina < 0)
                request.AddNotification("ObterProdutosQuery.Pagina", "Pagina deve ser maior que 0.");

            if (request.Quantidade < 5)
                request.AddNotification("ObterProdutosQuery.Quantidade", "Quantidade deve ser maior ou igual que 5.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(new List<ProdutoDto>());
            }

            return await _produtoDapper.ObterProdutos(request.Quantidade, request.Pagina);
        }

        public async Task<ProdutoDto> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.Id == Guid.Empty)
                request.AddNotification("ObterCarcomQuery.Id", "Id é obrigatório.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                ProdutoDto produtoNull = null;

                return await Task.FromResult(produtoNull);
            }

            return _produtoRepository.GetById(request.Id);
        }
    }
}
