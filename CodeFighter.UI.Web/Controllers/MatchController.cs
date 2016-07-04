using System.Web.Mvc;
using CodeFighter.BL;

namespace CodeFighter.UI.Web.Controllers
{
    public class MatchController : Controller
    {
        public ActionResult Index()
        {

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