using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        public string location { get; set; }
        public string state { get; set; }
        public string pincode { get; set; }
        public int userId { get; set; }
        public string phoneNumber { get; set; }
    }
}