using schedule.com.Models.sessions;
using schedule.data.businessObject;
using schedule.data.enums;
using schedule.data.erps.systems;
using schedule.data.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers.Base
{
    public class BaseController : Controller
    {
        protected SessionProvider sessionProvider;
        private int _page;
        private int _pagesize;
        public BaseController()
        {
            this.sessionProvider = new SessionProvider();
            sessionProvider.ModuleId = "9";
            sessionProvider.ModuleCode = "GSQLHT";
            LoadMainMenu();
        }

        protected virtual void LoadMainMenu()
        {
            using (data.erps.systems.SYS_GROUPSYSTEM sys_groupsystem = new data.erps.systems.SYS_GROUPSYSTEM())
            {
                var groupModules = sys_groupsystem.GetAll();
                ViewData["groupModules"] = groupModules;
            }
            MenuProvider menuProvider = new MenuProvider();
            
            List<SYS_SUBSYSTEM> da = new List<SYS_SUBSYSTEM>();
            for (int i = 0; i < 10000; i++)
            {
                SYS_SUBSYSTEM d = new SYS_SUBSYSTEM { SubSystemID = i };
                Random random = new Random();
                if (i < 50) d.ParentID = null;
                else d.ParentID = random.Next(0, 50).ToString();
                da.Add(d);
            }
            //theo foreach
            DateTime date1 = DateTime.Now;
            IEnumerable<data.erpExtensions.SYS_SUBSYSTEM_EXTEND> menus= menuProvider.GetMainMenu(da);
            var count = DateTime.Now - date1;
            //theo chấm
            DateTime date2 = DateTime.Now;
            IEnumerable<data.erpExtensions.SYS_SUBSYSTEM_EXTEND> menus2 = menuProvider.GetMainMenu2(da);
            var count2 = DateTime.Now - date2;
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

        protected void GetMessageFromSqlState(data.enums.SqlResultType resultType,string key="")
        {
            switch (resultType)
            {
                case data.enums.SqlResultType.Existed:
                    ModelState.AddModelError("error",string.Format("{0} đã tồn tại trong hệ thống.", key));
                    break;
                case data.enums.SqlResultType.NotExisted:
                    ModelState.AddModelError("error", string.Format("{0} không tồn tại trong hệ thống.", key));
                    break;
                case data.enums.SqlResultType.OK:
                    break;
                case data.enums.SqlResultType.Failed:
                    ModelState.AddModelError("error", string.Format("Có lỗi xảy ra.Thử lại sau.", key));
                    break;
                case data.enums.SqlResultType.Exception:
                    ModelState.AddModelError("error", string.Format("Lỗi hệ thống, xin hãy thử lại.", key));
                    break;
                case data.enums.SqlResultType.None:
                    break;
                default:
                    break;
            }
        }

        protected void HanderException(Exception exception)
        {
            ModelState.AddModelError("error", string.Format("Có lỗi xảy ra. {0}", exception.Message));
            TempData["systemerror"] = exception.Message;
        }

        protected void ShowNotification(MessageObjectType type, string title,string message)
        {
            TempData["notify"] = new MessageObject { type= type, title = title, message = message };
        }
        protected void ShowNotification(SqlResultType type, string title, string message)
        {
            MessageObjectType objectType = MessageObjectType.Info;
            switch (type)
            {
                case SqlResultType.Existed:
                    objectType = MessageObjectType.Warning;
                    break;
                case SqlResultType.NotExisted:
                    objectType = MessageObjectType.Warning;
                    break;
                case SqlResultType.OK:
                    objectType = MessageObjectType.Success;
                    break;
                case SqlResultType.Failed:
                    objectType = MessageObjectType.Error;
                    break;
                case SqlResultType.Exception:
                    objectType = MessageObjectType.Error;
                    break;
                case SqlResultType.None:
                    break;
                default:
                    break;
            }
            TempData["notify"] = new MessageObject { type = objectType, title = title, message = message };
        }

        protected void ShowMessage(MessageObjectType type, string title, string message)
        {
            TempData["messagebox"] = new MessageObject { type = type, title = title, message = message };
        }
    }
}