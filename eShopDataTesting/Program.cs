﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using eShop.DataLayer;
using eShop.DomainClasses;
using eShop.LoggingConfiguration;
using log4net;
using log4net.Config;
using log4net.Repository.Hierarchy;
using System.Data.SqlClient;
using System.Globalization;
using Configuration = eShop.DataLayer.Migrations.Configuration;

[assembly: XmlConfigurator(Watch=true)]

namespace eShopDataTesting
{
    public class Program
    {

        static void Main(string[] args)
        {
            var log = LogManager.GetLogger(typeof (Program));

            log.Info("Starting Application");

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<eShopContext,Configuration>());
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
