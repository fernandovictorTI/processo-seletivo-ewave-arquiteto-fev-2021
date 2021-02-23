using Flunt.Notifications;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Pedido
{
    public class AdicionarProdutoPedidoCommand : Notifiable<Notification>, IRequest<Guid>
    {
        public AdicionarProdutoPedidoCommand(Guid iDPedido, Guid iDProduto, int quantidade)
        {
            IDPedido = iDPedido;
            IDProduto = iDProduto;
            Quantidade = quantidade;
        }

        public Guid IDPedido { get; set; }
        public Guid IDProduto { get; set; }
        public int Quantidade { get; set; }
    }
}
