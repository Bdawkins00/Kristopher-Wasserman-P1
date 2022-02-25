using System.ComponentModel.DataAnnotations;

namespace LakeJacksonCyclingModel
{
    public class Customers
    {
        private string name;
        private string _zip;
       
        
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
                    throw new ValidationException ("Please enter a valid zip code");
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
                    throw new ValidationException("A customer must have a zip code");
                }
            }
        }
        public string Email {get;set;}
        public string PhoneNumber { get; set; }

       
        public List<Orders> Ordered {get;set;}

        
        public override string ToString()
        {
           return $"Id: {cId} \nName: {Name} \n City: {City} \n State: {State}";
        }
    }
}
