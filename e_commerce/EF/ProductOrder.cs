//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace e_commerce.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductOrder
    {
        public int id { get; set; }
        public int pid { get; set; }
        public int oid { get; set; }
        public int qty { get; set; }
    
        public virtual Order Order { get; set; }
        public virtual product product { get; set; }
    }
}
