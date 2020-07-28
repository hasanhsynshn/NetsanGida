using NetsanGida.Bll.Helpers;
using NetsanGida.Dal;
using NetsanGida.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetsanGida.Bll
{
    public static class bCategory
    {
        public static List<Category> GetAll()
        {
            var list = new List<Category>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Categories.Where(x => x.IsActive == false).ToList();
            }
            return list;
        }

        public static List<Category> GetAllSubCategories()
        {
            var list = new List<Category>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Categories.Where(x => x.IsActive == false && x.ParentId == 0).ToList();
            }
            return list;
        }

        public static Category GetById(int id)
        {
            var data = new Category();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            }
            return data;
        }

        public static Category GetByParentId(int id)
        {
            var data = new Category();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            }
            return data;
        }

        public static Category Add(Category model)
        {
            if (model.ParentId == null)
            {
                model.ParentId = 0;
            }
            model.CreateDate = DateTime.Now;
            model.Url = Tool.CreateUrlSlug(model.Name);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Categories.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Category Update(Category model)
        {
            if (model.ParentId == null)
            {
                model.ParentId = 0;
            }
            model.UpdateDate = DateTime.Now;
            if (model.Url == null)
            {
                model.Url = Tool.CreateUrlSlug(model.Name);
            }
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
                var data = db.Categories.Find(id);
                data.IsActive = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
