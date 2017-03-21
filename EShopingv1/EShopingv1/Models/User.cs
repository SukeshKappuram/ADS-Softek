using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class User
    {
        public int Id{ get; set; }
        [Required]
        [StringLength(20,MinimumLength=4)]
        [Display(Name="First Name")]
        public string firstName { get; set; }
        [StringLength(20)]
        [Display(Name = "Middle Name")]
        public string middleName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 4)]
        [Display(Name = "Last Name")]
        public string lastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Mail Id")]
        public string mailId { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile Number")]
        public string phoneNumber { get; set; }

        public virtual List<Role> Roles { get; set; }

    }
}