﻿using System.Web.Mvc;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Controllers
{
    public class MatchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Score = string.Format("{0}:{1}", ScorePlayer1, ScorePlayer2);
            return View(CurrentGame);
        }

        [HttpPost]
        public ActionResult Index(bool isPlayer1, string move)
        {
            switch (move)
            {
                case "P": CurrentGame.Punch(isPlayer1); break;
                case "K": CurrentGame.Kick(isPlayer1); break;
                case "S": CurrentGame.Special(isPlayer1); break;
                case "H": CurrentGame.Heal(isPlayer1); break;
                case "F": return RedirectToAction("Index", "FinalPlay");
            }
            ViewBag.Score = string.Format("{0}:{1}", ScorePlayer1, ScorePlayer2);
            if (!CurrentGame.HasWinner())
                return View(CurrentGame);
            if (CurrentGame.Player1.Life <= 0)
                ScorePlayer1++;
            else
                ScorePlayer2++;
            if (!CurrentGame.CanFatalityPlayer1() && CurrentGame.CanFatalityPlayer2())
                return RedirectToAction("Index", "FinalPlay");
            return View(CurrentGame);
        }

        private Game CurrentGame
        {
            get { return (Game)Session["CurrentGame"]; }
            set { Session["CurrentGame"] = value; }
        }

        private int ScorePlayer1
        {
            get { return (int?)Session["ScorePlayer1"] ?? 0; }
            set { Session["ScorePlayer1"] = value; }
        }

        private int ScorePlayer2
        {
            get { return (int?)Session["ScorePlayer2"] ?? 0; }
            set { Session["ScorePlayer2"] = value; }
        }
    }
}