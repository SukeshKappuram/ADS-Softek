using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Role
    {
        public int roleId { get; set; }
        public string roleName { get; set; }
        public int userId { get; set; }
    }
}