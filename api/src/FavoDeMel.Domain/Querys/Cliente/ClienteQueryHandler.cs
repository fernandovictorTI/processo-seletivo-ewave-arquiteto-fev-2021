using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Cliente.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Querys.Cliente
{
    public class ClienteQueryHandler :
        IRequestHandler<ObterClientesQuery, IEnumerable<ClienteDto>>,
        IRequestHandler<ObterClienteQuery, ClienteDto>
    {
        private readonly IClienteDapper _clienteDapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteQueryHandler(
            IClienteDapper clienteDapper,
            IMediator mediator,
            IClienteRepository clienteRepository
            )
        {
            _clienteDapper = clienteDapper;
            _mediator = mediator;
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<ClienteDto>> Handle(ObterClientesQuery request, CancellationToken cancellationToken)
        {
            if (request.Pagina < 0)
                request.AddNotification("ObterClientesQuery.Pagina", "Pagina deve ser maior que 0.");

            if (request.Quantidade < 5)
                request.AddNotification("ObterClientesQuery.Quantidade", "Quantidade deve ser maior ou igual que 5.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(new List<ClienteDto>());
            }

            return await _clienteDapper.ObterClientes(request.Quantidade, request.Pagina);
        }

        public async Task<ClienteDto> Handle(ObterClienteQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.Id == Guid.Empty)
                request.AddNotification("ObterClienteQuery.Id", "Id é obrigatório.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                ClienteDto clienteNull = null;

                return await Task.FromResult(clienteNull);
            }

            return _clienteRepository.GetById(request.Id);
        }
    }
}
