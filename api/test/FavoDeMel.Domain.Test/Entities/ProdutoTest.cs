using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.ValueObjects;
using Xunit;

namespace FavoDeMel.Domain.Test.Entities
{
    public class ProdutoTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void ProdutoInvalidoValorIncorreto(decimal valor)
        {
            var nome = new NomeVo("Fernando Victor Pereira Santiago");
            var produto = new Produto(nome, valor);

            Assert.True(!produto.IsValid);
        }
    }
}
