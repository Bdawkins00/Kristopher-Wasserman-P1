using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{

    public class AddCustomerZip
    {
        [Fact]
        public void AddCustomerZipData()
        {
            //Arrange
            Customers cName = new Customers(); /* thos arrange Customer name for test*/
            string validZip = "77566";
            

            //Act
            cName.Zip = validZip;
            
            //Assert
            
             
             Assert.NotNull(cName.Zip);
            Assert.Equal(validZip, cName.Zip);
        }
    }
}