using System;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.Exceptions;
using Xunit;

namespace FavoDeMel.Domain.Test.Event
{
    public class SituacaoPedidoAlteradaEventTest
    {
        [Fact]
        public void DeveValidarIDPedidoInformadoEmpty()
        {
            Assert.Throws<IDValidoException>(() => new SituacaoPedidoAlteradaEvent(Guid.Empty, Enums.EnumSituacaoPedido.Aberto));
        }

        [Fact]
        public void DeveValidarSituacaoNula()
        {
            Assert.Throws<SituacaoValidaException>(() => new SituacaoPedidoAlteradaEvent(Guid.NewGuid(), default(Enums.EnumSituacaoPedido)));
        }
    }
}