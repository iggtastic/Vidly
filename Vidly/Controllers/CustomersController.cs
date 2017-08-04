using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // this is how to establish a connection to a database in the model
        // we need to
        //   1 - declare a private variable to store the ApplicationDbContext instance
        //   2 - initialize that instance variable in the class constructor
        //   3 - dispose of the instance variable in an overrided Dispose method
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost] // no http get! actions that modify data should never use http get!
        public ActionResult Save(Customer customer) // this is model binding. MVC binds the request data to this model/view model
        // MVC is smart enough to map the fields in the form data to the Customer class instance since all of the fields are preceeded by "customer."
        {
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customerInDb.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers"); // return the user to the customer index once they click the submit button
        }

        // GET: Customers
        public ActionResult Index()
        {
            // this gets all customers from the database
            // the database is not accessed here, but rather in the view while looping
            // need to use the Include method to pull in the MembershipType class since
            //   Customer is dependent on it and it will not be loaded by MVC by default
            //   in the View. the View will only pull in the explicitly referenced class,
            //   Customer. Basically, we're tying Customer to MembershipType.
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
            //return View(GetCustomers());
        }

        public ActionResult Details(int id)
        {
            // gets the customer matching the provided id
            // note that this query will be executed against the db immediately
            //   due to use of the Linq method, SingleOrDefault
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            // from the db, grab the single customer with the id matching the local variable
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel); // have to pass in the name of the View explicitly since this is an override (normally, the Edit view would be returned)
        }

        // this method is not required anymore since we're using the database instead
        //   of a static list
        //private IList<Customer> GetCustomers()
        //{
        //    return new List<Customer> {
        //        new Customer { Id = 1, Name = "John Smith" },
        //        new Customer { Id = 2, Name = "Mary Williams" }
        //    };
        //}
    }
}