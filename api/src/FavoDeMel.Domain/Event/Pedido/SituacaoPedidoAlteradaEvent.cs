using FavoDeMel.Domain.Enums;
using MediatR;
using System;

namespace FavoDeMel.Domain.Event.Pedido
{
    public class SituacaoPedidoAlteradaEvent : IRequest<bool>
    {
        public SituacaoPedidoAlteradaEvent(
            Guid idPedido,
            EnumSituacaoPedido enumSituacao)
        {
            IDPedido = idPedido;
            EnumSituacao = enumSituacao;
        }

        public Guid IDPedido { get; set; }
        public EnumSituacaoPedido EnumSituacao { get; set; }
    }
}
