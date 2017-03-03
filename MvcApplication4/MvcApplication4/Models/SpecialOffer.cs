using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class SpecialOffer
    {
        public int Id { get; set; }
        public string description { get; set; }
        public float Discount { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int minQuantity { get; set; }
        public int maxQuantity { get; set; }
    }
}