using NetsanGida.Bll.Helpers;
using NetsanGida.Dal;
using NetsanGida.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;


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
                data = db.Products.FirstOrDefault(x => x.ProductId == id);
            }
            return data;
        }

        public static Product GetByUrl(string urunUrl)
        {
            var data = new Product();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Products.FirstOrDefault(x => x.Url == urunUrl);
            }
            return data;
        }

        public static List<Product> GetByCategoryId(int categoryId)
        {
            var list = new List<Product>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Products.Where(x => x.CategoryId == categoryId && x.IsActive == false).ToList();
            }
            return list;
        }

        public static Category GetByCatUrl(string kategoriUrl)
        {
            var data = new Category();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Categories.FirstOrDefault(x => x.Url == kategoriUrl);
            }
            return data;
        }

        public static List<Product> GetByCategoryUrl(string kategoriUrl)
        {
            var list = new List<Product>();
            var data = GetByCatUrl(kategoriUrl);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Products.Where(x => x.CategoryId == data.CategoryId && x.IsActive == false).ToList();
            }
            return list;
        }

        public static List<Product> GetByCategoryName(string categoryName)
        {
            var list = new List<Product>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Products.Where(x => x.Name == categoryName && x.IsActive == false).ToList();
            }
            return list;
        }

        public static List<Product> GetByProductMunzur()
        {
            var list = new List<Product>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Products.Where(x => x.CategoryId == 8).ToList();
            }
            return list;
        }

        public static Product Add(Product model)
        {
            model.CreateDate = DateTime.Now;
            model.Url = Tool.CreateUrlSlug(model.Name);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Products.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Product Update(Product model)
        {
            model.CreateDate = DateTime.Now;
            model.Url = Tool.CreateUrlSlug(model.Name);
            using (ApplicationDbContext db = new ApplicationDbContext())
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
                db.SaveChanges();
            }
        }
    }
}
