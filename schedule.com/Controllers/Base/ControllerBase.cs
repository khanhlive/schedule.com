using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers.Base
{
    public class BaseController : Controller
    {
        private int _page;
        private int _pagesize;
        public BaseController()
        {
        }

        protected void SetPage(int page)
        {
            this._page = page;
            ViewBag.page = this._page;
        }
        protected void SetPageSize(int pagesize)
        {
            this._pagesize = pagesize;
            ViewBag.pagesize = this._pagesize;
        }
        protected void SetPageInfo(int page,int pagesize)
        {
            this._page = page;
            this._pagesize = pagesize;
            ViewBag.page = this._page;
            ViewBag.pagesize = this._pagesize;
        }
    }
}