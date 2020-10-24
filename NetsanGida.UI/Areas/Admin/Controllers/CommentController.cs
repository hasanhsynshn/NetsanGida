using NetsanGida.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        public ActionResult List()
        {
            var list = bComment.GetAll();
            return View(list);
        }

        public ActionResult GetComment(int commentId)
        {
            var data = bComment.GetById(commentId);
            return View(data);
        }

        public ActionResult ApproveComment(int id)
        {
            bComment.AddApprove(id);
            return RedirectToAction(nameof(List));
        }

        public ActionResult RemoveApproveComment(int id)
        {
            bComment.RemoveApprove(id);
            return RedirectToAction(nameof(List));
        }

        public JsonResult Delete(int id)
        {
            bComment.Delete(id);
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}