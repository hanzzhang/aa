using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeefunWeb.Controllers
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
            ViewBag.Message = "Neefun";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "请联系：";

            return View();
        }
    }
}