using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFBook.Models;
using EFBook.ViewModels;

namespace EFBook.Controllers
{
    public class ShoppingCartController : Controller
    {
        private jnolanEntities6 db = new jnolanEntities6();

        //
        // GET: /ShoppingCart/

        public ActionResult Index()
        {
            var cart = Cart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);

            //  return View(db.SHOPPING_CART.ToList());
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int BookId)
        {
            // Retrieve the books from the database
            var addedBook = db.BOOKS
                .Single(book => book.BookID == BookId);

            // Add it to the shopping cart
            var cart = Cart.GetCart(this.HttpContext);


            cart.AddToCart(addedBook);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        //
        // AJAX: /ShoppingCart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = Cart.GetCart(this.HttpContext);

            // Get the name of the album to display confirmation
            // -----------------the Record_ID to damn cart table!!!!!!!!!!!!!!!!!!!!!
            var bookName = db.SHOPPING_CART
                .Single(item => item.Record_ID == id).BOOK.Title;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(bookName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        //
        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = Cart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}


//         // GET: /ShoppingCart/Details/5

//        public ActionResult Details(int id = 0)
//        {
//            SHOPPING_CART shopping_cart = db.SHOPPING_CART.Find(id);
//            if (shopping_cart == null)
//            {
//                return HttpNotFound();
//            }
//            return View(shopping_cart);
//        }

//        //
//        // GET: /ShoppingCart/Create

//        public ActionResult Create()
//        {
//            return View();
//        }

//        //
//        // POST: /ShoppingCart/Create

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(SHOPPING_CART shopping_cart)
//        {
//            if (ModelState.IsValid)
//            {
//                db.SHOPPING_CART.Add(shopping_cart);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(shopping_cart);
//        }

//        //
//        // GET: /ShoppingCart/Edit/5

//        public ActionResult Edit(int id = 0)
//        {
//            SHOPPING_CART shopping_cart = db.SHOPPING_CART.Find(id);
//            if (shopping_cart == null)
//            {
//                return HttpNotFound();
//            }
//            return View(shopping_cart);
//        }

//        //
//        // POST: /ShoppingCart/Edit/5

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit(SHOPPING_CART shopping_cart)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(shopping_cart).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(shopping_cart);
//        }

//        //
//        // GET: /ShoppingCart/Delete/5

//        public ActionResult Delete(int id = 0)
//        {
//            SHOPPING_CART shopping_cart = db.SHOPPING_CART.Find(id);
//            if (shopping_cart == null)
//            {
//                return HttpNotFound();
//            }
//            return View(shopping_cart);
//        }

//        //
//        // POST: /ShoppingCart/Delete/5

//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            SHOPPING_CART shopping_cart = db.SHOPPING_CART.Find(id);
//            db.SHOPPING_CART.Remove(shopping_cart);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            db.Dispose();
//            base.Dispose(disposing);
//        }
//    }
//}