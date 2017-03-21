using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class SpecialOffer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(20,MinimumLength=5)]
        [Display(Name="Offer Name")]
        public string OfferName { get; set; }
        [Required]
        [Range(1,100)]
        public float Discount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name="Start Date")]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
        [Required]
        [Range(1,10)]
        [Display(Name = "Min Quantity")]
        public int MaxQuantity { get; set; }
        [Required]
        [Range(1, 20)]
        [Display(Name = "Max Quantity")]
        public int MinQuantity { get; set; }
    }
}