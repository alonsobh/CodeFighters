using System.Web.Mvc;
using CodeFighter.BL;
using System;

namespace CodeFighter.UI.Web.Controllers
{
    public class HomeController : Controller
    {

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Go(string Player1, string Player2, string PlayerType1, string PlayerType2)
        {
            Session["CurrentGame"] = new Game(Player1, (GameRoleList) Enum.Parse(typeof(GameRoleList), PlayerType1), Player2, (GameRoleList) Enum.Parse(typeof(GameRoleList), PlayerType2));
            return RedirectToAction("Index", "Match");
        }
    }
}