using LakeJacksonCyclingModel;
using LakeJacksonCyclingDL;


namespace LakeJacksonCyclingBL
{
    public class LakeJacksonBL : ILakeJacksonBL
    {
        /// <summary>
        /// The injection below allows functions to do what they need to get done.
        /// </summary>
        private readonly IRepository _repo;
        public LakeJacksonBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        public Customers AddCustomer(Customers p_name)
        {
            
              return _repo.AddCustomer(p_name);
            
        }

        public Products AddProduct(Products p_name)
        {
            return _repo.AddProduct(p_name);
        }

        public List<Products> GetAllProducts()
        {
            return _repo.GetAllProducts();
        }

        public List<Customers> SearchCustomer(string p_name)
        {
            List<Customers> CustomerList = _repo.GetAllCustomers();

            return CustomerList.Where(cList => cList.Name.Contains(p_name)).ToList();
        }
        

        

        public List<Products> SearchProducts(string name)
        {
            List<Products> ProductList = _repo.GetProducts();
            return ProductList.Where(pList => pList.ItemName.Contains(name)).ToList();
        }

       
        public List<Customers> GetAllCustomers()
        {
             return _repo.GetAllCustomers();
        }

        

        public Customers GetCustomerById(int customerID)
        {
            return GetAllCustomers().Where(customer => customer.cId.Equals(customerID)).First();
        }

        public Orders PlaceOrder(int customerID, int storeID, List<ItemLines> _cart, double totalPrice)
        {
            return _repo.PlaceOrder(customerID, storeID, _cart, totalPrice);
        }

        public List<StoreFrontModel> GetAllStoreFront()
        {
            return _repo.GetAllStoreFront();
        }


        public List<Products> GetAllProductsByStoreID(int storeid)
        {
            List<Products> listOfProduct = new List<Products>();
            foreach (var p_name in GetAllInventoryByStoreId(storeid))
            {
                listOfProduct.Add(GetAllProducts().Find(p => p.productID.Equals(p_name.productID)));
            }
            
            return listOfProduct;
        }

        public StoreFrontModel GetStoreFrontById(int storeID)
        {
            return GetAllStoreFront().Where(storeid=>storeID.Equals(storeID)).First();
        }

        public List<Inventory> GetAllInventory()
        {
            return _repo.GetAllInventory();
        }

        public List<Inventory> GetAllInventoryByStoreId(int storeID)
        {
            return GetAllInventory().FindAll(p => p.storeID.Equals(storeID));
        }

        public void AddProductToStore(int storeID, int productID, int quantity)
        {
           _repo.AddProductToStore(storeID,  productID, quantity);
        }

        public List<Orders> GetCustomerHistory(int customerid)
        {
           return  _repo.GetCustomerHistory(customerid);
        }
        public List<StoreModel> GetStoreHistory(int storeid)
        {
           return  _repo.GetStoreHistory(storeid);
        }

        public List<Inventory> ReplemishInventory(int storeid, int productid, int quantity)
        {
            return _repo.ReplemishInventory(storeid, productid, quantity);
        }

        public List<Employee> Employees()
        {
            return _repo.GetEmployees();
        }

        public bool IsAdmin(int eID, string password)
        {
            try
            {
                Employee ep = new Employee();
                ep = Employees().Where(ep => ep.employeeID.Equals(eID) & ep.password.Equals(password)).First();
                return ep.IsManager;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public List<Employee> Employees(int eID, string password)
        {
            throw new NotImplementedException();
        }
    }
}