using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetsanGida.Model
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string NameSurname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsApprove { get; set; } = false;
        public int Score { get; set; }
        public string Mail { get; set; }
        public int Phone { get; set; }
        public int? ProductId { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
