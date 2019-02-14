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
    public class HorariosFijosController : Controller
    {
        private AulaBaseEntities db = new AulaBaseEntities();

        // GET: HorariosFijos
        public ActionResult Index()
        {
            var horariosFijos = db.HorariosFijos.Include(h => h.Espacio).Include(h => h.Materia);
            return View(horariosFijos.ToList());
        }

        // GET: HorariosFijos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorariosFijos horariosFijos = db.HorariosFijos.Find(id);
            if (horariosFijos == null)
            {
                return HttpNotFound();
            }
            return View(horariosFijos);
        }

        // GET: HorariosFijos/Create
        public ActionResult Create()
        {
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio");
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria");
            return View();
        }

        // POST: HorariosFijos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHorarioFijo,IdMateria,IdEspacio,Estado")] HorariosFijos horariosFijos)
        {
            if (ModelState.IsValid)
            {
                db.HorariosFijos.Add(horariosFijos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio", horariosFijos.IdEspacio);
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria", horariosFijos.IdMateria);
            return View(horariosFijos);
        }

        // GET: HorariosFijos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorariosFijos horariosFijos = db.HorariosFijos.Find(id);
            if (horariosFijos == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio", horariosFijos.IdEspacio);
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria", horariosFijos.IdMateria);
            return View(horariosFijos);
        }

        // POST: HorariosFijos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHorarioFijo,IdMateria,IdEspacio,Estado")] HorariosFijos horariosFijos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horariosFijos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEspacio = new SelectList(db.Espacio, "IdEspacio", "NombreEspacio", horariosFijos.IdEspacio);
            ViewBag.IdMateria = new SelectList(db.Materia, "IdMateria", "NombreMateria", horariosFijos.IdMateria);
            return View(horariosFijos);
        }

        // GET: HorariosFijos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorariosFijos horariosFijos = db.HorariosFijos.Find(id);
            if (horariosFijos == null)
            {
                return HttpNotFound();
            }
            return View(horariosFijos);
        }

        // POST: HorariosFijos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorariosFijos horariosFijos = db.HorariosFijos.Find(id);
            db.HorariosFijos.Remove(horariosFijos);
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
