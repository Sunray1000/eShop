using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using eShop.DataLayer;
using eShop.DomainClasses;
using eShop.Repository;
using Microsoft.Owin.Security.DataHandler.Encoder;

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
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eShopDb.Customers.Add(customer);
                    _eShopDb.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Problem");
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            Customer customer = _eShopDb.Customers.Find(id);
            return View("Edit", customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eShopDb.Entry(customer).State = EntityState.Modified;
                    _eShopDb.SaveChanges();
                    return RedirectToAction("Index", new { id = customer.CustomerId });
                }

                return View(customer);
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_eShopDb.Customers.Find(id));
        }

        // POST: Customer/Delete/5
        [HttpPost]
        public ActionResult Delete(Customer customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _eShopDb.Entry(customer).State = EntityState.Deleted;
                    _eShopDb.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
