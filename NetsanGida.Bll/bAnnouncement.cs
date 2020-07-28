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
    public static class bAnnouncement
    {
        public static List<Announcement> GetAll()
        {
            var list = new List<Announcement>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                list = db.Announcements.Where(x => x.IsActive == false).ToList();
            }
            return list;
        }

        public static Announcement GetById(int id)
        {
            var data = new Announcement();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                data = db.Announcements.FirstOrDefault(x => x.AnnouncementId == id);
            }
            return data;
        }

        public static Announcement Add(Announcement model)
        {
            model.CreateDate = DateTime.Now;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Announcements.Add(model);
                db.SaveChanges();
            }
            return model;
        }

        public static Announcement Update(Announcement model)
        {
            model.UpdateDate = DateTime.Now;
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
                var data = db.Announcements.Find(id);
                data.IsActive = true;
                data.DeleteDate = DateTime.Now;
                db.SaveChanges();
            }
        }
    }
}
