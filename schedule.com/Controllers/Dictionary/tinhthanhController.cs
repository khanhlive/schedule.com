using PagedList;
using schedule.com.Controllers.Base;
using schedule.data.erps.dictionary;
using schedule.data.helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers
{
    public class tinhthanhController : BaseController
    {
        public tinhthanhController() : base()
        {
            this.SetModuleCode("DANHMUCTINH");
        }
        // GET: tinhthanh
        public ActionResult Index(string text, string cap, bool status=true, int page = 1, int pagesize = 20)
        {
            this.SetPageInfo(page, pagesize);

            ViewBag.text = text;
            ViewBag.cap = cap;
            ViewBag.status = status;
            using (DIC_TINH dic_tinhthanh = new DIC_TINH())
            {
                string _cap = dic_tinhthanh.GetCapById(cap);
                var dic_tinhthanhs = dic_tinhthanh.GetFilter(text, _cap == "" ? null : _cap, status ? "1" : "0").ToPagedList(page, pagesize);
                return View(dic_tinhthanhs);
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DIC_TINH model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Cap = model.GetCapById(model.Cap);
                    var result = model.Insert();
                    if (result == data.enums.SqlResultType.OK)
                    {
                        this.ShowNotification(data.enums.MessageObjectType.Success, "", "Tạo mới tỉnh/thành thành công.");
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        this.GetMessageFromSqlState(result, "Mã tỉnh");
                        return View(model);
                    }
                }
                catch (Exception ex)
                {
                    this.HanderException(ex);
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpGet]
        public ActionResult Edit(string id = "")
        {
            using (DIC_TINH dic_tinh = new DIC_TINH())
            {
                return View(dic_tinh.Get(id));
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, DIC_TINH model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Cap = model.GetCapById(model.Cap);
                    var entityUpdate = model.Get(DataConverter.StringToInt(id));
                    if (entityUpdate != null)
                    {
                        entityUpdate.MaTinh = model.MaTinh;
                        entityUpdate.TenTinh = model.TenTinh;
                        entityUpdate.Cap = model.Cap;
                        entityUpdate.Status = model.Status;
                        var result = entityUpdate.Update();
                        if (result == data.enums.SqlResultType.OK)
                        {
                            this.ShowNotification(data.enums.MessageObjectType.Success, "", "Chỉnh sửa thành công.");
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            this.GetMessageFromSqlState(result, "Mã tỉnh");
                            return View(model);
                        }

                    }
                    else
                    {
                        this.GetMessageFromSqlState(data.enums.SqlResultType.NotExisted, "Mã tỉnh");
                        return View(model);
                    }

                }
                catch (Exception ex)
                {
                    this.HanderException(ex);
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            using (DIC_TINH dic_tinh = new DIC_TINH())
            {
                dic_tinh.MaTinh = id;
                var result = dic_tinh.Delete();
                if (result == data.enums.SqlResultType.OK)
                {
                    this.ShowNotification(data.enums.MessageObjectType.Success, "Xóa tỉnh thành", "Đã xóa thành công ");
                    return RedirectToAction("Index");
                }
                else
                {
                    this.ShowNotification(result, "Xóa tỉnh thành", "Không xóa được bản ghi này.");
                    return RedirectToAction("Index");
                }
            }
        }
        //[HttpDelete]
        //public JsonResult delete(string id)
        //{
        //    using (DIC_TINH dic_tinh = new DIC_TINH())
        //    {
        //        dic_tinh.MaTinh = id;
        //        var result = dic_tinh.Delete();
        //        if(result== data.enums.SqlResultType.OK)
        //        {
        //            return Json(result);
        //        }
        //        else
        //        {
        //            return Json(result);
        //        }
        //    }
        //}
    }
}