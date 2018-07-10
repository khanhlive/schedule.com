using schedule.data.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using schedule.com.Controllers.Base;

namespace schedule.com.Controllers
{
    public class thoikhoabieuController : BaseController
    {
        // GET: thoikhoabieu
        public ActionResult Index()
        {
            GiaoVien giaoVien = new GiaoVien();
            return View(giaoVien.GetList().ToPagedList(1,30));
        }
    }
}