using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EshoppingV2._0.Models
{
    public class CartItem
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("cart")]
        public int cartId { get; set; }
        [ForeignKey("product")]
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public Cart cart { get; set; }
        public ProductDetails product { get; set; }
    }
}