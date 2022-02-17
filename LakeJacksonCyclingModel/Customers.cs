namespace LakeJacksonCyclingModel
{
    public class Customers
    {
        private string name;
        private string _zip;
        private string _state;
        private string _email;
        public int cId {get;set;}
        public string Name{
            get{return name;}
            set
            {
                if(name != " ")
                {
                      name = value;  
                }
                else
                {
                    throw new Exception("The customer must have a name to be called by");
                }
            }

        } 
        
        public string Address { get; set;}
        public string City { get; set; }


        public string State {get;set;}
        public string Zip 
        {
            get{ return _zip;}
            set
            {
                if(_zip != " ")
                {
                    _zip = value;
                }
                else
                {
                    throw new Exception("A customer must have a zip code");
                }
            }
        }
        public string Email 
        {
            get{ return _email;}

            set
            {
                _email = value;
            }
        }
        public string PhoneNumber { get; set; }

        private List<Orders> _orders;
        public List<Orders> Ordered
        {
            get { return _orders; }

            set
            {
                _orders = value;
            }
        }

        
        public override string ToString()
        {
           return $"Id: {cId} \nName: {Name} \n City: {City} \n State: {State}";
        }
    }
}
