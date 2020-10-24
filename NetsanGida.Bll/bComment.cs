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
    public static class bComment
    {
        public static List<Comment> GetAll()
        {
            var list = new List<Comment>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Comments.Where(x => x.IsActive == false).ToList();
            }
            return list;
        }

        public static List<Comment> GetAllApproves(int productId)
        {
            var list = new List<Comment>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Comments.Where(x => x.IsActive == false && x.ProductId == productId && x.IsApprove == true).ToList();
            }
            return list;
        }

        public static Comment GetById(int id)
        {
            var data = new Comment();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Comments.Where(x => x.CommentId == id).FirstOrDefault();
            }
            return data;
        }
        public static Comment Add(Comment model)
        {
            model.CreateDate = DateTime.Now;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(model).State = EntityState.Added;
                db.SaveChanges();
            }
            return model;
        }
        public static void Delete(int id)
        {
            using (ApplicationDbContext db=new ApplicationDbContext())
            {
                var data = db.Comments.Find(id);
                data.IsActive = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
        public static void AddApprove(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var data = db.Comments.Find(id);
                data.IsApprove = true;
                db.SaveChanges();
            }
        }

        public static void RemoveApprove(int id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var data = db.Comments.Find(id);
                data.IsApprove = false;
                db.SaveChanges();
            }
        }
    }
}