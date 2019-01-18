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
    public class logueosController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        // GET: logueos
        public ActionResult Index()
        {
            var logueos = db.logueos.Include(l => l.Usuario1);
            return View(logueos.ToList());
        }

        // GET: logueos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logueo logueo = db.logueos.Find(id);
            if (logueo == null)
            {
                return HttpNotFound();
            }
            return View(logueo);
        }

        // GET: logueos/Create
        public ActionResult Create()
        {
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: logueos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdLogueo,IdUsuario,Usuario,Clave,Estado")] logueo logueo)
        {
            if (ModelState.IsValid)
            {
                db.logueos.Add(logueo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", logueo.IdUsuario);
            return View(logueo);
        }

        // GET: logueos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {

                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logueo logueo = db.logueos.Find(id);
            if (logueo == null)
            {
                return RedirectToAction("Index");
            }
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", logueo.IdUsuario);
            return View(logueo);
        }

        // POST: logueos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdLogueo,IdUsuario,Usuario,Clave,Estado")] logueo logueo)
        {
            if (ModelState.IsValid)
            {
                string password = Helper.EncodePassword(logueo.Clave);
                var dato = new logueo()
                {
                    IdLogueo = logueo.IdLogueo,
                    IdUsuario = logueo.IdUsuario,
                    Usuario = logueo.Usuario,
                    Clave = logueo.Clave,
                    Estado = logueo.Estado
                };
                db.Entry(logueo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
            //ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", logueo.IdUsuario);
            //return View(logueo);
        }

        // GET: logueos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            logueo logueo = db.logueos.Find(id);
            if (logueo == null)
            {
                return HttpNotFound();
            }
            return View(logueo);
        }

        // POST: logueos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            logueo logueo = db.logueos.Find(id);
            db.logueos.Remove(logueo);
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
