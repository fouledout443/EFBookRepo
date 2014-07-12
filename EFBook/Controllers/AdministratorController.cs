using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFBook.Controllers
{
    //[Authorize(Roles = "Administrator")]
    [Authorize(Roles = "Admin")] 
    public class AdministratorController : Controller
    {
        private jnolanEntities6 db = new jnolanEntities6();

        //
        // GET: /Administrator/
        
        public ActionResult Index()
        {
            var books = db.BOOKS.Include(b => b.CATEGORY).Include(b => b.PUBLISHER);
            return View(books.ToList());
        }

        //
        // GET: /Administrator/Details/5

        public ActionResult Details(int id = 0)
        {
            BOOK book = db.BOOKS.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Administrator/Create

        public ActionResult Create()
        {
            ViewBag.Category_ID = new SelectList(db.CATEGORies, "Category_ID", "CategoryName");
            ViewBag.Publisher_ID = new SelectList(db.PUBLISHERs, "Publisher_ID", "Publisher_Name");
            return View();
        }

        //
        // POST: /Administrator/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BOOK book)
        {
            if (ModelState.IsValid)
            {
                db.BOOKS.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category_ID = new SelectList(db.CATEGORies, "Category_ID", "CategoryName", book.Category_ID);
            ViewBag.Publisher_ID = new SelectList(db.PUBLISHERs, "Publisher_ID", "Publisher_Name", book.Publisher_ID);
            return View(book);
        }

        //
        // GET: /Administrator/Edit/5

        public ActionResult Edit(int id = 0)
        {
            BOOK book = db.BOOKS.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category_ID = new SelectList(db.CATEGORies, "Category_ID", "CategoryName", book.Category_ID);
            ViewBag.Publisher_ID = new SelectList(db.PUBLISHERs, "Publisher_ID", "Publisher_Name", book.Publisher_ID);
            return View(book);
        }

        //
        // POST: /Administrator/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BOOK book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category_ID = new SelectList(db.CATEGORies, "Category_ID", "CategoryName", book.Category_ID);
            ViewBag.Publisher_ID = new SelectList(db.PUBLISHERs, "Publisher_ID", "Publisher_Name", book.Publisher_ID);
            return View(book);
        }

        //
        // GET: /Administrator/Delete/5

        public ActionResult Delete(int id = 0)
        {
            BOOK book = db.BOOKS.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Administrator/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BOOK book = db.BOOKS.Find(id);
            db.BOOKS.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
//http://logcorner.wordpress.com/2013/08/29/how-to-configure-custom-membership-and-role-provider-using-asp-net-mvc4/