using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
    [AllowAnonymous] // this overrides our global filter (filter.config) dissallowing anonymous access
    public class HomeController : Controller
    {
        // this will cause mvc to use the cached version of the page instead of grabbing a fresh one.
        //   it will also store the cached version on the server.
        //   it will also store a different cached version for each different genre.
        //      if you use "*" then every different parameter will cause a new cached page.
        //[OutputCache(Duration =50,Location =OutputCacheLocation.Server,VaryByParam ="genre")]
        // this line will disable all browser caching for the page
        //[OutputCache(Duration =0,VaryByParam ="*",NoStore =true)]
        public ActionResult Index()
        {
            return View();
        }
    }
}