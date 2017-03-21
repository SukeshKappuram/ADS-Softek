using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EShopingv1.Models
{
    public class Seller:User
    {
        [Display(Name="Òutlet Name")]
        public string OutletName { get; set; }
    }
}