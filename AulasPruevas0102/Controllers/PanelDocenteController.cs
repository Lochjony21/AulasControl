using AulasPruevas0102.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulasPruevas0102.Controllers
{
    public class PanelDocenteController : Controller
    {
        private asignacionEntities db = new asignacionEntities();
        // GET: PanelDocente
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult Horarios()
        {
            //Equivaler segun ID de docente
           // Equivaler segun fecha 
            var query = from a in db.HorariosFijos select a;
            return PartialView("_HorariosFijo", query.ToList());
        }
        [ChildActionOnly]
        public ActionResult Materia()
        {
            //Equivaler segun ID de docente
            // Equivaler segun fecha 
            var query = from a in db.Materias select a;
            return PartialView("_Materias", query.ToList());
        }
        public ActionResult Materias()
        {

            return View();
        }
        }
}