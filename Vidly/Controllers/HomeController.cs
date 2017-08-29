using System.Web.Mvc;

namespace Vidly.Controllers
{
    [AllowAnonymous] // this overrides our global filter (filter.config) dissallowing anonymous access
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}