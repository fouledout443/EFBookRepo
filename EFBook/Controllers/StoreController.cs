using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EFBook.Controllers
{
    public class StoreController : Controller
    {

        private jnolanEntities6 db = new jnolanEntities6();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            var categories = db.CATEGORies.ToList();
            return View(categories);
        }
        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string category)
        {
            var categoryModel = db.CATEGORies.Include("Books")
                .Single(c => c.CategoryName == category);
            return View(categoryModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id = 0)
        {
            BOOK book = db.BOOKS.Find(id);
            if ( book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Store/GenreMenu
        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = db.CATEGORies.ToList();
            return PartialView(categories);
        }

    }
}
