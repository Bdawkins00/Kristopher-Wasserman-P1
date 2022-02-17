using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{
    public class ProductPriceTest
    {
        [Fact]
        public void ProductPriceData()
        {
            // Given
            Products _pInfo = new Products();
            double _price = 12.20;
            // When
            _pInfo.Price = _price;
            // Then

            Assert.NotNull(_pInfo.Price);
            Assert.Equal(_price,_pInfo.Price);
        }
        [Fact]
        
        public void ProductNameData()
        {
            // Given
            Products _pInfo = new Products();
            string Name = "shirt";
            // When
            _pInfo.ItemName = Name;
            // Then

            Assert.NotNull(_pInfo.ItemName);
            Assert.Equal(Name, _pInfo.ItemName);
        }

        [Fact]
        public void ProductDescriptionTest()
        {
            // Given
            Products _pInfo = new Products();
            string Description = "a really nice shirt";
        
            // When
            _pInfo.Description = Description;
            // Then

            Assert.NotNull(_pInfo.Description);
            Assert.Equal(Description,_pInfo.Description);
        }
        [Fact]
        public void ProductQuantityTest()
        {
            // Given
            Products _pInfo = new Products();
            int _quantity = 10;
        
            // When
            _pInfo.Quantity = _quantity;
            // Then

            Assert.NotNull(_pInfo.Quantity);
            Assert.Equal(_quantity,_pInfo.Quantity);
        }
        
        

    }
}