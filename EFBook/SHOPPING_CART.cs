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
    
    public partial class SHOPPING_CART
    {
        public SHOPPING_CART()
        {
            this.INVOICEs = new HashSet<INVOICE>();
        }
    
        public int Record_ID { get; set; }
        public string Cart_ID { get; set; }
        public int Quantity { get; set; }
        public string CartStatus { get; set; }
        public int BookID { get; set; }
        public int CID { get; set; }
    
        public virtual BOOK BOOK { get; set; }
        public virtual CUSTOMER1 CUSTOMER { get; set; }
        public virtual ICollection<INVOICE> INVOICEs { get; set; }
    }
}
