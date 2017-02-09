using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models;


namespace RetroAlimentacionSoft.Controllers
{
    public class IngresarController : Controller
    {
        // GET: Ingresar
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Ingreso ingreso)
        {
            
            if (string.IsNullOrEmpty(ingreso.nomina) || string.IsNullOrEmpty(ingreso.pass))
            {
                ViewBag.Error = "Esta vacia la infomración";

                return View(ingreso);
                
            }
            System.Web.HttpContext.Current.Session["usuario"] = ingreso.nomina;
            return RedirectToAction("Index", "Home");
            
        }
    }
}