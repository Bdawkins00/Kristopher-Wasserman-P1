namespace LJCUI
{
    public class MainMenu : IMenu
    {
        public void Display()
        {
            Log.Information("User is viewing main menu of store");
            Console.WriteLine("+++++++ Lake Jackson Cycling +++++++");
            Console.WriteLine("++ [1] - Replenish Inventory   ++");
            Console.WriteLine("++ [2] - View Products            ++");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("*******       Employee       *******");
            Console.WriteLine("** [5] - Add Customer Information **");
            Console.WriteLine("** [6] - Add Products             **");
            Console.WriteLine("** [7] - Place an Order           **");
            Console.WriteLine("** [8] - Search for a customer    **");
            Console.WriteLine("** [9] - View History              **");
            Console.WriteLine("** [10] - Replemish Inventory      **");
            Console.WriteLine("************************************");
            Console.WriteLine("[0] - Exit");
        }
        public string UserInput()
        {
            string userSelection = Console.ReadLine();

            switch (userSelection)
            {
                case "0":
                    Log.Information("User Exited the Add Customer ");
                    return "Exit";
                    
                case "1":
                    Log.Information("Customer Entered the front door");
                    return "Store";
                   
                case "2":
                    Log.Information("User is viewing products");
                    return "SearchProducts";
                   
                case "5":
                    Log.Information("Empolyee accessed AddCustomer Functions");
                    return "AddCustomer";
                    
                case "6":
                    Log.Information("Employee added products to the inventory");
                    return "AddProduct";
                    
                case "7":
                    Log.Information("Employee placed an order!MONEY");
                    return "PlaceOrder";
                    
                case "8":
                    Log.Information("Employee confirmed a Customer by searching them in the database");
                    return "SearchCustomer";
                case "9":
                    Log.Information("User accessed History Screen");
                    return "OrderHistory";
                case "10":
                    Log.Information("User replimeshed inventory");
                    return "ReplemishInventory";
                default:
                    Log.Warning("A user made an incorrect option");
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    break;
            }

            return "MainMenu";
        }
    }
}