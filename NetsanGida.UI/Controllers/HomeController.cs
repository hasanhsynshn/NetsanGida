using NetsanGida.Bll.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("hakkinda")]
        public ActionResult About()
        {
            return View();
        }

        [Route("sss")]
        public ActionResult FAQ()
        {
            return View();
        }

        [Route("iletisim")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("duyuru")]
        public ActionResult Announcement()
        {
            return View();
        }

        [Route("galeri")]
        public ActionResult Gallery()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Contact(string namesurname, string email, string tel, string subject, string message)
        {
            var body = "Ad - Soyad: " + namesurname + "<br /> Email: " + email + "<br /> Telefon No: " + tel + "<br /> Konu: " + subject + "<br /> Mesaj: " + message;
            if (string.IsNullOrEmpty(namesurname) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(subject) || string.IsNullOrEmpty(message))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else if (!email.IsValidEmail())
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            else
            {
                EmailService.TransactionalEmail_WithSpecial(subject, body, EmailService.AppSetting("ContactForm_To"));
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }
    }
}