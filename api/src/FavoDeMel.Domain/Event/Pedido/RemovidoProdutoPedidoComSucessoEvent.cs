using FavoDeMel.Domain.Core.Messaging;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class RemovidoProdutoPedidoComSucessoEvent : IMessagin
    {
        public RemovidoProdutoPedidoComSucessoEvent(Guid iDPedido)
        {
            IDPedido = iDPedido;
        }

        public Guid IDPedido { get; set; }

        public string Key => "queue:queue-removido-produto-pedido";
        public DateTime DataCriacao => DateTime.Now;
    }
}
