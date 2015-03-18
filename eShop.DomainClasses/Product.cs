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
        Product()
        {
            _reviews = new List<Review>();
            _specification = new List<string>();
        }

        [Key]
        public int ProductId;
        public string Name;
        public Manufacturers Manufacturer;
        public string ManufactureProductId;
        public string Colour;
        public string ShortDescription;
        public string LongDescription;
        
        public ProductCategories Category;
        public Money Price;

        private List<string> _specification;

        public int ReviewId;
        private List<Review> _reviews;
        
        public ICollection<Review> Reviews
        {
            get { return _reviews;}
            set { _reviews = new List<Review>(value); }
        }

        public ICollection<string> Specification
        {
            get { return _specification;}
            set { _specification = new List<string>(value); }
        }
    }
}
