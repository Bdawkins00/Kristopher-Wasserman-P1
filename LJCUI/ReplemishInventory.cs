using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class ReplemishInventory : IMenu
    {
        List<Inventory> listOfInventory = new List<Inventory>();
        
        private static List<StoreFrontModel>  listOfStoreFront = new List<StoreFrontModel>();
        public static StoreFrontModel selectedStore = new StoreFrontModel();

        private ILakeJacksonBL _LakeJacksonCycleBL;
        
        public ReplemishInventory(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
            listOfInventory = _LakeJacksonCycleBL.GetAllInventoryByStoreId(StoreFrontUI.selectedStore.storeId);
        }
        public void Display()
        {
            
            foreach (var _storeFront in listOfStoreFront)
            {
                Console.WriteLine(_storeFront);
            }
            Console.WriteLine("**[1] Update Store");
            Console.WriteLine("**[0] Go Back");
        }

        public string UserInput()
        {
            string ans = Console.ReadLine();

            switch (ans)
            {
                case "1":
                        Console.WriteLine("Which store would you like to update the inventory for?");
                        int storeid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please Enter a product id");
                        int productid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Please Enter a quantity for the Product");
                        int quantity = Convert.ToInt32(Console.ReadLine());
                        
                        listOfInventory = _LakeJacksonCycleBL.ReplemishInventory(storeid,productid,quantity);

                        Console.WriteLine("Replenished Successfully");
                    Console.ReadLine();
                        return "ReplemishInventory";
                case "0":
                    return "MainMenu";
                default:
                 Log.Warning("A user made an incorrect option");
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "ReplemishInventory";
            }
        }
    }
}