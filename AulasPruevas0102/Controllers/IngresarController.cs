using AulasPruevas0102.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AulasPruevas0102.Controllers
{
    public class IngresarController : Controller
    {

        private asignacionEntities obj = new asignacionEntities();
        Helper Helper = new Helper();
        // GET: Sesion
        public ActionResult Index()
        {
            ViewBag.alerta = "hidden";
            return View();
        }

        [HttpPost]
        public ActionResult Index(string user, string pass)
        {
            /*string password = Helper.EncodePassword(pass);*/
            var dato = (from a in obj.logueos where a.Usuario == user && a.Clave == pass select a).FirstOrDefault();
            if (dato != null)
            {
                Session["Id"] = dato.IdLogueo;
                Session["nombre"] = dato.Usuario;
                //EVALUACION PARA TIPO DE USUARIO
                //    SI ES ADMIN >pANEL GENERAL
                //    SI ES DOCEN >pPanel DOCENTE
                return RedirectToAction("Index", "Panel");
            }

            ViewBag.alerta = "vissible";

            ViewBag.error = "Usuario o contraseña incorrectos";
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}