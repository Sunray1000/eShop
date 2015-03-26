using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using eShop.DomainClasses;
using Useful.Money;

namespace eShop.DataLayer
{
    public class eShopContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ContactDetail> ContactDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public eShopContext()
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderItemConfiguration());
            modelBuilder.Configurations.Add(new ContactDetailConfiguration());
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new ReviewConfiguration());
            modelBuilder.ComplexType<Money>();
        }
    }


    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            Property(c => c.UserName).IsRequired().HasMaxLength(30);
            Property(c => c.CustomerId).HasColumnOrder(0);
            Property(c => c.FirstName).HasColumnOrder(1);
            Property(c => c.LastName).HasColumnOrder(2);
            Property(c => c.RowVersion).IsRowVersion().IsConcurrencyToken();
            HasRequired(c => c.Addresses).WithMany().HasForeignKey(a => a.CustomerId);
        }
    }

    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            Property(a => a.Name).IsRequired();
            Property(a => a.AddressType).IsRequired();
            Property(a => a.RowVersion).IsRowVersion().IsConcurrencyToken();
        }
    }

    public class OrderConfiguration : EntityTypeConfiguration<Order>
    {
        public OrderConfiguration()
        {
            Property(o => o.DeliveryAddressId).IsRequired();
            Property(o => o.CustomerId).IsRequired();
            Property(o => o.OrderDateTime).IsRequired();
            Property(o => o.RowVersion).IsRowVersion().IsConcurrencyToken();
            HasRequired(o => o.OrderItems).WithMany();
        }
    }


    public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemConfiguration()
        {
            HasKey(oi => oi.OrderItemId);
            Property(oi => oi.OrderId).IsRequired();
            Property(oi => oi.RowVersion).IsRowVersion().IsConcurrencyToken();
            Property(oi => oi.ProductId).IsRequired();

            HasRequired(oi => oi.ProductOrdered);
        }
    }

    public class ProductConfiguration : EntityTypeConfiguration<Product>
    {
        public ProductConfiguration()
        {
            HasKey(p => p.ProductId);
            Property(p => p.RowVersion);
        }
    }

    public class ContactDetailConfiguration : EntityTypeConfiguration<ContactDetail>
    {
        public ContactDetailConfiguration()
        {
            HasKey(cd => cd.ContactDetailId);
            Property(cd => cd.RowVersion).IsRowVersion().IsConcurrencyToken();
            Property(cd => cd.ContactDescription).IsRequired();
        }
    }

    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            HasKey(r => r.ReviewId);
            Property(r => r.RowVersion).IsRowVersion().IsConcurrencyToken();
            Property(r => r.ReviewDescription).IsRequired();
            Property(r => r.ReviewDateTime).IsRequired();
        }
    }
    
}