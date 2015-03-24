using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Useful.Money;

namespace eShop.DomainClasses
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public DateTime OrderDateTime { get; set; }

        public Order()
        {
            _orderItems = new List<OrderItems>();
            OrderDateTime = DateTime.UtcNow;
        }

        private List<OrderItems> _orderItems;

        public ICollection<OrderItems> OrderItems
        {
            get { return _orderItems;}
            set { _orderItems = (List<OrderItems>)value; }
        }

        public int AddressId { get; set; }
        public Address DeliveryAddress { get; set; }

        public Money TotalPrice
        {
            get { return _orderItems.Sum(); }
        }
    }
}
