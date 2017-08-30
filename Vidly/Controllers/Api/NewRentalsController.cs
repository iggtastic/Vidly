using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    // we're making the rental functionality API-based since it returns data, not markup
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            // edge case security - not needed for an internally-called API
            //if (newRental.MovieIds.Count == 0)
            //    return BadRequest("No movie Ids were selected for rental.");

            // this populates a list with the group of movies that match the ids in the provided list of ids
            // translation: SELECT * FROM Movies WHERE Id IN (1,2,3)
            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            // edge case security - not needed for an internally-called API
            //if (movies.Count != newRental.MovieIds.Count)
            //    return BadRequest("One or more movie ids are invalid.");

            // edge case security - not needed for an internally-called API
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            //if (customer == null)
            //    return BadRequest("Invalid customer Id");

            // using Single and not SingleOrDefault since the input is controlled
            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            foreach (var movie in movies) {
                if (movie.NumberAvailable == 0)
                    return BadRequest("No copies of " + movie.Name + " are in stock.");

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                movie.NumberAvailable--;

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok(); // can't use Created() since it requires a URI to a specific resource. here there are multiple rentals.
        }
    }
}