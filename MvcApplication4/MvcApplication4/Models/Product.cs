using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public byte img { get; set; }
        public int categoryId { get; set; }
        public string manufactureName { get; set; }
    }
}