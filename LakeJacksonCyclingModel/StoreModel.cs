namespace LakeJacksonCyclingModel
{
    public class StoreModel
    {
        public int storeid {get;set;}
        public string  StoreName {get;set;}
        public string StoreAddress{get;set;}
        public string Phone {get;set;}

        public string pName {get;set;}
        public int orderid {get;set;}
        public int productid {get;set;}

        public decimal orderTotal{get;set;}


        public override string ToString(){
            return $"Orderid: {orderid}" + " " + $"Product Name: {pName} " + " " + $"Product ID: {productid}" + "" + $"Orders Total: {orderTotal}";
        }
    }
    
    
}