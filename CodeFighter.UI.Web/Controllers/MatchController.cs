using System.Web.Mvc;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Controllers
{
    public class MatchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return ReturnView();
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
                case "F": return GoToResult();
            }
            if (!CurrentGame.HasWinner())
                return ReturnView();
            if (!CurrentGame.CanFatalityPlayer1() && !CurrentGame.CanFatalityPlayer2())
                return GoToResult();
            return ReturnView();
        }

        private ActionResult GoToResult()
        {
            if (CurrentGame.Player1.Life > 0)
                ScorePlayer1++;
            else
                ScorePlayer2++;
            return RedirectToAction("Index", "FinalPlay");

        }

        private ActionResult ReturnView()
        {
            ViewBag.Score = string.Format("{0}:{1}", ScorePlayer1, ScorePlayer2);
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