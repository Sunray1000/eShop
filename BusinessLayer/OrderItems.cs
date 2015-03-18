using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DomainClasses
{
    public class OrderItems
    {
        [Key]
        public int OrderItemsId;
        public int OrderId;
        public int ProductId;
        public Product ProductOrdered;
        public int Quantity;
    }
}
