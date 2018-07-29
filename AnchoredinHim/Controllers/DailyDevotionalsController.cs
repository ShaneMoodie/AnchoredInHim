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
    public class DailyDevotionalsController : Controller
    {
        private AnchoredinHimEntities db = new AnchoredinHimEntities();

        // GET: DailyDevotionals
        public ActionResult Index()
        {
            var dailyDevotionals = db.DailyDevotionals.Include(d => d.Archive);
            return View(dailyDevotionals.ToList());
        }

        // GET: DailyDevotionals/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyDevotional dailyDevotional = db.DailyDevotionals.Find(id);
            if (dailyDevotional == null)
            {
                return HttpNotFound();
            }
            return View(dailyDevotional);
        }

        // GET: DailyDevotionals/Create
        public ActionResult Create()
        {
            ViewBag.DailyDevoID = new SelectList(db.Archives, "ArchivesID", "ArchivesID");
            return View();
        }

        // POST: DailyDevotionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DailyDevoID,Devo")] DailyDevotional dailyDevotional)
        {
            if (ModelState.IsValid)
            {
                db.DailyDevotionals.Add(dailyDevotional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DailyDevoID = new SelectList(db.Archives, "ArchivesID", "ArchivesID", dailyDevotional.DailyDevoID);
            return View(dailyDevotional);
        }

        // GET: DailyDevotionals/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyDevotional dailyDevotional = db.DailyDevotionals.Find(id);
            if (dailyDevotional == null)
            {
                return HttpNotFound();
            }
            ViewBag.DailyDevoID = new SelectList(db.Archives, "ArchivesID", "ArchivesID", dailyDevotional.DailyDevoID);
            return View(dailyDevotional);
        }

        // POST: DailyDevotionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DailyDevoID,Devo")] DailyDevotional dailyDevotional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dailyDevotional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DailyDevoID = new SelectList(db.Archives, "ArchivesID", "ArchivesID", dailyDevotional.DailyDevoID);
            return View(dailyDevotional);
        }

        // GET: DailyDevotionals/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DailyDevotional dailyDevotional = db.DailyDevotionals.Find(id);
            if (dailyDevotional == null)
            {
                return HttpNotFound();
            }
            return View(dailyDevotional);
        }

        // POST: DailyDevotionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DailyDevotional dailyDevotional = db.DailyDevotionals.Find(id);
            db.DailyDevotionals.Remove(dailyDevotional);
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
