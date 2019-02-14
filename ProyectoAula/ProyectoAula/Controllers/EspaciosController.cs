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
    public class EspaciosController : Controller
    {
        private AulaBaseEntities db = new AulaBaseEntities();

        // GET: Espacios
        public ActionResult Index()
        {
            return View(db.Espacio.ToList());
        }

        // GET: Espacios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espacio espacio = db.Espacio.Find(id);
            if (espacio == null)
            {
                return HttpNotFound();
            }
            return View(espacio);
        }

        // GET: Espacios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Espacios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEspacio,NombreEspacio,Descripcion,Capacidad,Tipo,Estado")] Espacio espacio)
        {
            if (ModelState.IsValid)
            {
                db.Espacio.Add(espacio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(espacio);
        }

        // GET: Espacios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espacio espacio = db.Espacio.Find(id);
            if (espacio == null)
            {
                return HttpNotFound();
            }
            return View(espacio);
        }

        // POST: Espacios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEspacio,NombreEspacio,Descripcion,Capacidad,Tipo,Estado")] Espacio espacio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(espacio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(espacio);
        }

        // GET: Espacios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Espacio espacio = db.Espacio.Find(id);
            if (espacio == null)
            {
                return HttpNotFound();
            }
            return View(espacio);
        }

        // POST: Espacios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Espacio espacio = db.Espacio.Find(id);
            db.Espacio.Remove(espacio);
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
