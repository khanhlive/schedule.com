using schedule.com.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController() : base()
        {
            this.SetModuleCode("");
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        [HttpPost]
        public ActionResult ChangeModule(int moduleid)
        {
            this.SetModuleID(moduleid);
            return RedirectToAction("Index");
        }
    }
}
