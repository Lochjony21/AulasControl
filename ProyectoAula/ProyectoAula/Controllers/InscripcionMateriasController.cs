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
    public class InscripcionMateriasController : Controller
    {
        private AulaBaseEntities db = new AulaBaseEntities();

        // GET: InscripcionMaterias
        public ActionResult Index()
        {
            var inscripcionMateria = db.InscripcionMateria.Include(i => i.Usuario).Include(i => i.Materia);
            return View(inscripcionMateria.ToList());
        }

        // GET: InscripcionMaterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionMateria inscripcionMateria = db.InscripcionMateria.Find(id);
            if (inscripcionMateria == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionMateria);
        }

        // GET: InscripcionMaterias/Create
        public ActionResult Create()
        {
            ViewBag.IdInscrito = new SelectList(db.Usuario, "IdUsuario", "Nombre");
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria");
            return View();
        }

        // POST: InscripcionMaterias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdInscripcion,IdInscrito,IdMateria,Estado")] InscripcionMateria inscripcionMateria)
        {
            if (ModelState.IsValid)
            {
                db.InscripcionMateria.Add(inscripcionMateria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdInscrito = new SelectList(db.Usuario, "IdUsuario", "Nombre", inscripcionMateria.IdInscrito);
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria", inscripcionMateria.IdMateria);
            return View(inscripcionMateria);
        }

        // GET: InscripcionMaterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionMateria inscripcionMateria = db.InscripcionMateria.Find(id);
            if (inscripcionMateria == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdInscrito = new SelectList(db.Usuario, "IdUsuario", "Nombre", inscripcionMateria.IdInscrito);
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria", inscripcionMateria.IdMateria);
            return View(inscripcionMateria);
        }

        // POST: InscripcionMaterias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdInscripcion,IdInscrito,IdMateria,Estado")] InscripcionMateria inscripcionMateria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcionMateria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdInscrito = new SelectList(db.Usuario, "IdUsuario", "Nombre", inscripcionMateria.IdInscrito);
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria", inscripcionMateria.IdMateria);
            return View(inscripcionMateria);
        }

        // GET: InscripcionMaterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InscripcionMateria inscripcionMateria = db.InscripcionMateria.Find(id);
            if (inscripcionMateria == null)
            {
                return HttpNotFound();
            }
            return View(inscripcionMateria);
        }

        // POST: InscripcionMaterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InscripcionMateria inscripcionMateria = db.InscripcionMateria.Find(id);
            db.InscripcionMateria.Remove(inscripcionMateria);
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
