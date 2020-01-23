using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Filmoteka.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /Helloworld
        public ActionResult Index()
        {
            return View();
        }

        //GET: /HelloWorld/Welcome
        public ActionResult Welcome(string n, int i = 0)
        {
            ViewBag.Message = "Hello " + n;
            ViewBag.Number = i;

            return View();
        }
    }
}