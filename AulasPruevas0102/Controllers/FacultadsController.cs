using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AulasPruevas0102.Models;

namespace AulasPruevas0102.Controllers
{
    public class FacultadsController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: Facultads
        public ActionResult Index()
        {
            return View(db.Facultads.ToList());
        }

        // GET: Facultads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = db.Facultads.Find(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // GET: Facultads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facultads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFacultad,Nombre")] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                db.Facultads.Add(facultad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(facultad);
        }

        // GET: Facultads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = db.Facultads.Find(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // POST: Facultads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFacultad,Nombre")] Facultad facultad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(facultad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(facultad);
        }

        // GET: Facultads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Facultad facultad = db.Facultads.Find(id);
            if (facultad == null)
            {
                return HttpNotFound();
            }
            return View(facultad);
        }

        // POST: Facultads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Facultad facultad = db.Facultads.Find(id);
            db.Facultads.Remove(facultad);
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
