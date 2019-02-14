using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoAula.Models;

namespace ProyectoAula.Controllers
{
    public class ReservasController : Controller
    {
        private AulaBaseEntities db = new AulaBaseEntities();

        // GET: Reservas
        public ActionResult Index()
        {
            var reserva = db.Reserva.Include(r => r.BloqueHoras).Include(r => r.Espacio);
            return View(reserva.ToList());
        }

        // GET: Reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: Reservas/Create
        public ActionResult Create()
        {
            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "NombreBloque");
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio");
            return View();
        }

        // POST: Reservas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdReserva,CodigoReservante,IdEspacio,IdBloque,Fecha,Confirmacion,Estado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Reserva.Add(reserva);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "NombreBloque", reserva.IdBloque);
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio", reserva.IdEspacio);
            return View(reserva);
        }

        // GET: Reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "NombreBloque", reserva.IdBloque);
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio", reserva.IdEspacio);
            return View(reserva);
        }

        // POST: Reservas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdReserva,CodigoReservante,IdEspacio,IdBloque,Fecha,Confirmacion,Estado")] Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "NombreBloque", reserva.IdBloque);
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio", reserva.IdEspacio);
            return View(reserva);
        }

        // GET: Reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserva reserva = db.Reserva.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: Reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserva reserva = db.Reserva.Find(id);
            db.Reserva.Remove(reserva);
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
