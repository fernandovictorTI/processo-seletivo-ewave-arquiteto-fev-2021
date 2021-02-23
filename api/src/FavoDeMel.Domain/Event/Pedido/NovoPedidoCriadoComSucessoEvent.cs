using FavoDeMel.Domain.Core.Messaging;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class NovoPedidoCriadoComSucessoEvent : IMessagin
    {
        public NovoPedidoCriadoComSucessoEvent(Guid iDPedido)
        {
            IDPedido = iDPedido;
        }

        public Guid IDPedido { get; set; }

        public string Key => "queue:queue-novo-pedido";
        public DateTime DataCriacao => DateTime.Now;
    }
}
