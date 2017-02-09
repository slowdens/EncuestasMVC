using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models;

namespace RetroAlimentacionSoft.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if(System.Web.HttpContext.Current.Session["usuario"]== null)
            {
                return RedirectToAction("Index", "Ingresar"); 
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Salir()
        {
            string dato = "";
            //Salir del sisma
            Session.Remove("usuario");
            return RedirectToAction("Index", "Ingresar");
        }

      
    }
}