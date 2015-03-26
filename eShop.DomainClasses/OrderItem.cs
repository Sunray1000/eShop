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
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public virtual Product ProductOrdered { get; set; }
        public int Quantity { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
