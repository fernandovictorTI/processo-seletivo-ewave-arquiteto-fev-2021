using FavoDeMel.Domain.Command.Cliente;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class ClienteCommandHandler : IRequestHandler<CriarClienteCommand, Guid>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteCommandHandler(
            IClienteRepository clienteRepository,
            IMediator mediator)
        {
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome);

            if (_clienteRepository.PossuiNomeCadastrado(cliente))
                cliente.AddNotification("Cliente.Nome", "O nome do cliente ja esta cadastrado no banco.");

            if (!cliente.IsValid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = cliente.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            _clienteRepository.Add(cliente);

            return await Task.FromResult(cliente.Id);
        }
    }
}
