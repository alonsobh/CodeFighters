using System.Web.Mvc;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Controllers
{
    public class MatchController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {

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
                case "F": break;
            }
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
    }
}