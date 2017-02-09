using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RetroAlimentacionSoft.Models;

namespace RetroAlimentacionSoft.Controllers
{
    public class ValorCalificacionController : Controller
    {
        private BaseDatosContext db = new BaseDatosContext();

        // GET: ValorCalificacion
        public ActionResult Index()
        {
            return View(db.ValorCalificacion.ToList());
        }

        // GET: ValorCalificacion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorCalificacion valorCalificacion = db.ValorCalificacion.Find(id);
            if (valorCalificacion == null)
            {
                return HttpNotFound();
            }
            return View(valorCalificacion);
        }

        // GET: ValorCalificacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValorCalificacion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstatus,Estatus,MayorQue,MenorQue")] ValorCalificacion valorCalificacion)
        {
            if (ModelState.IsValid)
            {
                db.ValorCalificacion.Add(valorCalificacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valorCalificacion);
        }

        // GET: ValorCalificacion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorCalificacion valorCalificacion = db.ValorCalificacion.Find(id);
            if (valorCalificacion == null)
            {
                return HttpNotFound();
            }
            return View(valorCalificacion);
        }

        // POST: ValorCalificacion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstatus,Estatus,MayorQue,MenorQue")] ValorCalificacion valorCalificacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valorCalificacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valorCalificacion);
        }

        // GET: ValorCalificacion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValorCalificacion valorCalificacion = db.ValorCalificacion.Find(id);
            if (valorCalificacion == null)
            {
                return HttpNotFound();
            }
            return View(valorCalificacion);
        }

        // POST: ValorCalificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValorCalificacion valorCalificacion = db.ValorCalificacion.Find(id);
            db.ValorCalificacion.Remove(valorCalificacion);
            db.SaveChanges();
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
