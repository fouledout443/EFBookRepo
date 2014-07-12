using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFBook.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<SHOPPING_CART> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}