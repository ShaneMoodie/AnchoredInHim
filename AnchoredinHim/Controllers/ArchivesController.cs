using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnchoredinHim.Models;

namespace AnchoredinHim.Controllers
{
    public class ArchivesController : Controller
    {
        private AnchoredinHimEntities db = new AnchoredinHimEntities();

        // GET: Archives
        public ActionResult Index()
        {
            var archives = db.Archives.Include(a => a.Blog).Include(a => a.DailyDevotional).Include(a => a.Event);
            return View(archives.ToList());
        }

        // GET: Archives/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archive archive = db.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            return View(archive);
        }

        // GET: Archives/Create
        public ActionResult Create()
        {
            ViewBag.ArchivesID = new SelectList(db.Blogs, "BlogID", "Post");
            ViewBag.ArchivesID = new SelectList(db.DailyDevotionals, "DailyDevoID", "Devo");
            ViewBag.ArchivesID = new SelectList(db.Events, "EventID", "Name");
            return View();
        }

        // POST: Archives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ArchivesID,Date")] Archive archive)
        {
            if (ModelState.IsValid)
            {
                db.Archives.Add(archive);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ArchivesID = new SelectList(db.Blogs, "BlogID", "Post", archive.ArchivesID);
            ViewBag.ArchivesID = new SelectList(db.DailyDevotionals, "DailyDevoID", "Devo", archive.ArchivesID);
            ViewBag.ArchivesID = new SelectList(db.Events, "EventID", "Name", archive.ArchivesID);
            return View(archive);
        }

        // GET: Archives/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archive archive = db.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            ViewBag.ArchivesID = new SelectList(db.Blogs, "BlogID", "Post", archive.ArchivesID);
            ViewBag.ArchivesID = new SelectList(db.DailyDevotionals, "DailyDevoID", "Devo", archive.ArchivesID);
            ViewBag.ArchivesID = new SelectList(db.Events, "EventID", "Name", archive.ArchivesID);
            return View(archive);
        }

        // POST: Archives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ArchivesID,Date")] Archive archive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(archive).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ArchivesID = new SelectList(db.Blogs, "BlogID", "Post", archive.ArchivesID);
            ViewBag.ArchivesID = new SelectList(db.DailyDevotionals, "DailyDevoID", "Devo", archive.ArchivesID);
            ViewBag.ArchivesID = new SelectList(db.Events, "EventID", "Name", archive.ArchivesID);
            return View(archive);
        }

        // GET: Archives/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Archive archive = db.Archives.Find(id);
            if (archive == null)
            {
                return HttpNotFound();
            }
            return View(archive);
        }

        // POST: Archives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Archive archive = db.Archives.Find(id);
            db.Archives.Remove(archive);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
