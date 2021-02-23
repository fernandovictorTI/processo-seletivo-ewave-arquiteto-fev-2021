using FavoDeMel.Domain.Entities;
using Xunit;

namespace FavoDeMel.Domain.Test.Entities
{
    public class PedidoTest
    {
        private readonly HelperEntitiesTest _helperTest;

        public PedidoTest()
        {
            _helperTest = new HelperEntitiesTest();
        }

        [Fact]
        public void PedidoDevePossuirGarcomValido()
        {
            var pedido = new Pedido(_helperTest.GarcomInvalido, _helperTest.Comanda, _helperTest.Cliente);
            Assert.True(!pedido.IsValid);
        }

        [Fact]
        public void DeveRetornarErroAoAdicionarProdutoRepetido()
        {
            var pedido = new Pedido(_helperTest.Garcom, _helperTest.Comanda, _helperTest.Cliente);
            var produtoPedido = new ProdutoPedido(_helperTest.Produto.Id, 2);

            pedido.AdicionarProduto(produtoPedido);
            pedido.AdicionarProduto(produtoPedido);

            Assert.True(!pedido.IsValid);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DeveRetornarErroAoAdicionarQuantidadeInvalida(int quantidade)
        {
            var pedido = new Pedido(_helperTest.Garcom, _helperTest.Comanda, _helperTest.Cliente);
            var produtoPedido = new ProdutoPedido(_helperTest.Produto.Id, 2);

            pedido.AumentarQuantidadeProduto(produtoPedido, quantidade);

            Assert.True(!pedido.IsValid);
        }
    }
}
