using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFighter.UI.Web.Controllers
{
    public class FightController : Controller
    {
        // GET: Fight
        public ActionResult Index()
        {
            return View();
        }
    }
}