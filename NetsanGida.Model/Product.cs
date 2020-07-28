using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace NetsanGida.Model
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Media { get; set; }
        public string Url { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
        public double VAT { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Stock { get; set; }
        public int? CategoryId { get; set; }
        public bool IsActive { get; set; } = false;
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
