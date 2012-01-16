using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCAjaxTabs.Controllers
{
    public partial class HomeController : Controller
    {
        public virtual ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public virtual ActionResult About()
        {
            return View();
        }

        public virtual ActionResult AboutTabOne()
        {
            return PartialView();
        }

        public virtual ActionResult AboutTabTwo()
        {
            return PartialView();
        }


    }
}
