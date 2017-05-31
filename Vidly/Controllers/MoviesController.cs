using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            var customers = new List<Customer>() {
                new Customer { Name = "bob" },
                new Customer { Name = "larry" }
            };
            var movie = new Movie() { Name = "Shrek" };

            // use a viewmodel when you need to include data from 2 or more
            //   different models since only 1 model can be imported in a view
            var viewModel = new RandomMovieViewModel { Movie = movie, Customers = customers };

            // this is a bad approach to passing data to views since it's fragile
            //ViewData["Movie"] = movie;
            //return View();

            // this is the preferred method of passing data to views
            //   since we can access the model properties directly in the view
            //return View(movie);

            // when using a viewmodel, pass the viewmodel to the view instead of the model
            return View(viewModel);

            // the View method will assign the variable 'movie' to an instance
            //   of ViewResult in its ViewData proprty, in its Model property,
            //   like this: viewResult.ViewData.Model

            //return Content("Hello World");
            //return HttpNotFound();
            //return new EmptyResult();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "Name" });


        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // movies
        public ActionResult Index()
        {
            return View(GetMovies());
            //if (!pageIndex.HasValue)
            //    pageIndex = 1;

            //if (string.IsNullOrWhiteSpace(sortBy))
            //    sortBy = "Name";

            //return Content(string.Format("pageIndex={0}@sortBy={1}", pageIndex, sortBy));
        }

        public ActionResult Details(int id)
        {
            var movie = GetMovies().SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        private IList<Movie> GetMovies()
        {
            return new List<Movie>
            {
                new Movie { Name = "Shrek", Id = 1 },
                new Movie { Name = "Fargo", Id = 2 }
            };
        }

        // sample attribute route with regex constraints
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {
            return Content(year + "/" + month);
        }
    }
}