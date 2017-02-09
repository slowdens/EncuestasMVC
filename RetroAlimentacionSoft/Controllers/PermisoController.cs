using RetroAlimentacionSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models.utilidades;


namespace RetroAlimentacionSoft.Controllers
{
    public class PermisoController : BaseController
    {


        BaseDatosContext db = new BaseDatosContext();
        // GET: Permiso
        public ActionResult Index()
        {

            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            var items = db.Cat_roles;
            var vm = new VistaRol();
            vm.rol = items;
            return View(vm);
        }


        public PartialViewResult agregar(string seperados,string idrol)
        {
            string []arr = seperados.Split('!');
            int idMenu, iidrol;
            if(seperados !="" && idrol!="")
            {
                foreach (var s in arr)
                {
                    // varible que tiene informacion 
                    iidrol = int.Parse(idrol);

                    if (s != "")
                    {
                        idMenu = int.Parse(s);
                        menu_roles imenuroles = new menu_roles
                        {
                            id_menu = idMenu,
                            id_rol = iidrol
                        };
                        db.menu_roles.Add(imenuroles);
                        db.SaveChanges();
                    }


                }
 
            }
                      
            return PartialView();
        }


        public PartialViewResult GetMenu(string rol)
        {
            List<MenuControl> datos = new List<MenuControl>();
            List<PasoCadenas> cade = new List<PasoCadenas>();
            try
            {
                int introl = int.Parse(rol);
                int intCantidad=0;     

                /*
                 * query
                    select * 
                    from cat_menu 
                    where id_menu 
                    not in (
                    select id_menu 
                    from  
                    menu_roles
                     where id_rol=2) 

                 */

                var combo = from Cat_menu in db.cat_menu
                             where !
                             (from Menu_roles in db.menu_roles
                              where Menu_roles.id_rol == introl
                              select new{
                                  Menu_roles.id_menu
                              }).Contains(new { id_menu = (System.Int32?)Cat_menu.id_menu })
                             select new
                             {
                                 id_menu = Cat_menu.id_menu,
                                 Nombre = Cat_menu.Nombre
                             };
                                         

                foreach (var ds in combo)
                {                    
                    datos.Add(new MenuControl() { id_menu = ds.id_menu, Nombre = ds.Nombre });
                }                
            }
            catch (Exception ess)
            {
                Response.Write("Error " + ess.Message.ToString());
            }

            return PartialView(datos);  

        }


        public ActionResult Lista()
        {
            List<UnionMenuRol> dato = new List<UnionMenuRol>();
            //validamos la session
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            
            
            var s = from mr in db.menu_roles
                    select new
                    {
                        mr.cat_menu.Nombre,
                        mr.cat_menu.Link,
                        rol = mr.Cat_roles.Nombre,
                        mr.id_menu_rol

                    };


           foreach(var ss in s)
           {
               dato.Add(new UnionMenuRol() { Id_menu_rol= ss.id_menu_rol, Nombre = ss.Nombre,Link=ss.Link,Rol=ss.rol });
           }
            return View(dato);
        }


        public ActionResult Regresar()
        {
            return RedirectToAction("Index", "Permiso");
        }

        public PartialViewResult Eliminar(string id)
        {
           if(!string.IsNullOrEmpty(id))
           {
               int i = int.Parse(id);
               var dato = (from ds in db.menu_roles
                          where ds.id_menu_rol == i
                          select ds).FirstOrDefault();


               db.menu_roles.Remove(dato);
               db.SaveChanges();
               ViewBag.valor = "Exito";

           }
           else
           {
               ViewBag.valor = "Sin exito";
           }
            
            return PartialView();
        }
        public ActionResult Asignar()
        {
            //validamos la session
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            return View();
        }


        public ActionResult CrearUsuarioRol()
        {
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();

            /*Tomamos query de los roles*/
            //var items = db.Cat_roles;
            //var vm = new VistaRol();
            //vm.rol = items;

            var items = db.Cat_roles;
            var vm = new ViewmodelNominaRol();
            vm.rol = items;
            return View(vm);
        }

        [HttpPost]
        public ActionResult UsuarioAgregar(string Nomina, string rol)
        {
            int idrol = int.Parse(rol);
            var quer = from user in db.UsuarioRol
                       where user.Nomina == Nomina
                       select user;
            int contador = quer.Count();
            if(quer.Count()==0)
            {
                //No existe vamos a agregar ese dato.
                
                UsuarioRol usuriorol = new UsuarioRol
                {
                    id_rol = idrol,
                    Nomina = Nomina
                };

                db.UsuarioRol.Add(usuriorol);
                db.SaveChanges();
                ViewBag.resultado = "Agregado";
            }
            else
            {
                ViewBag.resultado = "TieneAsignacion";
            }

            return View();
        }


        public ActionResult direccion()
        {
            return RedirectToAction("Asignar", "Permiso");
        }

        public ActionResult ListadoUsuarioRol()
        {
            //validamos la session
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar");
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            
            List<NominaRol> dato = new List<NominaRol>();
            var ds = from use in db.UsuarioRol
                     select new
                     {
                         Nomina=use.Nomina,
                         Rol=use.Cat_roles.Nombre
                         
                     };

            foreach (var ss in ds)
            {
                dato.Add(new NominaRol() { Nomina = ss.Nomina, Rol = ss.Rol });
            }
            return View(dato);            
        }


        public PartialViewResult EliminarNomina(string nomina)
        {
            if(!string.IsNullOrEmpty(nomina))
            {
                var s = (from rol in db.UsuarioRol
                        where rol.Nomina == nomina
                        select rol).SingleOrDefault();

                db.UsuarioRol.Remove(s);
                db.SaveChanges();
                ViewBag.valor = "Exito";

            }
            else
            {
                ViewBag.valor = "SinExito";
            }
            return PartialView();
        }



    }
}