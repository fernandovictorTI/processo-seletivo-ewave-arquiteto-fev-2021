using FavoDeMel.Domain.Core.Messaging;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class AdicionadoProdutoPedidoComSucessoEvent : IMessagin
    {
        public AdicionadoProdutoPedidoComSucessoEvent(Guid iDPedido)
        {
            IDPedido = iDPedido;
        }

        public Guid IDPedido { get; set; }

        public string Key => "queue:queue-inserido-produto-pedido";
        public DateTime DataCriacao => DateTime.Now;
    }
}
