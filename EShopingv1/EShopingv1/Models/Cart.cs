using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("product")]
        public int productId { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        public int quantity { get; set; }
        public Product product { get; set; }
        public User user { get; set; }
    }
}