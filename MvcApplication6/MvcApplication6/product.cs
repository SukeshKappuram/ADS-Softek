//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication6
{
    using System;
    using System.Collections.Generic;
    
    public partial class product
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string manufactureName { get; set; }
        public string description { get; set; }
        public byte[] productImg { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> categoryId { get; set; }
    
        public virtual Category Category { get; set; }
    }
}