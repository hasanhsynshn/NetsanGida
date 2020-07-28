using NetsanGida.Bll.Helpers;
using NetsanGida.Dal;
using NetsanGida.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NetsanGida.Bll
{
    public static class bProduct
    {
        public static List<Product> GetAll()
        {
            var list = new List<Product>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Products.Where(x => x.IsActive == false).ToList();
            }
            return list;
        }
        public static Product GetById(int id)
        {
            var data = new Product();
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                data = db.Products.Where(x => x.ProductId == id).FirstOrDefault();
            }
            return data;
        }
        public static Product Add(Product model)
        {
            model.CreateDate = DateTime.Now;
            model.Url = Tool.CreateUrlSlug(model.Name);
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                db.Entry(model).State = EntityState.Added;
                db.SaveChanges();
            }
            return model;
        }
        public static Product Update(Product model)
        {
            model.UpdateDate = DateTime.Now;
            if (model.Url == null)
            {
                model.Url = Tool.CreateUrlSlug(model.Name);
            }            
            using (ApplicationDbContext db=new ApplicationDbContext())
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
            }
            return model;
        }
        public static void Delete(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext()) 
            {
                var data = db.Products.Find(id);
                data.IsActive = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }

    }
}
