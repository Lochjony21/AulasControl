using AulasPruevas0102.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace AulasPruevas0102.Controllers
{
    public class AdminController : Controller
    {
        private asignacionEntities db = new asignacionEntities();

        public ActionResult Index()
        {
            var reservas = db.Reservas.Include(r => r.BloqueHora).Include(r => r.Espacio);
            return View("Admin",reservas.ToList());
        }
    }
}