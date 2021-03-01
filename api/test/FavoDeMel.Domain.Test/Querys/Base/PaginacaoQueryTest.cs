using System;
using FavoDeMel.Domain.Querys.Base;
using Xunit;

namespace FavoDeMel.Domain.Test.Querys.Base
{
    public class PaginacaoQueryTest
    {
        [Fact]
        public void DeveValidarPaginaMenorIgualQueZero()
        {
            Assert.Throws<ArgumentNullException>(() => new PaginacaoQuery<dynamic>(0, 10));
        }
    }
}