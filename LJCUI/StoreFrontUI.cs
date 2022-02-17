using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class StoreFrontUI : IMenu
    {
        private static List<StoreFrontModel>  listOfStoreFront = new List<StoreFrontModel>();
        public static StoreFrontModel selectedStore = new StoreFrontModel();

        private ILakeJacksonBL _LakeJacksonCycleBL;
      
        public StoreFrontUI(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
            listOfStoreFront =  _LakeJacksonCycleBL.GetAllStoreFront();
        }

        
        public void Display()
        {
            Log.Information("displayed shop selection app");
            Console.WriteLine("What location would you like to shop at?");
             foreach (var storeid in listOfStoreFront)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(storeid);
            }
            Console.WriteLine("[1] - Choose Store");
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
                            Console.WriteLine("Please enter the store ID that you would like to shop at?");
                            storeID = Convert.ToInt32(Console.ReadLine());  

                        }   
                     
                     selectedStore = _LakeJacksonCycleBL.GetStoreFrontById(storeID);
                     return "StoreMenu"; 
                    }
                    else{
                        Console.WriteLine("PLease press Enter to contiune.");
                        Console.ReadLine();
                        return "StoreFrontUI";
                    }
                   
                   
                
                case "0":
                    return "MainMenu";
                default:
                    Log.Warning("User did not enter any valid options");
                    Console.WriteLine("Please select a valid option.");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "StoreFrontUI";
            }
        }
    }
}