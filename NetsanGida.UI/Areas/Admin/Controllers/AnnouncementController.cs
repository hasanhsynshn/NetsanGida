using NetsanGida.Bll;
using NetsanGida.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Areas.Admin.Controllers
{
    public class AnnouncementController : Controller
    {
        // GET: Admin/Announcement
        public ActionResult List()
        {
            var list = bAnnouncement.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Announcement model)
        {
            try
            {
                bAnnouncement.Add(model);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {

                throw;
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
            try
            {
                if (ModelState.IsValid)
                {
                    bAnnouncement.Update(model);
                    return RedirectToAction(nameof(List));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            bAnnouncement.Delete(id);
            return View(nameof(List));
        }
    }
}