using LakeJacksonCyclingModel;
using Xunit;

namespace LakeJacksonTest
{

    public class AddCustomerTest
    {
        [Fact]
        public void AddCustomerNameData()
        {
            //Arrange
            Customers cName = new Customers(); /* thos arrange Customer name for test*/
            string validName = "Kristopher";
            

            //Act
            cName.Name = validName;
            
            
            //Assert
            Assert.NotNull(cName.Name);
            Assert.Equal(validName, cName.Name);
             
            
        }
        
        [Fact]

        public void CustomerZipData()
        {
            Customers cName = new Customers(); 
            string validZip = "77566";

            cName.Zip = validZip;

            Assert.NotNull(cName.Zip);
            Assert.Equal(validZip, cName.Zip);
        }

        [Fact]
        public void CustomerEmailTest()
        {
            
            Customers cName = new Customers(); 
            string validEmail = "kristopherwasserman6@msn.com";

            cName.Email = validEmail;

            Assert.NotNull(cName.Email);
            Assert.Equal(validEmail,cName.Email);
        }

        
        
    }
}