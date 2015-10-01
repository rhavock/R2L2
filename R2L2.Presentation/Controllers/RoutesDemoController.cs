using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace R2L2.Presentation.Controllers
{
    public class RoutesDemoController : Controller
    {
        // GET: RoutesDemo
        public ActionResult One()
        {
            return View();
        }

        public ActionResult Two(int donuts =1)
        {
            ViewBag.Donuts = donuts;
            return PartialView();
        }

        [Authorize]
        public ActionResult Three()
        {
            return View();
        }
    }
}