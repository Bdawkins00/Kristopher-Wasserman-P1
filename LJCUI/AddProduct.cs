using LakeJacksonCyclingModel;
using LakeJacksonCyclingBL;

namespace LJCUI
{
    public class AddProduct : IMenu
    {

        /// <summary>
        /// The lines of code below are depecdent injection. Please do not remove. Needed to make program run.
        /// </summary>
        /// <returns></returns>
        private static Products _pInfo = new Products();
        private ILakeJacksonBL _LakeJacksonCycleBL;
        public AddProduct(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
        }

        /// <summary>
        /// below displays the menu options to the user and logs them
        /// </summary>
        public void Display()
        {
           Log.Information("System displayed addProduct menu to user.");
           Console.WriteLine("*****    Add Inventory(Employee)    *****");
           Console.WriteLine("** [1] Product Name: "+ _pInfo.ItemName + " **");
           Console.WriteLine("** [2] Price: "+ _pInfo.Price + " **");
           Console.WriteLine("** [3] Description: "+ _pInfo.Description + " **");
           Console.WriteLine("** [4] Quantity: " + _pInfo.Quantity);
           Console.WriteLine("** [9] - Save");
           Console.WriteLine("*****   Add Inventory(Empolyee)     *****");
           Console.WriteLine("[0] Go Back");
        }

        public string UserInput()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Log.Information("User added a new name of a new product");
                    Console.WriteLine("Please enter a name for the product!");
                    _pInfo.ItemName = Console.ReadLine();
                    break;
                case "2":
                    Log.Information("User has added a price to a product");
                    Console.WriteLine("Please enter a price.");
                    _pInfo.Price = Convert.ToDouble(Console.ReadLine());
                    break;
                case "3":
                    Log.Information("User has added a description to a product");
                    Console.WriteLine("Please describ the product");
                    _pInfo.Description = Console.ReadLine();
                    break;
                case "4":
                    Log.Information("User add a quantity of a product");
                    Console.WriteLine("Please enter the quantity of product on hand");
                    _pInfo.Quantity = Convert.ToInt32(Console.ReadLine());
                    break;
                case "9":
                    try
                    {
                        Log.Information("Product has been added");
                        Console.WriteLine("Product Added!!");
                        _LakeJacksonCycleBL.AddProduct(_pInfo);
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Customer already added");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue!");
                        Console.ReadLine();
                    }
                    return "AddProduct";
                case "0":
                    return "MainMenu";
                default:
                    Log.Warning("A user made an incorrect option");
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "AddProduct";
            }
            return "AddProduct";
        }
    }
}