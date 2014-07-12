using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFBook.Models;

namespace EFBook.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        jnolanEntities6 db = new jnolanEntities6();
        const string PromoCode = "FREE";
        //
        // GET: /Checkout/

        public ActionResult AddressAndPayment()
        {
            return View();
        }

        //
        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {

            var order = new ORDERR();
            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode,
                    StringComparison.OrdinalIgnoreCase) == false)
                {
                    order.Username = User.Identity.Name;
                    order.DateOfOrder = DateTime.Now;

                    //Save Order

                    db.ORDERRs.Add(order);
                    db.SaveChanges();
                    //Process the order
                    var cart = Cart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete", new { id = order.Order_ID });
                }
                else
                {
                    order.Username = User.Identity.Name;
                    order.DateOfOrder = DateTime.Now;

                    //Save Order

                    db.ORDERRs.Add(order);
                    db.SaveChanges();
                    //Process the order
                    var cart = Cart.GetCart(this.HttpContext);
                    cart.CreateOrder(order);
                    return RedirectToAction("Complete", new { id = order.Order_ID });
                
                }
               
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }

        //
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = db.ORDERRs.Any(
                o => o.Order_ID == id &&
                o.Username == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }

    }
}
