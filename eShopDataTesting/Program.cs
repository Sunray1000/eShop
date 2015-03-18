using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.DataLayer;
using eShop.DomainClasses;


namespace eShopDataTesting
{
    class Program
    {
        static void Main(string[] args)
        {
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
                return context.Customers.ToList();
            }
        }
    }


}
