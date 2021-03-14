using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolManagement3.Models
{
    public class LecturersController : Controller
    {
        private SchollManagement_DBEntities db = new SchollManagement_DBEntities();

        // GET: Lecturers
        public ActionResult Index()
        {
            return View(db.Lecturers.ToList());
        }

        // GET: Lecturers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = db.Lecturers.Find(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // GET: Lecturers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lecturers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name")] Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                db.Lecturers.Add(lecturers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lecturers);
        }

        // GET: Lecturers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = db.Lecturers.Find(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name")] Lecturers lecturers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecturers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lecturers);
        }

        // GET: Lecturers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecturers lecturers = db.Lecturers.Find(id);
            if (lecturers == null)
            {
                return HttpNotFound();
            }
            return View(lecturers);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecturers lecturers = db.Lecturers.Find(id);
            db.Lecturers.Remove(lecturers);
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
