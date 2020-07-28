using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetsanGida.Model
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
