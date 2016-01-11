using System.Collections.Generic;
using eShop.enums;
using Useful.Money;

namespace eShop.DomainClasses
{
    public class Product : ItemState
    {
        public Product()
        {
            Reviews = new List<Review>();
            Specification = new List<string>();
            Price = new Money();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public Manufacturers Manufacturer { get; set; }
        public string ManufactureProductId { get; set; }
        public string Colour { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public Money Price { get; set; }

        // Link to reviews by people for this product   
        public int ReviewId { get; set; }   
        public virtual ICollection<Review> Reviews { get; set; }

        // Link to the specification
        public int SpecificationId { get; set; }    
        public virtual ICollection<string> Specification { get; set; }

        //The category link
        public int CategoryId { get; set; } 
        public virtual ICollection<ProductCategory> Category { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
