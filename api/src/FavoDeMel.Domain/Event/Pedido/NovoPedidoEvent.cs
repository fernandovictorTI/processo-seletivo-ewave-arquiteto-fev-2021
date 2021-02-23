using MediatR;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class NovoPedidoEvent : IRequest<bool>
    {
        public NovoPedidoEvent(Guid idPedido)
        {
            IDPedido = idPedido;
        }

        public Guid IDPedido { get; set; }
    }
}
