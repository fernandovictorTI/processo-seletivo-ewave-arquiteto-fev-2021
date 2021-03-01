using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Exceptions;
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
            if (idPedido == Guid.Empty)
                throw new IDValidoException(nameof(idPedido));

            if (enumSituacao == default(EnumSituacaoPedido))
                throw new SituacaoValidaException();

            IDPedido = idPedido;
            EnumSituacao = enumSituacao;
        }

        public Guid IDPedido { get; set; }
        public EnumSituacaoPedido EnumSituacao { get; set; }
    }
}
