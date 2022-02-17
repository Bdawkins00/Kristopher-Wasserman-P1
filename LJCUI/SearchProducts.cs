using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class SearchProducts : IMenu
    {
        private List<Products> _productList;
        private ILakeJacksonBL _LakeJacksonCycleBL;
        
        //My Customer Dependency Injection
        //=====================================
        // public SearchProducts(LakeJacksonBL p_name)
        // {
        //    _LakeJacksonCycleBL = p_name;
        //   2
        // }
        public SearchProducts(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
           _productList = p_name.GetAllProducts();
        }
        //=====================================

        public void Display()
        {
           Log.Information("System Displayed Employee Customer Uplook menu");
            // Console.WriteLine("********         Employee             ******");
            // Console.WriteLine("** [1] - Search Product by Name           **");
            // Console.WriteLine("** [0] - Go Back                           **");
            // Console.WriteLine("*********************************************");
            Console.WriteLine("========= Products =========");
            foreach (var item in _productList)
            {
                Console.WriteLine("==========================");
                Console.WriteLine(item);
            }
            Console.WriteLine("** [1] - Order Product by ID           **");
            Console.WriteLine("** [0] - Go Back                           **");
            Console.WriteLine("*********************************************");
        }

        public string UserInput()
        {
            string asw = Console.ReadLine();
            switch (asw)
            {
                case "1":
                    return "PlaceOrder";
                case "0":
                    return "MainMenu";
                default: 
                    Log.Warning("A user made an incorrect option");
                    Console.WriteLine("Please enter a valid option.");
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                    return "SearchProducts";
                
            }
            
        }
    }
}