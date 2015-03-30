using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.DataLayer;
using eShop.DataLayer.Migrations;
using eShop.DomainClasses;


namespace eShopDataTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<eShopContext,Configuration>());
            ICollection<Customer> customers = GetCustomers();

            foreach (var customer in customers)
            {
                Console.WriteLine("Customer Name = {0}", customer.FirstName + " " + customer.LastName);
            }

            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }

        public static ICollection<Customer> GetCustomers()
        {
            using (var context = new eShopContext())
            {
                try
                {
                    return context.Customers.ToList();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }

}
