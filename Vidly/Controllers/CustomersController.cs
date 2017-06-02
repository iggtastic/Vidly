using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;

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
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
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