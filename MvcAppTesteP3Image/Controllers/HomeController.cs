using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppTesteP3Image.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Form(String catslug, String subcatslug)
        {
            ViewBag.Title = "Form";
            ViewBag.catslug = catslug;
            ViewBag.subcatslug = subcatslug;

            return View();
        }

        public ActionResult Admin()
        {
            ViewBag.Title = "Admin";

            return View();
        }
    }
}
