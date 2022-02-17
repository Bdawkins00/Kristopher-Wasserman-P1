using LakeJacksonCyclingModel;

namespace LakeJacksonCyclingDL
{
    public interface IRepository
    {
           Products AddProduct( Products p_name);
           Customers AddCustomer( Customers p_name);
           /// <summary>
            ///     Gets the current list of customers within the database.
            /// </summary>
            /// <returns></returns>
            List<Customers> GetAllCustomers();
            List<Products> GetProducts();
            List<Products> GetAllProducts();
            List<StoreFrontModel> GetAllStoreFront();
            Orders PlaceOrder(int customerID, int storeID, List<ItemLines> _cart, double totalPrice);  

            List<Inventory> GetAllInventory(); 
            void AddProductToStore(int storeID,int  productID,int quantity);
            List<Orders> GetCustomerHistory(int customerid);

            List<StoreModel> GetStoreHistory(int storeid);

            List<Inventory> ReplemishInventory(int storeid, int productid, int quantity);
    }
}

