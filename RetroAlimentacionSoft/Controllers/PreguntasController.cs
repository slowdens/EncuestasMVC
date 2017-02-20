using RetroAlimentacionSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models.utilidades;

namespace RetroAlimentacionSoft.Controllers
{
    public class PreguntasController : BaseController
    {

        private BaseDatosContext db = new BaseDatosContext();
        
        // GET: Preguntas


        public ActionResult Index()
        {
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();

            var consulta = from s in db.Software
                    join p in db.Preguntas on new { sigla = s.Sigla } equals new { sigla = p.Sigla }
                    select new
                    {
                        p.IdPregunta,
                        software = s.NombreSoftware,
                        p.Pregunta
                    };

            List<UnionPreguntaSoft> datos = new List<UnionPreguntaSoft>();
            foreach(var s in consulta)
            {
                datos.Add(new UnionPreguntaSoft(){ idPregunta = s.IdPregunta, Pregunta = s.Pregunta, Software = s.software });
            }

            return View(datos);
        }

        public ActionResult Agregar()
        {

            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            //var items = db.Cat_roles;
            //var vm = new VistaRol();
            //vm.rol = items;
            ////mandamos el rol a la vista
            //return View(vm);

            var items = db.Software;
            var vm = new VistaAplicacion();
            vm.sofware = items;
            return View(vm);
        
        }

        public ActionResult AgregarDatos(string sofware, string Preguntass)
        {
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();

            //Agregar pregunta
            Preguntas per = new Preguntas()
            {
                Pregunta = Preguntass,
                Sigla = sofware
            };
            db.Preguntas.Add(per);
            db.SaveChanges();

            //tomamos el id de la pregunta guardada

            var objIds = from pr in db.Preguntas
                         where pr.Pregunta == Preguntass && pr.Sigla == sofware
                         select new
                         {
                           idp=  pr.IdPregunta
                         };
            foreach(var od in objIds)
            {
                ViewBag.ids = od.idp;
            }

            ViewBag.pregunta = Preguntass;
            //mandamos el id de la pregunta generada
            return View(ViewBag.ids);
        }

        public ActionResult AgregarRespuesta(string respuesta, int idPregunta,float valor)
        {
            Respuesta res = new Respuesta();

            res.Respuesta1 = respuesta;
            res.Valor = valor;
            res.IdPregunta = idPregunta;

            db.Respuesta.Add(res);
            db.SaveChanges();
            
            //tomamos el valor del id registrado
            var valorActual = from i in db.Respuesta
                              where i.Respuesta1 == respuesta && i.Valor == valor && i.IdPregunta == idPregunta
                              select new
                              {
                                  Ids = i.IdRespuesta
                              };
            foreach(var vals in valorActual ){
                ViewBag.ids = vals.Ids;
            };
                        
            return View();
        }

    }

    
}