using LakeJacksonCyclingModel;
using LakeJacksonCyclingBL;


namespace LJCUI
{
        /// <summary>
        /// Function inside here will look at Customers Model with in th LakeJacksonCyclingModel.
        /// if you need to change or add things please remeber to add them to the model as well
        /// </summary>
    public class AddCustomer : IMenu
    {
        private static Customers _cInfo = new Customers();

        private ILakeJacksonBL _LakeJacksonCycleBL;
        public AddCustomer(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
        }

        /// <summary>
        /// Displays the Menu need to add a customer to our database
        /// </summary>
        public void Display()
        {
            Log.Information("System displayed Add Customer To user!");
            Console.WriteLine("********         Employee             *******");
            Console.WriteLine("** [1] - Name: " + _cInfo.Name + "         **");
            Console.WriteLine("** [2] - Address: "+_cInfo.Address + "     **");
            Console.WriteLine("** [3] - City: " + _cInfo.City + "         **");
            Console.WriteLine("** [4] - State: " + _cInfo.State + "       **");
            Console.WriteLine("** [5] - Zip: " + _cInfo.Zip + "           **");
            Console.WriteLine("** [6] - Phone: " + _cInfo.PhoneNumber + " **");
            Console.WriteLine("** [7] - Email: " + _cInfo.Email + "       **");
            Console.WriteLine("** [9] - Save                              **");
            Console.WriteLine("*********************************************");
            Console.WriteLine("[0] - Go Back");
        }

        public string UserInput()
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Log.Information("Employee updated customer name");
                    Console.WriteLine("Please enter customers Name. ");
                    _cInfo.Name = Console.ReadLine();
                    break;
                case "2":
                    Log.Information("Employee updated customer address");
                    Console.WriteLine("Please enter thier address.");
                    _cInfo.Address = Console.ReadLine();
                    break;
                case "3":
                    Log.Information("Employee updated customer city");
                    Console.WriteLine("Please enter the City.");
                    _cInfo.City = Console.ReadLine();
                    break;
                case "4":
                    Log.Information("Employee updated customer State");
                    Console.WriteLine("Please enter the State.");
                    _cInfo.State = Console.ReadLine();
                    break;
                case "5":
                    Log.Information("Employee updated customer's Zip code");
                    Console.WriteLine("Please enter the Zip(numbers only please)");
                    _cInfo.Zip = Console.ReadLine();
                    break;
                case "6":
                    Log.Information("Employee updated customer's phone number");
                    Console.WriteLine("Please enter a phone number!(numbers only please)");
                    _cInfo.PhoneNumber = Console.ReadLine();
                    break;
                case "7":
                    Log.Information("Employee updated customer's email");
                    Console.WriteLine("Please enter a email.");
                    _cInfo.Email = Console.ReadLine();
                    break;
                case "9":
                    try
                    {
                        Log.Information("Employee - CustomerAdded!");
                        Console.WriteLine("CustomerAdded");
                        _LakeJacksonCycleBL.AddCustomer(_cInfo);
                        Console.WriteLine("Please press Enter to contiune.");
                        Console.ReadLine();
                    }
                    catch (System.Exception exc)
                    {
                        Log.Warning("Customer already added");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue!");
                        Console.ReadLine();
                    }
                    return "AddCustomer";
                case "0":
                    Log.Information("User went back to the main menu.");
                    return "MainMenu";
                default:
                    Log.Warning("A user made an incorrect option");
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
            return "AddCustomer";
        }
        
    }
}