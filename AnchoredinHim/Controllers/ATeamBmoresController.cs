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
    public class ATeamBmoresController : Controller
    {
        private AnchoredinHimEntities1 db = new AnchoredinHimEntities1();

        // GET: ATeamBmores
        public ActionResult Index()
        {
            return View(db.ATeamBmores.ToList());
        }

        // GET: ATeamBmores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATeamBmore aTeamBmore = db.ATeamBmores.Find(id);
            if (aTeamBmore == null)
            {
                return HttpNotFound();
            }
            return View(aTeamBmore);
        }

        // GET: ATeamBmores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ATeamBmores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Post")] ATeamBmore aTeamBmore)
        {
            if (ModelState.IsValid)
            {
                db.ATeamBmores.Add(aTeamBmore);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aTeamBmore);
        }

        // GET: ATeamBmores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATeamBmore aTeamBmore = db.ATeamBmores.Find(id);
            if (aTeamBmore == null)
            {
                return HttpNotFound();
            }
            return View(aTeamBmore);
        }

        // POST: ATeamBmores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Post")] ATeamBmore aTeamBmore)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aTeamBmore).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aTeamBmore);
        }

        // GET: ATeamBmores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ATeamBmore aTeamBmore = db.ATeamBmores.Find(id);
            if (aTeamBmore == null)
            {
                return HttpNotFound();
            }
            return View(aTeamBmore);
        }

        // POST: ATeamBmores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ATeamBmore aTeamBmore = db.ATeamBmores.Find(id);
            db.ATeamBmores.Remove(aTeamBmore);
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
