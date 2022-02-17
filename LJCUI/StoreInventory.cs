using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class StoreInventory : IMenu
    {
         private static List<Products>  listOfProduct ;
        
        
        private ILakeJacksonBL _LakeJacksonCycleBL;
      
        public StoreInventory(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
            listOfProduct =  _LakeJacksonCycleBL.GetAllProducts();
        }

        public void Display()
        {
            Log.Information("displayed shop selection app");
            Console.WriteLine("What Product would you like to add?");
             foreach (var product in listOfProduct)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(product);
            }
            Console.WriteLine("[1] - Please enter a product id");
            Console.WriteLine("[0] - Go Back");
        }

        public string UserInput()
        {
            string asn = Console.ReadLine();
            switch(asn)
            {
               
                case "1":
                    Console.WriteLine("Please Enter a product ID");
                    int productID = Convert.ToInt32(Console.ReadLine());
                    if(productID != 0){
                        while(listOfProduct.All(pid => pid.productID != productID))
                        {
                            Console.WriteLine("Please enter the product id you wish to add?");
                            productID = Convert.ToInt32(Console.ReadLine());  

                        }   
                        Console.WriteLine("Please Enter quantity");
                        int quantity = Convert.ToInt32(Console.ReadLine());    
                      _LakeJacksonCycleBL.AddProductToStore(Store.selectedStore.storeId, productID,quantity);
                        Console.WriteLine("Add Successful");
                    Console.WriteLine("PLease press Enter to contiune.");

                        Console.ReadLine();
                        return "Store";
                     
                    }
                    else{
                        Console.WriteLine("PLease press Enter to contiune.");
                        Console.ReadLine();
                        return "StoreInventory";
                    }
                   
                   
                
                case "0":
                    return "MainMenu";
                default:
                    Log.Warning("User did not enter any valid options");
                    Console.WriteLine("Please select a valid option.");
                    Console.WriteLine("Please press Enter to continue");
                    return "Store";
            }
        }
    }
}