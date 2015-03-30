using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Useful.Money;

namespace eShop.DomainClasses
{
    public class Order : ItemState
    {
        [Key]
        public int OrderId { get; set; }

        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }

        public virtual ICollection<OrderItem> OrderItems { get; set; } 

        public int? DeliveryAddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public Money TotalPrice
        {
            get { return OrderItems.Sum(oi=>oi.Quantity*oi.ProductOrdered.Price.Amount); }
        }

        public byte[] RowVersion { get; set; }
    }
}
