using NetsanGida.Bll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetsanGida.UI.Controllers
{
    public class ProductController : Controller
    {
        [Route("urun/{urunUrl}")]
        public ActionResult Detail(string urunUrl)
        {
            var data = bProduct.GetByUrl(urunUrl);
            return View(data);
        }

        [Route("urunler/{kategoriUrl}")]
        public ActionResult GetProducts(string kategoriUrl)
        {
            var list = bProduct.GetByCategoryUrl(kategoriUrl);
            return View(list);
        }
    }
}