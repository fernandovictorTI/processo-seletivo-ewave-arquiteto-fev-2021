using FavoDeMel.Domain.ValueObjects;
using Xunit;

namespace FavoDeMel.Domain.Test.ValueObjects
{
    public class NomeVoTest
    {
        [Theory]
        [InlineData("Fe")]
        [InlineData("Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago Fernando Victor Pereira Santiago")]
        public void NomeVoInvalidoComNomeComQuantidadeCaracteresIncorreto(string strNome)
        {
            var nome = new NomeVo(strNome);

            Assert.True(nome.Invalid);
        }
    }
}