using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Web;

namespace EshoppingV2._0.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Please enter the Name of the Product")]
        [RegularExpression(@"[A-Za-z]{4,}")]
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
        [RegularExpression(@"^[a-zA-Z\s]*$")]
        [StringLength(30)]
        public string manufactureName { get; set; }
        [ForeignKey("Category")]
        [Display(Name="Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } //No coulum

        public virtual List<ProductDetails> productDetails { get; set; }
    }
}