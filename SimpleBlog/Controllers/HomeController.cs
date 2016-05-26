using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.selectedItem = "homt";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.selectedItem = "about";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.selectedItem = "contact";
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}