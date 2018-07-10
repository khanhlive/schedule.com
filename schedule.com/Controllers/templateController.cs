using schedule.com.Controllers.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace schedule.com.Controllers
{
    public class templateController : BaseController
    {
        // GET: template
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Error(int? status)
        {
            ViewBag.StatusCode = status;
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult PanelAndWells()
        {
            return View();
        }
        public ActionResult Buttons()
        {
            return View();
        }
        public ActionResult Alert()
        {
            return View();
        }
        public ActionResult Modal()
        {
            return View();
        }
        public ActionResult ProgressBars()
        {
            return View();
        }
        public ActionResult Notifications()
        {
            return View();
        }
        public ActionResult ListAndMediaObject()
        {
            return View();
        }
        public ActionResult FormBasic()
        {
            return View();
        }
        public ActionResult FormLayout()
        {
            return View();
        }
        public ActionResult FormAddon()
        {
            return View();
        }
        public ActionResult FormMaterial()
        {
            return View();
        }
        public ActionResult FormFloatInput()
        {
            return View();
        }
        public ActionResult FileUpload()
        {
            return View();
        }
        public ActionResult FormMask()
        {
            return View();
        }
        public ActionResult FormValidation()
        {
            return View();
        }
        public ActionResult FormDropZone()
        {
            return View();
        }
        public ActionResult FormPicker()
        {
            return View();
        }
        public ActionResult FormWizards()
        {
            return View();
        }
        public ActionResult Typehead()
        {
            return View();
        }
        public ActionResult XeditTable()
        {
            return View();
        }
        public ActionResult TableBasic()
        {
            return View();
        }
        public ActionResult TableLayout()
        {
            return View();
        }
        public ActionResult Datatable()
        {
            return View();
        }
        public ActionResult bootstraptable()
        {
            return View();
        }
        public ActionResult responsiveTable()
        {
            return View();
        }
        public ActionResult Edittable()
        {
            return View();
        }
        public ActionResult Footable()
        {
            return View();
        }
        public ActionResult JsGrid()
        {
            return View();
        }
        public ActionResult Treeview()
        {
            return View();
        }

    }
}