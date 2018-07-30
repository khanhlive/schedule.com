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
    public class QuanHuyenController : BaseController
    {
        public QuanHuyenController() : base()
        {
            this.SetModuleCode("DANHMUCQUANHUYEN");
        }
        // GET: QuanHuyen
        public ActionResult Index(string text, string matinh, string cap, bool status = true, int page = 1, int pagesize = 20)
        {
            this.SetPageInfo(page, pagesize);
            ViewBag.text = text;
            ViewBag.cap = cap;
            ViewBag.status = status;
            ViewBag.matinh = matinh;
            using (DIC_HUYEN dic_huyen = new DIC_HUYEN())
            {
                string _cap = dic_huyen.GetCapById(cap);
                var dic_huyens = dic_huyen.GetFilter(text, CheckString(_cap) ? null : _cap, status ? "1" : "0", matinh == null ? null : matinh.Equals("0") ? null : matinh).ToPagedList(page, pagesize);
                return View(dic_huyens);
            }
        }
    }
}