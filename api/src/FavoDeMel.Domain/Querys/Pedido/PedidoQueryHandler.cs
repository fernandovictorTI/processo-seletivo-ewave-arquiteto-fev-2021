using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Pedido.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Querys.Pedido
{

    public class PedidoQueryHandler :
        IRequestHandler<ObterPedidosQuery, IEnumerable<PedidoDto>>,
        IRequestHandler<ObterPedidoQuery, PedidoDto>
    {
        private readonly IPedidoDapper _clienteDapper;
        private readonly IMediator _mediator;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoQueryHandler(
            IPedidoDapper clienteDapper,
            IMediator mediator,
            IPedidoRepository pedidoRepository
            )
        {
            _clienteDapper = clienteDapper;
            _mediator = mediator;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<IEnumerable<PedidoDto>> Handle(ObterPedidosQuery request, CancellationToken cancellationToken)
        {
            if (request.Pagina < 0)
                request.AddNotification("ObterPedidosQuery.Pagina", "Pagina deve ser maior que 0.");

            if (request.Quantidade < 5)
                request.AddNotification("ObterPedidosQuery.Quantidade", "Quantidade deve ser maior ou igual que 5.");

            if (request.IsValid is not true)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(new List<PedidoDto>());
            }

            return await _clienteDapper.ObterPedidos(request.Quantidade, request.Pagina);
        }

        public async Task<PedidoDto> Handle(ObterPedidoQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
                request.AddNotification("ObterPedidoQuery.Id", "Id é obrigatório.");

            if (request.IsValid is not true)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                PedidoDto clienteNull = null;

                return await Task.FromResult(clienteNull);
            }

            return _pedidoRepository.GetById(request.Id);
        }
    }
}
