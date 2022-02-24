namespace LakeJacksonCyclingModel
{
    public class StoreFrontModel
    {
      
        public int storeId {get;set;}
        public string StoreName {get;set;}
        public string Address {get;set;}
        public string Phone {get;set;}
        
        public override string ToString()
        {
            return $"ID: {storeId}\n Name: {StoreName}";
        }
    }
    
}