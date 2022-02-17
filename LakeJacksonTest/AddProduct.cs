using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{
    public class AddProduct
    {
        [Fact]
        public void AddProductNameTest()
        {
            // Arrange

            Products pName = new Products();

            string validName = "Shirt";
        
            // When
            pName.ItemName = validName;
            // Then
            Assert.NotNull(pName.ItemName);
            Assert.Equal(validName, pName.ItemName);
        }
    }

}