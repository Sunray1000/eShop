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
        public int ReviewId;
        public Customer Customer;
        public int CustomerId;
        public DateTime ReviewDateTime;
        public string ReviewDescription;
        public Rating StarRating;
    }
}
