using FavoDeMel.Domain.Core.Messaging;
using FavoDeMel.Domain.Exceptions;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class RemovidoProdutoPedidoComSucessoEvent : IMessagin
    {
        public RemovidoProdutoPedidoComSucessoEvent(Guid iDPedido)
        {
            if (iDPedido == Guid.Empty)
                throw new IDValidoException(nameof(iDPedido));

            IDPedido = iDPedido;
        }

        public Guid IDPedido { get; set; }

        public string Key => "queue:queue-removido-produto-pedido";
        public DateTime DataCriacao => DateTime.Now;
    }
}
