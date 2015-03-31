using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using eShop.DataLayer;
using eShop.DataLayer.Migrations;
using eShop.DomainClasses;
using eShop.DomainClasses.enums;
using eShop.enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Useful.Money;

namespace eShop.DataLayerTest
{
    [TestClass]
    public class eShopDataLayerTest
    {
        [ClassInitialize]
        public static void ClassInitialise(TestContext context)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<eShopContext>());
        }

        [TestInitialize]
        public void TestInitialise()
        {
        }

        [TestMethod]
        [ExpectedException(typeof (DbEntityValidationException))]
        public void TestCustomerMissingUserName()
        {
            using (var context = new eShopContext())
            {

                Customer customer = new Customer()
                {
                    FirstName = "Alex",
                    LastName = "Macklen"
                };

                customer.Addresses.Add(new Address()
                {
                    Name = "Delivery",
                    AddressLine1 = "Line1",
                    AddressLine2 = "Line2",
                    AddressType = AddressType.Billing
                });

                context.Customers.Add(customer);
                context.SaveChanges();

                context.Customers.ToList();
            }

        }

        [TestMethod]
        [ExpectedException(typeof (DbEntityValidationException))]
        public void TestAddressMissingName()
        {
            Address address = new Address()
            {
                AddressLine1 = "Address line 1",
                AddressLine3 = "Address line 3",
                AddressType = AddressType.Delivery
            };

            using (var context = new eShopContext())
            {
                context.Addresses.Add(address);
                context.SaveChanges();
            }
        }

        [TestMethod]
        [ExpectedException(typeof (DbEntityValidationException))]
        public void TestMissingContactDetailDescription()
        {
            Customer customer = new Customer()

            {
                UserName = "Sunray",
                FirstName = "Alex",
                LastName = "Macklen",
            };

            ContactDetail contactDetail = new ContactDetail()
            {
                ContactDetailType = ContactDetailTypes.Phone,
                Email = "sunray1@clara.co.uk",
                PhoneNumber = "010101010101"
            };

            customer.ContactDetails.Add(contactDetail);

            using (var context = new eShopContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        [TestMethod]
        [ExpectedException(typeof (DbEntityValidationException))]
        public void TestCustomerUserNameOverLength()
        {
            Customer customer = new Customer()
            {
                UserName = "0123456790012345679001234567901"
            };

            using (var context = new eShopContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestCustomerUserNameLength()
        {
            Customer customer = new Customer()
            {
                UserName = "012345679001234567900123456790"
            };

            using (var context = new eShopContext())
            {
                context.Customers.Add(customer);
                context.SaveChanges();
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateException))]
        public void TestOrderMissingCustomerId()
        {
            using (var context = new eShopContext())
            {
                Product product = new Product()
                {
                    Category = ProductCategories.CPU,
                    Colour = "Red",
                    Name = "Hard Disk",
                    Price = new Money(100m),
                    Manufacturer = Manufacturers.IBM
                };

                Address address = new Address()
                {
                    Name = "Test Address Name"
                };

                context.Products.Add(product);
                context.SaveChanges();

                Order order = new Order()
                {
                    DeliveryAddressId = address.AddressId
                };

                OrderItem orderItem = new OrderItem()
                {
                    ProductId = product.ProductId,
                    ProductOrdered = product,
                    Quantity = 1
                };

                order.OrderItems.Add(orderItem);


                orderItem = new OrderItem()
                {
                    ProductId = product.ProductId,
                    ProductOrdered = product,
                    Quantity = 2
                };

                order.OrderItems.Add(orderItem);

                orderItem = new OrderItem()
                {
                    ProductId = product.ProductId,
                    ProductOrdered = product,
                    Quantity = 3
                };

                order.OrderItems.Add(orderItem);

                Customer customer = new Customer()
                {
                    UserName = "Sunray1",
                    FirstName = "Paul",
                    LastName = "Smith"
                };

                customer.Addresses.Add(address);
                context.Customers.Add(customer);
                context.Orders.Add(order);
                context.SaveChanges();
                Assert.IsTrue(true);
            }
        }

        public class Test
        {

            public Test()
            {
                while (true)
                {
                    
                }
            }
        }  
    }
}

