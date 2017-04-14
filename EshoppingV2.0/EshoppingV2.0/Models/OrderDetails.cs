using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EshoppingV2._0.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("order")]
        public Guid orderId { get; set; }
        [ForeignKey("product")]
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public Guid trackingNumber { get; set; }
        [ForeignKey("specialOffer")]
        public int specialOfferId { get; set; }
        public SalesOrder order { get; set; }
        public ProductDetails product { get; set; }
        public SpecialOffer specialOffer { get; set; }

    }
}