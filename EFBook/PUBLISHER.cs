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
    
    public partial class PUBLISHER
    {
        public PUBLISHER()
        {
            this.BOOKS = new HashSet<BOOK>();
            this.CONTACTs = new HashSet<CONTACT>();
            this.PUB_ADDRESS = new HashSet<PUB_ADDRESS>();
        }
    
        public int Publisher_ID { get; set; }
        public string Publisher_Name { get; set; }
    
        public virtual ICollection<BOOK> BOOKS { get; set; }
        public virtual ICollection<CONTACT> CONTACTs { get; set; }
        public virtual ICollection<PUB_ADDRESS> PUB_ADDRESS { get; set; }
    }
}