using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainClasses
{
    public class OrderItem
    {
        public int OrderItemsId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public Product ProductOrdered { get; set; }
        public int Quantity { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
