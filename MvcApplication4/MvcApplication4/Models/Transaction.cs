using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication4.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string payType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int orderId { get; set; }
        public int paymentId { get; set; }
    }
}