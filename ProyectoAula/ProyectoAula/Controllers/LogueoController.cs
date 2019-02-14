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
    public class LogueoController : Controller
    {
        private AulaBaseEntities db = new AulaBaseEntities();

        // GET: Logueo
        public ActionResult Index()
        {
            var logueo = db.Logueo.Include(l => l.Usuario1);
            return View(logueo.ToList());
        }

        // GET: Logueo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logueo logueo = db.Logueo.Find(id);
            if (logueo == null)
            {
                return HttpNotFound();
            }
            return View(logueo);
        }

        // GET: Logueo/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre");
            return View();
        }

        // POST: Logueo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLogueo,IdUsuario,Usuario,Clave,Tipo,Estado")] Logueo logueo)
        {
            if (ModelState.IsValid)
            {
                db.Logueo.Add(logueo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre", logueo.IdUsuario);
            return View(logueo);
        }

        // GET: Logueo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logueo logueo = db.Logueo.Find(id);
            if (logueo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre", logueo.IdUsuario);
            return View(logueo);
        }

        // POST: Logueo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLogueo,IdUsuario,Usuario,Clave,Tipo,Estado")] Logueo logueo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logueo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuario, "IdUsuario", "Nombre", logueo.IdUsuario);
            return View(logueo);
        }

        // GET: Logueo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logueo logueo = db.Logueo.Find(id);
            if (logueo == null)
            {
                return HttpNotFound();
            }
            return View(logueo);
        }

        // POST: Logueo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logueo logueo = db.Logueo.Find(id);
            db.Logueo.Remove(logueo);
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
