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
    public class BloqueHorasController : Controller
    {
        private AulaBaseEntities db = new AulaBaseEntities();

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
            BloqueHoras bloqueHoras = db.BloqueHoras.Find(id);
            if (bloqueHoras == null)
            {
                return HttpNotFound();
            }
            return View(bloqueHoras);
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
        public ActionResult Create([Bind(Include = "IdBloque,NombreBloque,HoraInicio,HoraFin,Turno,Estado")] BloqueHoras bloqueHoras)
        {
            if (ModelState.IsValid)
            {
                db.BloqueHoras.Add(bloqueHoras);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bloqueHoras);
        }

        // GET: BloqueHoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloqueHoras bloqueHoras = db.BloqueHoras.Find(id);
            if (bloqueHoras == null)
            {
                return HttpNotFound();
            }
            return View(bloqueHoras);
        }

        // POST: BloqueHoras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdBloque,NombreBloque,HoraInicio,HoraFin,Turno,Estado")] BloqueHoras bloqueHoras)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bloqueHoras).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bloqueHoras);
        }

        // GET: BloqueHoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BloqueHoras bloqueHoras = db.BloqueHoras.Find(id);
            if (bloqueHoras == null)
            {
                return HttpNotFound();
            }
            return View(bloqueHoras);
        }

        // POST: BloqueHoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BloqueHoras bloqueHoras = db.BloqueHoras.Find(id);
            db.BloqueHoras.Remove(bloqueHoras);
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
