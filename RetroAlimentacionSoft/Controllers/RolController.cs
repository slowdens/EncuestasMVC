using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models;
using RetroAlimentacionSoft.Models.utilidades;
namespace RetroAlimentacionSoft.Controllers
{
    public class RolController : BaseController
    {
        BaseDatosContext db = new BaseDatosContext();

        // GET: Rol
        public ActionResult Index()
        {
            
            if(System.Web.HttpContext.Current.Session["usuario"]== null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            var items = db.Cat_roles;
            var vm = new VistaRol();
            vm.rol = items;
            return View(vm);
        }

        public ActionResult hola(VistaRol r)
        {
            VistaRol res = r;
            return View();
        }

        public PartialViewResult GetMenu(string rol)
        {
            List<MenuControl> datos = new List<MenuControl>();
            try
            {
                int i = int.Parse(rol);

                //var combo = from p in db.menu_roles
                //            join m in db.cat_menu on p.id_menu equals m.id_menu
                //            join mss in db.Cat_roles on p.id_rol equals mss.id_rol
                //            where p.id_rol== i
                //            select new
                //            {
                //                m.id_menu,
                //                m.Nombre
                //            };


                var combo = from mr in db.menu_roles
                            where
                              mr.Cat_roles.id_rol == 1
                            select new
                            {
                                mr.id_menu,
                                mr.cat_menu.Nombre
                            };



                foreach (var ds in combo)
                {
                    datos.Add(new MenuControl() { id_menu = ds.id_menu, Nombre = ds.Nombre });
                    

                }
                

            }catch(Exception ess)
            {
                Response.Write("Error " + ess.Message.ToString());
            }

            return PartialView(datos);  

        }
    }
}