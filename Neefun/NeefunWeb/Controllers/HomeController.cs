using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeefunWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //sreturn RedirectToAction("Index", "Swim");
            return View();
        }

        //public ActionResult Contact()
        //{
        //    ViewBag.Message = "Contact";

        //    return View();
        //}
    }
}