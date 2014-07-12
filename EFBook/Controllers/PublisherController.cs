using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFBook.Controllers
{
    public class PublisherController : Controller
    {
        private jnolanEntities6 db = new jnolanEntities6();

        //
        // GET: /Publisher/

        public ActionResult Index()
        {
            return View(db.PUBLISHERs.ToList());
        }

        //
        // GET: /Publisher/Details/5

        public ActionResult Details(int id = 0)
        {
            PUBLISHER publisher = db.PUBLISHERs.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        //
        // GET: /Publisher/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Publisher/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PUBLISHER publisher)
        {
            if (ModelState.IsValid)
            {
                db.PUBLISHERs.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        //
        // GET: /Publisher/Edit/5

        public ActionResult Edit(int id = 0)
        {
            PUBLISHER publisher = db.PUBLISHERs.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        //
        // POST: /Publisher/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PUBLISHER publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        //
        // GET: /Publisher/Delete/5

        public ActionResult Delete(int id = 0)
        {
            PUBLISHER publisher = db.PUBLISHERs.Find(id);
            if (publisher == null)
            {
                return HttpNotFound();
            }
            return View(publisher);
        }

        //
        // POST: /Publisher/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PUBLISHER publisher = db.PUBLISHERs.Find(id);
            db.PUBLISHERs.Remove(publisher);
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