using NetsanGida.Bll;
using NetsanGida.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Controllers
{
    public class CommentController : Controller
    {
        [HttpPost]
        public JsonResult Add(Comment model)
        {
            if (string.IsNullOrEmpty(model.Description) || string.IsNullOrEmpty(model.Title) || string.IsNullOrEmpty(model.Mail) || string.IsNullOrEmpty(model.NameSurname))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                bComment.Add(model);
                return Json(true, JsonRequestBehavior.AllowGet);
            }          
        }
    }
}