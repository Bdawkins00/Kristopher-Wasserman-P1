using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class SearchCustomer : IMenu
    {
        private ILakeJacksonBL _LakeJacksonCycleBL;

        //My Customer Dependency Injection
        //=====================================
        public SearchCustomer(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
        }
        //=====================================

        
      
        public void Display()
        {
            Log.Information("System Displayed Employee Customer Uplook menu");
             Console.WriteLine("********         Employee             ******");
            Console.WriteLine("** [1] - Search By Name                    **");
            Console.WriteLine("** [0] - Go Back                           **");
            Console.WriteLine("*********************************************");
        }

        public string UserInput()
        {
            string asn = Console.ReadLine();
            switch (asn)
            {
                case "1":
                Log.Information("User used the system to look up customer information");
                    Console.WriteLine("Please enter customer's name.");
                    string  cName = Console.ReadLine();

                    List<Customers> CustomerList = _LakeJacksonCycleBL.SearchCustomer(cName);
                    Console.WriteLine("********  Customer List ********");
                    foreach (var item in CustomerList)
                    {
                        Console.WriteLine("-----------------");
                        Console.WriteLine(item);  
                    } 
          
                    Console.WriteLine("********  Customer List ********");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();

                    return "SearchCustomer";               
                case "0":
                    Log.Information("User returned to the Main Menu");
                    return "MainMenu";   
                   
                default:
                    Log.Warning("A user made an incorrect option");
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";
            }
        }
    }
}