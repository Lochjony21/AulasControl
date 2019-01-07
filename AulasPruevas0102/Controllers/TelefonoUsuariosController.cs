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
    public class TelefonoUsuariosController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: TelefonoUsuarios
        public ActionResult Index()
        {
            var telefonoUsuarios = db.TelefonoUsuarios.Include(t => t.Usuario);
            return View(telefonoUsuarios.ToList());
        }

        // GET: TelefonoUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonoUsuario telefonoUsuario = db.TelefonoUsuarios.Find(id);
            if (telefonoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(telefonoUsuario);
        }

        // GET: TelefonoUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: TelefonoUsuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdTelefono,IdUsuario,Telefono,Estado")] TelefonoUsuario telefonoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.TelefonoUsuarios.Add(telefonoUsuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", telefonoUsuario.IdUsuario);
            return View(telefonoUsuario);
        }

        // GET: TelefonoUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonoUsuario telefonoUsuario = db.TelefonoUsuarios.Find(id);
            if (telefonoUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", telefonoUsuario.IdUsuario);
            return View(telefonoUsuario);
        }

        // POST: TelefonoUsuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdTelefono,IdUsuario,Telefono,Estado")] TelefonoUsuario telefonoUsuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(telefonoUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", telefonoUsuario.IdUsuario);
            return View(telefonoUsuario);
        }

        // GET: TelefonoUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TelefonoUsuario telefonoUsuario = db.TelefonoUsuarios.Find(id);
            if (telefonoUsuario == null)
            {
                return HttpNotFound();
            }
            return View(telefonoUsuario);
        }

        // POST: TelefonoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TelefonoUsuario telefonoUsuario = db.TelefonoUsuarios.Find(id);
            db.TelefonoUsuarios.Remove(telefonoUsuario);
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
