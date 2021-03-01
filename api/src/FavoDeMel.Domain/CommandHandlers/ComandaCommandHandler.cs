using FavoDeMel.Domain.Command.Comanda;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class ComandaCommandHandler : IRequestHandler<CriarComandaCommand, Guid>
    {
        private readonly IComandaRepository _comandaRepository;
        private readonly IMediator _mediator;

        public ComandaCommandHandler(
            IComandaRepository comandaRepository,
            IMediator mediator)
        {
            _comandaRepository = comandaRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarComandaCommand request, CancellationToken cancellationToken)
        {
            var comanda = new Comanda(request.NumeroComanda);

            if (_comandaRepository.PossuiNumeroComandaCadastrada(comanda))
                comanda.AddNotification("Comanda.Numero", "O numero da comanda ja esta cadastrado no banco.");

            if (comanda.IsValid is not true)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = comanda.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            _comandaRepository.Add(comanda);

            return await Task.FromResult(comanda.Id);
        }
    }
}
