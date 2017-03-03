using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class OrderDetails
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int quantity { get; set; }
        public long trackingNumber { get; set; }
        public int specialOfferId { get; set; }
    }
}