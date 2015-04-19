using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eShop.DataLayer;
using eShop.DomainClasses;
using eShop.Repository;

namespace eShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly eShopContext _eShopDb = new eShopContext();

        // GET: Customer
        public ActionResult Index()
        {
            CustomerRepository customerRepository = new CustomerRepository(_eShopDb);
            List<Customer> customers = customerRepository.GetCustomers();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            Customer customer = _eShopDb.Customers.Find(id);
            return View(customer);
        }

        public ActionResult Search(string name)
        {
            CustomerRepository customerRepository = new CustomerRepository(_eShopDb);
            Customer customer = customerRepository.GetCustomer(name);
            return View(customer);
        }
        

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                foreach (Customer customer in collection)
                {
                    _eShopDb.Customers.Add(customer);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
