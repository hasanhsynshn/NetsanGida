using NetsanGida.Bll;
using NetsanGida.Model;
using NetsanGida.Ui.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class AnnouncementController : Controller
    {
        // GET: Admin/Announcement
        public ActionResult List()
        {
            var data = bAnnouncement.GetAll();
            return View(data);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Announcement model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bAnnouncement.Add(model);
                retVal.isSuccess = true;
                retVal.message = "Ekleme başarılı.";
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                retVal.isSuccess = false;
                retVal.message = ex.Message;
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult Update(int id)
        {
            var data = bAnnouncement.GetById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Announcement model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bAnnouncement.Update(model);
                retVal.isSuccess = true;
                retVal.message = "Güncelleme başarılı.";
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                retVal.isSuccess = false;
                retVal.message = ex.Message;
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Delete(int id)
        {
            bAnnouncement.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}