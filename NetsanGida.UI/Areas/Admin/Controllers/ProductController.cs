using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NetsanGida.Bll;
using NetsanGida.Dal;
using NetsanGida.Model;
using NetsanGida.Ui.Models;

namespace NetsanGida.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/Product
        public ActionResult List()
        {
            var list = bProduct.GetAll();
            return View(list);
        }

        // GET: Admin/Product/Create
        public ActionResult Add()
        {
            return View();
        }

        // POST: Admin/Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Add([Bind(Include = "ProductId,Name,Description,Media,Url,Price,TotalPrice,VAT,Brand,Model,Stock,CategoryId,IsActive,CreateDate,UpdateDate,DeleteDate")] Product product)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bProduct.Add(product);
                retVal.isSuccess = true;
                retVal.message = "Ekleme başarılı.";
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                retVal.isSuccess = true;
                retVal.message = ex.Message;
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Update(int? id)
        {
            var data = bProduct.GetById(id.Value);
            return View(data);
        }

        // POST: Admin/Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Update([Bind(Include = "ProductId,Name,Description,Media,Url,Price,TotalPrice,VAT,Brand,Model,Stock,CategoryId,IsActive,CreateDate,UpdateDate,DeleteDate")] Product product)
        {
            ReturnValue retVal = new ReturnValue();
            try
            {
                bProduct.Update(product);
                retVal.isSuccess = true;
                retVal.message = "Güncelleme başarılı.";
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                retVal.isSuccess = true;
                retVal.message = ex.Message;
                return Json(retVal, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Admin/Product/Delete/5
        public JsonResult Delete(int? id)
        {
            bProduct.Delete(id.Value);
            return Json(true, JsonRequestBehavior.AllowGet);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
