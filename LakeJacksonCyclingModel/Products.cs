using System.ComponentModel.DataAnnotations;

namespace LakeJacksonCyclingModel
{
    public class Products
    {
        public int productID {get;set;}
        private string _itemName;

        
        public string ItemName
        {
            get {return _itemName; }
            set
            {
                if(value != "")
                {
                    _itemName = value;
                }
                else
                {
                    throw new ValidationException(" Enter a name for the item");

                }
            }
            
        }

        private string _iDescription;
        public string Description
        {
            get { return _iDescription;}
            set
            {
                if(value != "")
                {
                    _iDescription = value;
                }
                else
                {
                    throw new ValidationException("Product must have a description.");
                }
            }
        }
        private double _itemPrice;
        public double Price
        {
            get {return _itemPrice ;}
            set
            {
                if(value != 0.00)
                {
                    _itemPrice = value;
                }
                else
                {
                    
                    throw new ValidationException("Please enter a valid price. Above 0.00");
                }
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity;  }
            set
            {
                if(value >= 0)
                {
                    _quantity = value;
                }
                else
                {
                    throw new ValidationException("Quantity can not be less than 0,This means we dont have anything!");
                }
            }
        }

        
        
        public override string ToString()
        {
            return $"ID: {productID}\n Name: {ItemName}";
        }
    }
}