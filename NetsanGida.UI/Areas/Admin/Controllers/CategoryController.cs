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
    public class CategoryController : Controller
    {
        public ActionResult List()
        {
            var list = bCategory.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Add(Category model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                if (model.Name == null)
                {
                    retVal.isSuccess = false;
                    retVal.message = "İsim girilmesi zorunludur.";
                    return Json(retVal, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bCategory.Add(model);
                    retVal.isSuccess = true;
                    retVal.message = "Ekleme başarılı.";
                    return Json(retVal, JsonRequestBehavior.AllowGet);
                }                
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
            var data = bCategory.GetById(id);
            return View(data);
        }

        [HttpPost]
        public JsonResult Update(Category model)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                if (model.Name == null)
                {
                    retVal.isSuccess = false;
                    retVal.message = "İsim girilmesi zorunludur.";
                    return Json(retVal, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    bCategory.Update(model);
                    retVal.isSuccess = true;
                    retVal.message = "Güncelleme başarılı.";
                    return Json(retVal, JsonRequestBehavior.AllowGet);
                }                
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
            bCategory.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}