using PagedList;
using schedule.com.Controllers.Base;
using schedule.data.erps.dictionary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers.Dictionary
{
    public class tinhthanhController : BaseController
    {
        // GET: tinhthanh
        public ActionResult Index(int page = 1, int pagesize = 20)
        {
            this.SetPageInfo(page, pagesize);
            using (DIC_TINH dic_tinhthanh= new DIC_TINH())
            {
                var dic_tinhthanhs = dic_tinhthanh.GetAll().ToPagedList(page, pagesize);
                return View(dic_tinhthanhs);
            }
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}