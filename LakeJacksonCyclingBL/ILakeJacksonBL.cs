using LakeJacksonCyclingModel;


namespace LakeJacksonCyclingBL
{
    /// <summary>
    /// This Data layer is used to make things happen. 
    /// </summary>
    public interface ILakeJacksonBL
    {
        

        /// <summary>
        /// Adds a customer to our customer database 
        /// </summary>
        /// <param name="p_name">name is being used to add to the database</param>
        /// <returns></returns>
        Customers AddCustomer(Customers p_name);
        List<Products> SearchProducts(string name);

        List<Products> GetAllProducts();

        List<Customers> GetAllCustomers();
        List<Customers> SearchCustomer(string name);

       Customers GetCustomerById(int customerID);

        StoreFrontModel GetStoreFrontById(int storeid);
      List<Products> GetAllProductsByStoreID(int storeid);

      List<StoreFrontModel> GetAllStoreFront();

    /// <summary>
    /// this function will add Inventory to the store
    /// </summary>
    /// <param name="p_name"></param>
    /// <returns></returns>
        Products AddProduct(Products p_name);

       Orders PlaceOrder(int customerID, int storeID, List<ItemLines> _cart, double totalPrice);

      List<Inventory> GetAllInventory();

      List<Inventory> GetAllInventoryByStoreId(int storeID);
      
      List<Orders> GetCustomerHistory(int customerid);
      void AddProductToStore(int storeID,int  productID,int quantity);
      List<StoreModel> GetStoreHistory(int storeid);
      List<Inventory> ReplemishInventory(int storeid, int productid, int quantity);
    }
}


