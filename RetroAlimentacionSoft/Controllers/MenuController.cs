using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models;

namespace RetroAlimentacionSoft.Controllers
{
    public class MenuController : BaseController
    {
        private BaseDatosContext db = new BaseDatosContext();

        // GET: Menu
        public async Task<ActionResult> Index()
        {
            if (System.Web.HttpContext.Current.Session["usuario"] == null)
            {
                return RedirectToAction("Index", "Ingresar"); 
            }
            ViewBag.ssesion = System.Web.HttpContext.Current.Session["usuario"].ToString();
            return View(await db.cat_menu.ToListAsync());
            
        }

        // GET: Menu/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_menu cat_menu = await db.cat_menu.FindAsync(id);
            if (cat_menu == null)
            {
                return HttpNotFound();
            }
            return View(cat_menu);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_menu,Nombre,Link,Padre")] cat_menu cat_menu)
        {
            if (ModelState.IsValid)
            {
                db.cat_menu.Add(cat_menu);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cat_menu);
        }

        // GET: Menu/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_menu cat_menu = await db.cat_menu.FindAsync(id);
            if (cat_menu == null)
            {
                return HttpNotFound();
            }
            return View(cat_menu);
        }

        // POST: Menu/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_menu,Nombre,Link,Padre")] cat_menu cat_menu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cat_menu).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cat_menu);
        }

        // GET: Menu/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cat_menu cat_menu = await db.cat_menu.FindAsync(id);
            if (cat_menu == null)
            {
                return HttpNotFound();
            }
            return View(cat_menu);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            cat_menu cat_menu = await db.cat_menu.FindAsync(id);
            db.cat_menu.Remove(cat_menu);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult EliminarMenu(int id)
        {
            int i = id;
            ViewBag.error = "";
            try
            {
                var dad = (from m in db.cat_menu
                           where m.id_menu == id
                           select m).SingleOrDefault();
                db.cat_menu.Remove(dad);
                db.SaveChanges();
                ViewBag.mensaje = "Exito";                
            }catch(Exception es)
            {
                ViewBag.error =  es.Message.ToString();
                ViewBag.mensaje = "No fue exito";
            }
            
            
            
            return PartialView();
        }
    }
}
