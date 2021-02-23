using MediatR;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class AdicionadoProdutoPedidoEvent : IRequest<bool>
    {
        public AdicionadoProdutoPedidoEvent(Guid idPedido)
        {
            IDPedido = idPedido;
        }

        public Guid IDPedido { get; set; }
    }
}
