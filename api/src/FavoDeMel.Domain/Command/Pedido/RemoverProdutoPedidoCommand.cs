using Flunt.Notifications;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Pedido
{
    public class RemoverProdutoPedidoCommand : Notifiable<Notification>, IRequest<bool>
    {
        public RemoverProdutoPedidoCommand(Guid iDProdutoPedido)
        {
            IDProdutoPedido = iDProdutoPedido;
        }

        public Guid IDProdutoPedido { get; set; }
    }
}
