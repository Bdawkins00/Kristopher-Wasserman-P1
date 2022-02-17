using LakeJacksonCyclingBL;
using LakeJacksonCyclingModel;

namespace LJCUI
{
    public class OrderHistory : IMenu
    {
        
        private ILakeJacksonBL _LakeJacksonCycleBL;

        private List<Orders> listofOrderHistory = new List<Orders>();
        private List<StoreModel> ListofStoreHistory = new List<StoreModel>();
        public OrderHistory(ILakeJacksonBL p_name)
        {
           _LakeJacksonCycleBL = p_name;
        }
        public void Display()
        {
            Console.WriteLine("====== Lake Jackson Cycling ======");
            Console.WriteLine("==[1] - View Order History by customer ID");
            Console.WriteLine("==[2] - View Order History by StoreID");
            Console.WriteLine("==[0] - Go Back");
            Console.WriteLine("====== Lake Jackson Cycling ======");
        }

        public string UserInput()
        {
            string ans = Console.ReadLine();
            switch (ans)
            {
                case "1":
                    Console.WriteLine("Please Enter the order id");
                    int orderID = Convert.ToInt32(Console.ReadLine());
                    listofOrderHistory = _LakeJacksonCycleBL.GetCustomerHistory(orderID);
                    foreach (var item in listofOrderHistory)
                    {
                        Console.WriteLine("==== Customer Order ====");
                        Console.WriteLine(item);
                        Console.WriteLine("==== Customer Order ====");
                        Console.ReadLine();
                    }
                    return "OrderHistory";
                case "2":
                    Console.WriteLine("Please Enter your storeid to continue!");
                    int storeId = Convert.ToInt32(Console.ReadLine());
                    ListofStoreHistory = _LakeJacksonCycleBL.GetStoreHistory(storeId);
                    foreach(var orders in ListofStoreHistory)
                    {
                        Console.WriteLine("===== Store History =====");
                        Console.WriteLine(orders);
                        Console.WriteLine("=========================");
                        Console.ReadLine();
                    }
                    return "OrderHistory";
                    
                case "0":
                    return "MainMenu";
                default:
                break;
            }
            return "OrderHistory";
        }
        
    }
}