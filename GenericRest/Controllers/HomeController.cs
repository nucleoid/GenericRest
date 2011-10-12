using System.Web.Mvc;

namespace GenericRest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Generic JSON REST project";

            return View();
        }
    }
}
