using Xunit;

namespace FavoDeMel.Domain.Test.Entities
{
    public class GarcomTest
    {
        private HelperEntitiesTest _helperTest;

        public GarcomTest()
        {
            _helperTest = new HelperEntitiesTest();
        }

        [Fact]
        public void GarcomValido()
        {
            var garcom = _helperTest.GarcomInvalido;
            Assert.True(garcom.IsValid is not true);
        }
    }
}
