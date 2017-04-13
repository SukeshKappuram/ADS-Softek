using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EshoppingV2._0.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public Guid userId { get; set; }

        public virtual List<CartItem> cartItems { get; set; }

    }
}