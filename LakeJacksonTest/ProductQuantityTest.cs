using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{
    public class ProductQuantityTest
    {
        [Fact]
        public void ProductQuantityTestData()
        {
            // Given
                Products _pInfo = new Products();
                int _quantity = 12;
            // When
                _pInfo.Quantity = _quantity;
            // Then
            Assert.NotNull(_pInfo.Quantity);
            Assert.Equal(_quantity,_pInfo.Quantity);
        }
    }
}