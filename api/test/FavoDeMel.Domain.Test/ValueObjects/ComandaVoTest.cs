using FavoDeMel.Domain.ValueObjects;
using Xunit;

namespace FavoDeMel.Domain.Test.ValueObjects
{
    public class ComandaVoTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ComandaInvalidaComComandaComNumeroIncorreto(int numeroComanda)
        {
            var comanda = new ComandaVo(numeroComanda);

            Assert.True(comanda.IsValid is not true);
        }
    }
}
