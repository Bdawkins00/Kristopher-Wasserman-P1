namespace LakeJacksonCyclingModel
{
    public class StoreFrontModel
    {
        //public int selectedStore {get;set;}
        public int storeId {get;set;}
        public string StoreName {get;set;}
        public string Address {get;set;}
        public string Phone {get;set;}
        // public StoreFrontModel()
        // {
        //         StoreName = "Lake Jackson Cycling";
        //         Address = "123 Oyster Point Blvd, Lake Jackson, TX 77566";
        //         Phone = "8083989431";

        // }
        public override string ToString()
        {
            return $"ID: {storeId}\n Name: {StoreName}";
        }
    }
    
}