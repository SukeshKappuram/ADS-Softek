using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EshoppingV2._0.Models
{
    public class Seller : ApplicationUser
    {
        public string OutletName { get; set; }
    }
}