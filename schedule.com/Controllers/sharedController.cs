using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers
{
    public class sharedController : Controller
    {
        // GET: shared
        public PartialViewResult _NavbarHeader()
        {
            using (data.erps.systems.SYS_GROUPSYSTEM sys_groupsystem = new data.erps.systems.SYS_GROUPSYSTEM())
            {
                var groupModules = sys_groupsystem.GetAll();
                ViewData["groupModules"] = groupModules;
                return PartialView("~/Views/Shared/_NavbarHeader.cshtml");
            }
        }
        public PartialViewResult _LeftSidebar()
        {
            return PartialView("~/Views/Shared/_LeftSidebar.cshtml");
        }
    }
}