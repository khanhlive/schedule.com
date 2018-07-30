using PagedList;
using schedule.com.Controllers.Base;
using schedule.data.erps.dictionary;
using System.Web.Mvc;

namespace schedule.com.Controllers
{
    public class dantocController : BaseController
    {
        public dantocController() : base()
        {
            this.SetModuleCode("DANHMUCDANTOC");
        }
        // GET: dantoc
        public ActionResult Index(int page=1,int pagesize=20)
        {
            this.SetPageInfo(page, pagesize);
            using (DIC_DANTOC dic_dantoc=new DIC_DANTOC())
            {
                var dantocs = dic_dantoc.GetAll().ToPagedList(page, pagesize);
                return View(dantocs);
            }
        }
    }
}