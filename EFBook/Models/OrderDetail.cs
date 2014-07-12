using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EFBook.Models
{
    public class OrderDetail
    {
        protected virtual void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>();
        }
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int BookID { get; set; }
        public int Quantity { get; set; }
        public decimal? UnitPrice { get; set; }
        public virtual BOOK Book { get; set; }
        public virtual Order Order { get; set; }
    }
}