using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EshoppingV2._0.Models
{
    public class ProductDetails
    {
        [Key]
        [Required]
        [Display(Name="Serial Number")]
        public Guid SerialNumber { get; set; }
        [Display(Name = "Product")]
        [ForeignKey("product")]
        public int ProductId { get; set; }
        [Required]
        [Display(Name="Expiery Date")]
        [DataType(DataType.Date)]
        public DateTime ExpieryDate { get; set; }
        [Required]
        [Display(Name = "Manufacture Date")]
        [DataType(DataType.Date)]
        public DateTime ManufactureDate { get; set; }
        [Required]
        [StringLength(10)]
        public string Size { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Color { get; set; }
        [Display(Name = "Seller")]
        [ForeignKey("seller")]
        public int sellerId { get; set; }
        [Required]
        [Display(Name="Seller Price")]
        [DataType(DataType.Currency)]
        public float sellingPrice { get; set; }
        public Product product { get; set; }
        public ApplicationUser seller { get; set; }
    }
}