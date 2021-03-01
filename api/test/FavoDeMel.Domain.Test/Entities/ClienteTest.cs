using FavoDeMel.Domain.Entities;
using Xunit;

namespace FavoDeMel.Domain.Test.Entities
{
    public class ClienteTest
    {
        [Fact]
        public void ClienteValido()
        {
            var cliente = new Cliente(new Domain.ValueObjects.NomeVo("Fe"));
            Assert.True(cliente.IsValid is not true);
        }
    }
}