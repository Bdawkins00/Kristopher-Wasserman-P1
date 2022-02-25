namespace LakeJacksonCyclingModel
{
    public class Orders
    {
        public int orderID {get;set;}
        public int productID {get;set;}
        public string pName {get;set;}
        public string pAddress {get;set;}
        public double Price {get;set;}
        public int storeid {get;set;}

        public string storeName {get;set;}
        public string StoreAddress {get;set;}
        public decimal OrderTotal {get;set;}
        public int Quantity {get;set;}
       
        public List<ItemLines> LineItems{get;set;}

         public override string ToString()
         {
             return $"Order Id: {orderID}" + " " + $" Store ID: {storeid} \nProduct Name: {pName} " +  " " +$" Price: {Price} \n Total Price: {OrderTotal} " + " " + $"Quantity Ordered: {Quantity}\n ";
         }
    }
}