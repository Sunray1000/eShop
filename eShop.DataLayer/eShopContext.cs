using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using eShop.DomainClasses;

namespace eShop.DataLayer
{
    public class eShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        //public DbSet<Address> Addresses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
