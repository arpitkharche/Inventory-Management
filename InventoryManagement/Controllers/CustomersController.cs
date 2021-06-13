using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagement.Models;
using System.Data.Entity;
using InventoryManagement.ViewModel;


namespace InventoryManagement.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _Context;

        public CustomersController()
        {
            _Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _Context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            var customers = _Context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }
        
        public ActionResult New()
        {
            var membershipType = _Context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipType = membershipType
            };
            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _Context.Customers.Add(customer);
            else
            {
                var customerInDb = _Context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
           
            _Context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }
        public ActionResult Details(int id)
        {
            var Customer = _Context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (Customer == null)
                return HttpNotFound();

            return View(Customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _Context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipType = _Context.MembershipTypes.ToList(),
            };
            return View("CustomerForm", viewModel);




        }

        //private IEnumerable<Customer> GetCustomer()
        //{
        //    return new List<Customer>
        //    {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Willams" }
        //    };
        //}
    }
}