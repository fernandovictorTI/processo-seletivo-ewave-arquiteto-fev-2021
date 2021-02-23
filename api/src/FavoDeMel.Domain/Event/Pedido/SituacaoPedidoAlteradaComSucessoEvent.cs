using FavoDeMel.Domain.Core.Messaging;
using FavoDeMel.Domain.Enums;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class SituacaoPedidoAlteradaComSucessoEvent : IMessagin
    {
        public SituacaoPedidoAlteradaComSucessoEvent(
            Guid iDPedido,
            EnumSituacaoPedido enumSituacao)
        {
            IDPedido = iDPedido;
            EnumSituacao = enumSituacao;
        }

        public Guid IDPedido { get; private set; }
        public EnumSituacaoPedido EnumSituacao { get; private set; }

        public string Key => "queue:queue-situacao-pedido-alterada";
        public DateTime DataCriacao => DateTime.Now;
    }
}
