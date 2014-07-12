using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFBook.Models
{
    public class Cart
    {
        jnolanEntities6 db = new jnolanEntities6();
        string ShoppingCartId { get; set; }
        public const string CartSessionKey = "CartId";
        public static Cart GetCart(HttpContextBase context)
        {
            var cart = new Cart();
            cart.ShoppingCartId = cart.GetCartId(context);
            return cart;
        }
        // Helper method to simplify shopping cart calls
        public static Cart GetCart(Controller controller)
        {
            return GetCart(controller.HttpContext);
        }
        public void AddToCart(BOOK book)
        {
            // Get the matching cart and album instances
            var cartItem = db.SHOPPING_CART.SingleOrDefault(
                c => c.Cart_ID == ShoppingCartId
                && c.BookID == book.BookID);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new SHOPPING_CART
                {
                    BookID = book.BookID,
                    Cart_ID = ShoppingCartId,
                    Quantity = 1,
                    CID = 1
                };
                db.SHOPPING_CART.Add(cartItem);
            }
            else
            {
                // If the item does exist in the cart, 
                // then add one to the quantity
                cartItem.Quantity++;
            }
            // Save changes
            db.SaveChanges();
        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = db.SHOPPING_CART.Single(
                cart => cart.Cart_ID == ShoppingCartId
                && cart.Record_ID == id);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;

                    //------------------------------reason i cant remove from cart
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    db.SHOPPING_CART.Remove(cartItem);
                }
                // Save changes
                db.SaveChanges();
            }
            return itemCount;
        }
        public void EmptyCart()
        {
            var cartItems = db.SHOPPING_CART.Where(
                cart => cart.Cart_ID == ShoppingCartId);

            foreach (var cartItem in cartItems)
            {
                db.SHOPPING_CART.Remove(cartItem);
            }
            // Save changes
            db.SaveChanges();
        }
        public List<SHOPPING_CART> GetCartItems()
        {
            return db.SHOPPING_CART.Where(
                cart => cart.Cart_ID == ShoppingCartId).ToList();
        }
        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in db.SHOPPING_CART
                          where cartItems.Cart_ID == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            decimal? total = (from cartItems in db.SHOPPING_CART
                              where cartItems.Cart_ID == ShoppingCartId
                              select (int?)cartItems.Quantity *
                              cartItems.BOOK.Price).Sum();

            return total ?? decimal.Zero;
        }
        public int CreateOrder(ORDERR order)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                var orderDetail = new ORDER_DETAIL
                {
                    BookID = item.BookID,
                    Order_ID = order.Order_ID,
                    UnitPrice = item.BOOK.Price,
                    Quantity = item.Quantity
                };
                // Set the order total of the shopping cart
                //orderTotal += (item.Quantity * item.BOOK.Price);

                db.ORDER_DETAIL.Add(orderDetail);

            }
            // Set the order's total to the orderTotal count
            order.UnitPrice = orderTotal;

            // Save the order
            db.SaveChanges();
            // Empty the shopping cart
            EmptyCart();
            // Return the OrderId as the confirmation number
            return order.Order_ID;
        }
        // We're using HttpContextBase to allow access to cookies.
        public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }
        // When a user has logged in, migrate their shopping cart to
        // be associated with their username
        public void MigrateCart(string userName)
        {
            var shoppingCart = db.SHOPPING_CART.Where(
                c => c.Cart_ID == ShoppingCartId);

            foreach (SHOPPING_CART item in shoppingCart)
            {
                item.Cart_ID = userName;
            }
            db.SaveChanges();
        }


    }
}