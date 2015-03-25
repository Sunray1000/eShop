using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.enums;

namespace eShop.DomainClasses
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public Customer Customer { get; set; }
        public int CustomerId { get; set; }
        public DateTime ReviewDateTime { get; set; }
        public string ReviewDescription { get; set; }
        public Rating StarRating { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
