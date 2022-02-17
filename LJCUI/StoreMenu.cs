using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class StoreMenu : IMenu
    {
        private static List<Products>  listOfProducts = new List<Products>();
        public static StoreFrontModel selectedStore = new StoreFrontModel();

        private static List<Inventory> listOfInventory = new List<Inventory>();
        private ILakeJacksonBL _LakeJacksonCycleBL;
        
        public StoreMenu(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
            listOfProducts =  _LakeJacksonCycleBL.GetAllProductsByStoreID(StoreFrontUI.selectedStore.storeId);
            listOfInventory = _LakeJacksonCycleBL.GetAllInventoryByStoreId(StoreFrontUI.selectedStore.storeId);
        }

        private static List<ItemLines> _cart = new List<ItemLines>();
        
        public void Display()
        {
            
            
            Log.Information("Products have been shown");
            Console.WriteLine("------ Products --------");
             foreach (var _productInfo in listOfProducts)
            {
                Console.WriteLine(_productInfo);
                Console.WriteLine("-------------------");
            }
            Console.WriteLine("------ Products --------");
            Console.WriteLine("[1] - Start Order");
            Console.WriteLine("[2] - Place Order");
            Console.WriteLine("[0] - Go Back");
        }


        public string UserInput()
        {
            
            string asn = Console.ReadLine();
            switch(asn)
            {

               
                case "1":
                    Log.Information("User started an order");
                    Console.WriteLine("Please Enter your  product ID");
                    int productID = Convert.ToInt32(Console.ReadLine());  
                    while(listOfProducts.All(product => product.productID != productID))
                    {
                        Console.WriteLine("Please Enter your product ID");
                        productID = Convert.ToInt32(Console.ReadLine());  

                    }  
                    Console.WriteLine("How much would you like to buy?");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    _cart.Add(new ItemLines()
                    {
                        productid = productID,
                        quantity = quantity,
                    });   
                    
                    Console.WriteLine("==Shopping Cart==");
                    foreach (var p_name in _cart)
                    {
                        // listOfProducts 
                        Console.WriteLine("Name: " + listOfProducts.Find(p =>p.productID == p_name.productid).ItemName);
                        
                        Console.WriteLine("Price: " + listOfProducts.Find(p =>p.productID == p_name.productid).Price);
                        Console.WriteLine("=============");
                        // Console.WriteLine(p_name.ItemName);
                        // Console.WriteLine(p_name.Price);
                        
                    }    
                    Console.WriteLine("============");              
                    Console.ReadLine();
                     return "StoreMenu";
                case "2":
                    Log.Information("User submitted an order");
                    Console.WriteLine("Your Order has been submitted");
                    _LakeJacksonCycleBL.PlaceOrder(PlaceOrder.selectedCustomer.cId, StoreFrontUI.selectedStore.storeId, _cart,TotalPrice(_cart));
                    
                    Console.WriteLine("Will now return you to main menu");
                    Console.ReadLine();
                    return "MainMenu";
                case "0":
                    return "MainMenu";
                default:
                    return "PlaceOrder";
            }
        }   
        public double TotalPrice(List<ItemLines> _cart)
        {
            double totalPrice = 0;
            Products _product = new Products();
    
            foreach(var product in _cart)
            {
               _product =  _LakeJacksonCycleBL.GetAllProducts().Find(p =>p.productID == product.productid);
                totalPrice += _product.Price * product.quantity;
            }

            return totalPrice;
        } 
    }
}