//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFBook
{
    using System;
    using System.Collections.Generic;
    
    public partial class CONTACT
    {
        public int Contact_ID { get; set; }
        public string LName { get; set; }
        public string FName { get; set; }
        public Nullable<decimal> Phone { get; set; }
        public string Email { get; set; }
        public int Publisher_ID { get; set; }
    
        public virtual PUBLISHER PUBLISHER { get; set; }
    }
}