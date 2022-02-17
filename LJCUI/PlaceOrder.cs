using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;


namespace LJCUI
{
    public class PlaceOrder : IMenu
    {
        
        private static Customers _cInfo = new Customers();

        private ILakeJacksonBL _LakeJacksonCycleBL;
        private List<Customers> listOfCustomers;
        public PlaceOrder(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
            listOfCustomers =  _LakeJacksonCycleBL.GetAllCustomers();
        }
        
        

        public static Customers selectedCustomer = new Customers();
        public void Display()
        {
           
            foreach (var _customerInfo in listOfCustomers)
            {
                Console.WriteLine("-------------------");
                Console.WriteLine(_customerInfo);
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
                    Log.Information("User has accessed the place order function");
                    Console.WriteLine("Please Enter your id");
                    int customerID = Convert.ToInt32(Console.ReadLine());  
                    while(listOfCustomers.All(customer => customer.cId != customerID))
                    {
                        Console.WriteLine("Please Enter your ID");
                        customerID = Convert.ToInt32(Console.ReadLine());  

                    }    
                     selectedCustomer = _LakeJacksonCycleBL.GetCustomerById(customerID);
                     Console.WriteLine("Going to store menu");
                     Console.ReadLine();
                     return "StoreFrontUI";
                
                case "0":
                    return "MainMenu";
                default:
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "PlaceOrder";
            }
        }
    }
}