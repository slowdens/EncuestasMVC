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
    public class ValorCalificacionsController : Controller
    {
        private BaseDatosContext db = new BaseDatosContext();

        // GET: ValorCalificacions
        public async Task<ActionResult> Index()
        {
            return View(await db.ValorCalificacion.ToListAsync());
        }

        // GET: ValorCalificacions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorCalificacion valorCalificacion = await db.ValorCalificacion.FindAsync(id);
            if (valorCalificacion == null)
            {
                return HttpNotFound();
            }
            return View(valorCalificacion);
        }

        // GET: ValorCalificacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValorCalificacions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdEstatus,Estatus,MayorQue,MenorQue")] ValorCalificacion valorCalificacion)
        {
            if (ModelState.IsValid)
            {
                db.ValorCalificacion.Add(valorCalificacion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(valorCalificacion);
        }

        // GET: ValorCalificacions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorCalificacion valorCalificacion = await db.ValorCalificacion.FindAsync(id);
            if (valorCalificacion == null)
            {
                return HttpNotFound();
            }
            return View(valorCalificacion);
        }

        // POST: ValorCalificacions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdEstatus,Estatus,MayorQue,MenorQue")] ValorCalificacion valorCalificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valorCalificacion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(valorCalificacion);
        }

        // GET: ValorCalificacions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorCalificacion valorCalificacion = await db.ValorCalificacion.FindAsync(id);
            if (valorCalificacion == null)
            {
                return HttpNotFound();
            }
            return View(valorCalificacion);
        }

        // POST: ValorCalificacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ValorCalificacion valorCalificacion = await db.ValorCalificacion.FindAsync(id);
            db.ValorCalificacion.Remove(valorCalificacion);
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
    }
}
