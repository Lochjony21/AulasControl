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
    public class HorariosFijoesController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: HorariosFijoes
        public ActionResult Index()
        {
            var horariosFijos = db.HorariosFijos.Include(h => h.BloqueHora).Include(h => h.Espacio).Include(h => h.Materia);
            return View(horariosFijos.ToList());
        }

        // GET: HorariosFijoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorariosFijo horariosFijo = db.HorariosFijos.Find(id);
            if (horariosFijo == null)
            {
                return HttpNotFound();
            }
            return View(horariosFijo);
        }

        // GET: HorariosFijoes/Create
        public ActionResult Create()
        {
            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "Nombre");
            ViewBag.IdEspacio = new SelectList(db.Espacios, "IdEspacio", "Nombre");
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "NombreMateria");
            return View();
        }

        // POST: HorariosFijoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdHorarios,IdBloque,IdMateria,IdEspacio,FechaInicio,FechaFin,Estado")] HorariosFijo horariosFijo)
        {
            if (ModelState.IsValid)
            {
                db.HorariosFijos.Add(horariosFijo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "Nombre", horariosFijo.IdBloque);
            ViewBag.IdEspacio = new SelectList(db.Espacios, "IdEspacio", "Nombre", horariosFijo.IdEspacio);
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "NombreMateria", horariosFijo.IdMateria);
            return View(horariosFijo);
        }

        // GET: HorariosFijoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorariosFijo horariosFijo = db.HorariosFijos.Find(id);
            if (horariosFijo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "Nombre", horariosFijo.IdBloque);
            ViewBag.IdEspacio = new SelectList(db.Espacios, "IdEspacio", "Nombre", horariosFijo.IdEspacio);
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "NombreMateria", horariosFijo.IdMateria);
            return View(horariosFijo);
        }

        // POST: HorariosFijoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdHorarios,IdBloque,IdMateria,IdEspacio,FechaInicio,FechaFin,Estado")] HorariosFijo horariosFijo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(horariosFijo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdBloque = new SelectList(db.BloqueHoras, "IdBloque", "Nombre", horariosFijo.IdBloque);
            ViewBag.IdEspacio = new SelectList(db.Espacios, "IdEspacio", "Nombre", horariosFijo.IdEspacio);
            ViewBag.IdMateria = new SelectList(db.Materias, "IdMateria", "NombreMateria", horariosFijo.IdMateria);
            return View(horariosFijo);
        }

        // GET: HorariosFijoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HorariosFijo horariosFijo = db.HorariosFijos.Find(id);
            if (horariosFijo == null)
            {
                return HttpNotFound();
            }
            return View(horariosFijo);
        }

        // POST: HorariosFijoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HorariosFijo horariosFijo = db.HorariosFijos.Find(id);
            db.HorariosFijos.Remove(horariosFijo);
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
