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
        public string Welcome(string n, int i = 0)
        {
            return HttpUtility.HtmlEncode("Hello " + n + ", Number is: " + i);
        }
    }
}