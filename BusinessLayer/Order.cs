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
        public int OrderId;

        public int CustomerId;
        public Customer Customer;

        public DateTime OrderDateTime;

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

        public int AddressId;
        public Address Address;

        public Money TotalPrice
        {
            get { return _orderItems.Sum(); }
        }
    }
}
