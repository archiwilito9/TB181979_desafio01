using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TB181979_desafio01.Models;

namespace TB181979_desafio01.Controllers
{
    public class TipoTransaccionsController : Controller
    {
        private banco db = new banco();

        // GET: TipoTransaccions
        public ActionResult Index()
        {
            return View(db.TipoTransaccion.ToList());
        }

        // GET: TipoTransaccions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // GET: TipoTransaccions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTransaccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Tipo_Transaccion")] TipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.TipoTransaccion.Add(tipoTransaccion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTransaccion);
        }

        // GET: TipoTransaccions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: TipoTransaccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Tipo_Transaccion")] TipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTransaccion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTransaccion);
        }

        // GET: TipoTransaccions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            if (tipoTransaccion == null)
            {
                return HttpNotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: TipoTransaccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTransaccion tipoTransaccion = db.TipoTransaccion.Find(id);
            db.TipoTransaccion.Remove(tipoTransaccion);
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
