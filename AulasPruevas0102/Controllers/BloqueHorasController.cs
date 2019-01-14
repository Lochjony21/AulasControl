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
    public class BloqueHorasController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: BloqueHoras
        public ActionResult Index()
        {
            return View(db.BloqueHoras.ToList());
        }

        // GET: BloqueHoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloqueHora bloqueHora = db.BloqueHoras.Find(id);
            if (bloqueHora == null)
            {
                return HttpNotFound();
            }
            return View(bloqueHora);
        }

        // GET: BloqueHoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BloqueHoras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdBloque,Nombre,HoraInicio,HoraFin,Turno,Estado")] BloqueHora bloqueHora)
        {
            if (ModelState.IsValid)
            {
                db.BloqueHoras.Add(bloqueHora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloqueHora);
        }

        // GET: BloqueHoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloqueHora bloqueHora = db.BloqueHoras.Find(id);
            if (bloqueHora == null)
            {
                return HttpNotFound();
            }
            return View(bloqueHora);
        }

        // POST: BloqueHoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBloque,Nombre,HoraInicio,HoraFin,Turno,Estado")] BloqueHora bloqueHora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloqueHora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloqueHora);
        }

        // GET: BloqueHoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloqueHora bloqueHora = db.BloqueHoras.Find(id);
            if (bloqueHora == null)
            {
                return HttpNotFound();
            }
            return View(bloqueHora);
        }

        // POST: BloqueHoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloqueHora bloqueHora = db.BloqueHoras.Find(id);
            db.BloqueHoras.Remove(bloqueHora);
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
