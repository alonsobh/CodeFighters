using System.Web.Mvc;

namespace CodeFighter.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Go()
        {
            return RedirectToAction("Index", "Fight");
        }
    }
}