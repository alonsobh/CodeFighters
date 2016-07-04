using CodeFighter.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFighter.UI.Web.Controllers
{
    public class FightController : Controller
    {
        private Game Game
        {
            get
            {
                return (Session["game"] as Game);
            }
        }

        // GET: Fight
        public ActionResult Index()
        {
            ViewBag.PlayerName1 = Game.Player1.Name;
            ViewBag.PlayerName2 = Game.Player2.Name;
            ViewBag.PlayerScore1 = Game.Player1.EnergyString;
            ViewBag.PlayerScore2 = Game.Player2.EnergyString;
            return View();
        }
    }
}