using AulasPruevas0102.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AulasPruevas0102.Controllers
{
    public class LoginController : Controller
    {
        private asignacionEntities db = new asignacionEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(logueo logueo, string returnUrl)
        {
            var data = db.logueos.Where(x => x.Usuario == logueo.Usuario && x.Clave == logueo.Clave).First();
            if (data != null)
            {
                FormsAuthentication.SetAuthCookie(data.Usuario, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ModelState.AddModelError("", "correo o contraseña invalida");
                return View();
            }
        }
    }
}