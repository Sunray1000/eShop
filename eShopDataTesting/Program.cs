using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using eShop.DataLayer;
using eShop.DomainClasses;
using log4net;
using log4net.Config;
using eShop;

[assembly: XmlConfigurator(Watch=true)]

namespace eShopDataTesting
{
    public class Program
    {

        static void Main(string[] args)
        {
            var log = LogManager.GetLogger(typeof (Program));

            log.Info("Starting Application");

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<eShopContext,eShop.DataLayer.Migrations.Configuration>());
            ICollection<Customer> customers = GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer Name = {0}", customer.FirstName + " " + customer.LastName);
            }

            Console.WriteLine("Press enter to continue...");
            log.Info("Ending Program");

            Console.ReadLine();
        }

        public static ICollection<Customer> GetCustomers()
        {
            using (var context = new eShopContext())
            {
               return context.Customers.ToList();
            }
        }

        
    }

}
