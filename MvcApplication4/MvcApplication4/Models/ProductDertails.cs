using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Web;

namespace MvcApplication4.Models
{
    public class ProductDertails
    {
        [Key]
        public int productSerialNum { get; set; }
        public int productId { get; set; }
        public int expieryDate { get; set; }
        public string size { get; set; }
        public string color { get; set; }
        public int sellerId { get; set; }
        public DateTime manufactureDate { get; set; }
    }
}