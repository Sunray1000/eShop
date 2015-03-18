using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.enums;

namespace eShop.DomainClasses
{
    public class Review
    {
        public int CustomerId;
        public Customer Customer;
        public DateTime ReviewDateTime;
        public string ReviewDescription;
        public Rating StarRating ;
    }
}
