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
    
    public partial class InventoryListView
    {
        public int BookID { get; set; }
        public decimal ISBN { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public string PublisherName { get; set; }
        public string CategoryName { get; set; }
        public Nullable<decimal> BookPrice { get; set; }
        public decimal QuantityOnHand { get; set; }
        public decimal CopyrightDate { get; set; }
        public decimal Cost { get; set; }
    }
}
