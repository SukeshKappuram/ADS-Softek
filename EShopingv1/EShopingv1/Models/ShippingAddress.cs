using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class ShippingAddress
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(100)]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string State { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string Pincode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string PhoneNumber { get; set; }
        [ForeignKey("user")]
        [Display(Name="User")]
        public int UserId { get; set; }
        public User user { get; set; }
    }
}