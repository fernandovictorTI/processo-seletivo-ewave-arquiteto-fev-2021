using FavoDeMel.Domain.Entities;
using Xunit;

namespace FavoDeMel.Domain.Test.Entities
{
    public class ComandaTest
    {
        [Fact]
        public void ComandaComNumeroValido()
        {
            var comanda = new Comanda(new Domain.ValueObjects.ComandaVo(0));
            Assert.True(!comanda.IsValid);
        }
    }
}
