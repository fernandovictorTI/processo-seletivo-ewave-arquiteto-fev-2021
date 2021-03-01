using FavoDeMel.Domain.Core.Messaging;
using FavoDeMel.Domain.Exceptions;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class NovoPedidoCriadoComSucessoEvent : IMessagin
    {
        public NovoPedidoCriadoComSucessoEvent(Guid iDPedido)
        {
            if (iDPedido == Guid.Empty)
                throw new IDValidoException(nameof(iDPedido));

            IDPedido = iDPedido;
        }

        public Guid IDPedido { get; set; }

        public string Key => "queue:queue-novo-pedido";
        public DateTime DataCriacao => DateTime.Now;
    }
}
