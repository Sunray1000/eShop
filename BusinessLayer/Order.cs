using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Order
    {
        public int OrderId;

        public int CustomerId;
        public Customer Customer;

        public DateTime OrderDateTime;

        public Order()
        {
            _products = new List<Product>();
        }

        private List<Product> _products;

        public ICollection<Product> Products
        {
            get { return _products;}
            set { _products = new List<Product>(value); }
        }

        public int AddressId;
        public Address Address;
    }
}
