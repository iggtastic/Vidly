using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // movies
        public ActionResult Index()
        {
            return View(GetMovies());            
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
    }
}