// See https://aka.ms/new-console-template for more information
global using Serilog;
using LJCUI;
using LakeJacksonCyclingBL;
using LakeJacksonCyclingDL;
using Microsoft.Extensions.Configuration;

Log.Logger = new LoggerConfiguration().WriteTo.File("./logs/user.txt").CreateLogger();
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("settings.json")
    .Build();

string _connString = configuration.GetConnectionString("Database");    
 Console.Clear();
bool repeat = true;
IMenu menu = new MainMenu();

    ///
    /// shows the user a welcome screen and asks for a name to be called by
    ///  
   
    Log.Information("System displayed main menu");
    Console.WriteLine("Welcome to Lake Jackson Cycling");
    
while(repeat)
{ 
    
    Console.Clear(); 
    /*
        The bottom four lines of code show the welcome and how may i help you responses/question when you enter the store or website
    */
  
    menu.Display();
   

   
    
    /// <summary>
    /// Asks for a answer then uses that to get the user to the correct menu to make some operation happen
    /// </summary>
    /// <returns></returns>
    string ans = menu.UserInput();
    switch (ans)
    {
        case "AddCustomer":
            Log.Information("Displaying add customer to user");
            menu = new AddCustomer(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "MainMenu":
            Log.Information("Displaying MainMenu to user");
            menu = new MainMenu();
            break;
        case "AddProduct":
            Log.Information("Displaying Add Product menu to user");
            menu = new AddProduct(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "SearchProducts" :
            Log.Information("Employee accessed inventory lookup menu");
            menu = new SearchProducts(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "SearchCustomer":
            Log.Information("Employee accessed search function");
            menu = new SearchCustomer(new LakeJacksonBL(new SQLRepository(_connString)));
            break;

        case "PlaceOrder":
            Log.Information("Place Order function has been accessed by the user");
            menu = new PlaceOrder(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "StoreFrontUI":
            menu = new StoreFrontUI(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "StoreMenu":
            menu = new StoreMenu(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "Store":
            menu = new Store(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "StoreInventory":
            menu = new StoreInventory(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "OrderHistory":
            menu = new OrderHistory(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "ReplemishInventory":
            menu = new ReplemishInventory(new LakeJacksonBL(new SQLRepository(_connString)));
            break;
        case "Exit":
            Log.Information("Exiting Application");
            Log.CloseAndFlush();
            repeat = false;
            break;
        default:
            Log.Warning("A user made an incorrect option");
            Console.WriteLine("Please enter a valid option.");
            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
            break;
    }

}


