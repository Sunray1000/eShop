using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
        //[ExpectedException()]
        public void TestCustomerValidation()
        {
            using (var context = new eShopContext())
            {
                //Customer customer = new Customer()
                //{
                //    UserName = "",
                //    FirstName = "Alex",
                //    LastName = "Macklen"
                //};

                //Address address = new Address()
                //{
                //    Name = "Delivery",
                //    AddressLine1 = "Line1",
                //    AddressLine2 = "Line2",
                //    AddressType = AddressType.Billing
                //};

                //customer.Addresses.Add(address);
                //context.Customers.Add(customer);
                //context.SaveChanges();
            }

        }
    }
}
