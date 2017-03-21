using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("user")] 
        [Display(Name="Role")]
        public int userId { get; set; }
        [Required]
        [Display(Name = "Role Name")]
        public string roleName { get; set; }
        public User user { get; set; }
    }
}