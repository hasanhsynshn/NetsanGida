using NetsanGida.Bll;
using NetsanGida.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult List()
        {
            var list = bProduct.GetAll();
            return View(list);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product model)
        {
            try
            {
                bProduct.Add(model);
                return RedirectToAction(nameof(List));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Update(int id)
        {
            var data = bProduct.GetById(id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Product model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bProduct.Update(model);
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
            bProduct.Delete(id);
            return View(nameof(List));
        }
    }
}