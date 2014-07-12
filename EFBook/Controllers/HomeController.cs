using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFBook.Models;


namespace EFBook.Controllers
{
    public class HomeController : Controller
    {
        jnolanEntities6 db = new jnolanEntities6();
        public ActionResult Index()
        {
            //ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            //return View();
            var books = GetTopSellingAlbums(5);
            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private List<BOOK> GetTopSellingAlbums(int count)
        {
            // Group the order details by album and return
            // the albums with the highest count
             
            return db.BOOKS
                .OrderByDescending(a => a.BookID)
                .Take(count)
                .ToList();
        }
    }
}
