using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Enums;
using System;
using Xunit;

namespace FavoDeMel.Domain.Test.Entities
{
    public class HistoricoPedidoTest
    {
        [Fact]
        public void HistoricoDoPedidoDevePossuirSituacaoValida()
        {
            var enumInvalido = System.Enum.Parse<EnumSituacaoPedido>("14");

            var historicoPedido = new HistoricoPedido(enumInvalido, Guid.NewGuid());

            Assert.True(historicoPedido.IsValid is not true);
        }
    }
}
