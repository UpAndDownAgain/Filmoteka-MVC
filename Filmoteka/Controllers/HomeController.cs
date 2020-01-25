using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Filmoteka.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "O aplikaci";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Kontaktní stránka.";

            return View();
        }
    }
}