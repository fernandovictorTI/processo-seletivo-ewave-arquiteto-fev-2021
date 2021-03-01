using System;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.Exceptions;
using Xunit;

namespace FavoDeMel.Domain.Test.Event
{
    public class SituacaoPedidoAlteradaComSucessoEventTest
    {
        [Fact]
        public void DeveValidarIDPedidoInformadoEmpty()
        {
            Assert.Throws<IDValidoException>(() => new SituacaoPedidoAlteradaComSucessoEvent(Guid.Empty, Enums.EnumSituacaoPedido.Aberto));
        }

        [Fact]
        public void DeveValidarSituacaoNula()
        {
            Assert.Throws<SituacaoValidaException>(() => new SituacaoPedidoAlteradaComSucessoEvent(Guid.NewGuid(), default(Enums.EnumSituacaoPedido)));
        }
    }
}