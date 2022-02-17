using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class Store : IMenu
    {
         private static List<StoreFrontModel>  listOfStoreFront = new List<StoreFrontModel>();
        
        public static StoreFrontModel selectedStore = new StoreFrontModel();
        private ILakeJacksonBL _LakeJacksonCycleBL;
      
        public Store(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
            listOfStoreFront =  _LakeJacksonCycleBL.GetAllStoreFront();
        }

        public void Display()
        {
            Log.Information("Employee login in to view store inventory page");
            Console.WriteLine("Which store location do you want to manage?");
             foreach (var storeid in listOfStoreFront)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(storeid);
            }
            Console.WriteLine("[1] - Please enter a id to begin order");
            Console.WriteLine("[0] - Go Back");
        }

        public string UserInput()
        {
            string asn = Console.ReadLine();
            switch(asn)
            {
               
                case "1":
                    Console.WriteLine("Please Enter Store ID");
                    int storeID = Convert.ToInt32(Console.ReadLine());
                    if(storeID != 0){
                        while(listOfStoreFront.All(store => store.storeId != storeID))
                        {
                            Console.WriteLine("Please enter the store ID that you would like to manage?");
                            storeID = Convert.ToInt32(Console.ReadLine());  

                        }   
                     
                     Log.Information ("Employee has made an store order for inventory");
                     selectedStore = _LakeJacksonCycleBL.GetStoreFrontById(storeID);
                     return "StoreInventory"; 
                    }
                    else{
                        Log.Error("Employee made an error");
                        Console.WriteLine("PLease press Enter to contiune.");
                        Console.ReadLine();
                        return "Store";
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