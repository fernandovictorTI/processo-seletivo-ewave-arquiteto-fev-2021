using System;
using FavoDeMel.Domain.Querys.Base;
using Xunit;

namespace FavoDeMel.Domain.Test.Querys.Base
{
    public class PaginacaoQueryTest
    {
        [Fact]
        public void DeveValidarPaginaMenorQueZero()
        {
            Assert.Throws<ArgumentNullException>(() => new PaginacaoQuery<dynamic>(-1, 10));
        }
    }
}