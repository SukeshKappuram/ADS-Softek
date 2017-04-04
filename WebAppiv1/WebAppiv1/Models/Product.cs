using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebAppiv1.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter the Name of the Product")]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [Range(50,80000)]
        [DataType(DataType.Currency)]
        public float Price { get; set; }
        [Required]
        [Display(Name="Manufacture Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$")]
        [StringLength(30)]
        public string manufactureName { get; set; }
        
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
    }

    public class ProductDB : DbContext
    {
        public ProductDB() : base("name=EShopingv2Context")
        {
        }
        public DbSet<Product> products { get; set; }
    }
}