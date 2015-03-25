using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using eShop.DataLayer;
using eShop.DataLayer.Migrations;
using eShop.DomainClasses;
using eShop.enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
