using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.enums;
using Useful.Money;

namespace eShop.DomainClasses
{
    public class Product
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
        public ProductCategories Category { get; set; }
        public Money Price { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<string> Specification { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
