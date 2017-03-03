using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int shippingId { get; set; }
        public float totalCost { get; set; }
        public float orderCost { get; set; }
        public float shippingCost { get; set; }
        public string status { get; set; }
        public DateTime orderDate { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime shippingDate { get; set; }
        public DateTime deliveryDate { get; set; }
    }
}