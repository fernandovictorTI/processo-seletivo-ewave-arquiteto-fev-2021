using System;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.Exceptions;
using Xunit;

namespace FavoDeMel.Domain.Test.Event
{
    public class AdicionadoProdutoPedidoEventTest
    {
        [Fact]
        public void DeveValidarIDPedidoInformadoEmpty()
        {
            Assert.Throws<IDValidoException>(() => new AdicionadoProdutoPedidoEvent(Guid.Empty));
        }
    }
}