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
    public class CorreoUsuariosController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: CorreoUsuarios
        public ActionResult Index()
        {
            var correoUsuarios = db.CorreoUsuarios.Include(c => c.Usuario);
            return View(correoUsuarios.ToList());
        }

        // GET: CorreoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorreoUsuario correoUsuario = db.CorreoUsuarios.Find(id);
            if (correoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(correoUsuario);
        }

        // GET: CorreoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: CorreoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCorreo,IdUsuario,Correo,Estado")] CorreoUsuario correoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.CorreoUsuarios.Add(correoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", correoUsuario.IdUsuario);
            return View(correoUsuario);
        }

        // GET: CorreoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorreoUsuario correoUsuario = db.CorreoUsuarios.Find(id);
            if (correoUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", correoUsuario.IdUsuario);
            return View(correoUsuario);
        }

        // POST: CorreoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCorreo,IdUsuario,Correo,Estado")] CorreoUsuario correoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(correoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", correoUsuario.IdUsuario);
            return View(correoUsuario);
        }

        // GET: CorreoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CorreoUsuario correoUsuario = db.CorreoUsuarios.Find(id);
            if (correoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(correoUsuario);
        }

        // POST: CorreoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CorreoUsuario correoUsuario = db.CorreoUsuarios.Find(id);
            db.CorreoUsuarios.Remove(correoUsuario);
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
