using System.Web.Mvc;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Controllers
{
    public class MatchController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        private Game CurrentGame
        {
            get { return (Game)Session["CurrentGame"]; }
            set { Session["CurrentGame"] = value; }
        }
    }
}