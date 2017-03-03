using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public int productId {get; set;}
    }
}