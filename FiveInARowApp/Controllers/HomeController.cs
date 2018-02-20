using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiveInARowApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Learning through Literature";

            return View();
        }

        public ActionResult BuyNow()
        {
            ViewBag.Message = "To purchase the curriculum:";

            return View();
        }
    }
}