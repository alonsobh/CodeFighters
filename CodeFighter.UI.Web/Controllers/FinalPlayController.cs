using System.Web.Mvc;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Controllers
{
    public class FinalPlayController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Winner = CurrentGame.GetWinner();
            if (ScorePlayer1 > 1 || ScorePlayer2 > 1)
            {
                ScorePlayer1 = 0;
                ScorePlayer2 = 0;
            }
            SetNewGame();
            return View(CurrentGame);
        }

        private void SetNewGame()
        {
            CurrentGame = new Game(CurrentGame.Player1.Name, CurrentGame.Player1.Role, CurrentGame.Player2.Name, CurrentGame.Player2.Role);
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