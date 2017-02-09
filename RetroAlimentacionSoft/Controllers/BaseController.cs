using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models;
using RetroAlimentacionSoft.Models.utilidades;
namespace RetroAlimentacionSoft.Controllers
{
    public class BaseController : Controller
    {
        //con este constructor lo retornamos a la vista de _MenuDeslis
        public BaseController()
        {
            ViewBag.Menu = CreaMenus();
        }

        private IList<MenusSelecto> CreaMenus()
        {
            List<MenusSelecto> datos = new List<MenusSelecto>();
            //Validamos que la session no este vacia
            if(System.Web.HttpContext.Current.Session["usuario"] != null)
            {
                string usuario = System.Web.HttpContext.Current.Session["usuario"].ToString();
                var contextoBanco = new BaseDatosContext();

                //Sacamos los menus desde la base de datos en funcion a la nomina logeada
                var des = from d in contextoBanco.cat_menu
                          join m in contextoBanco.menu_roles on d.id_menu equals m.id_menu
                          join c in contextoBanco.Cat_roles on m.id_rol equals c.id_rol
                          join f in contextoBanco.UsuarioRol on c.id_rol equals f.id_rol
                          where f.Nomina.Contains(usuario)
                          select new
                          {
                              d.Nombre,
                              d.Link
                          };

                //var menus = new List<MenusSelecto>{
                //    new MenusSelecto{ Link="ada", Nombre="" },
                //    new MenusSelecto{ Link="ada", Nombre="" }
                //};

                
                foreach (var ds in des)
                {
                    datos.Add(new MenusSelecto() { Link = ds.Link, Nombre = ds.Nombre });
                }
            }
            

            return datos;

        }
    }
}