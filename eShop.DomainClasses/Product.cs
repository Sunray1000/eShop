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
        private List<string> _specification;

        public int ReviewId { get; set; }
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

        public byte[] RowVersion { get; set; }
    }
}
