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
    public class TransaccionesController : Controller
    {
        private banco db = new banco();

        // GET: Transacciones
        public ActionResult Index()
        {
            var transacciones = db.Transacciones.Include(t => t.CuentaBancarias).Include(t => t.TipoTransacciones);
            return View(transacciones.ToList());
        }

        // GET: Transacciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // GET: Transacciones/Create
        public ActionResult Create()
        {
            ViewBag.CuentaBancariaId = new SelectList(db.CuentaBancaria, "id", "Moneda");
            ViewBag.TipoTransaccionId = new SelectList(db.TipoTransaccion, "id", "Tipo_Transaccion");
            return View();
        }

        // POST: Transacciones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Monto,Estado,FechaTransaccion,FechaAplicación,CuentaBancariaId,TipoTransaccionId")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Transacciones.Add(transacciones);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CuentaBancariaId = new SelectList(db.CuentaBancaria, "id", "Moneda", transacciones.CuentaBancariaId);
            ViewBag.TipoTransaccionId = new SelectList(db.TipoTransaccion, "id", "Tipo_Transaccion", transacciones.TipoTransaccionId);
            return View(transacciones);
        }

        // GET: Transacciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            ViewBag.CuentaBancariaId = new SelectList(db.CuentaBancaria, "id", "Moneda", transacciones.CuentaBancariaId);
            ViewBag.TipoTransaccionId = new SelectList(db.TipoTransaccion, "id", "Tipo_Transaccion", transacciones.TipoTransaccionId);
            return View(transacciones);
        }

        // POST: Transacciones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Monto,Estado,FechaTransaccion,FechaAplicación,CuentaBancariaId,TipoTransaccionId")] Transacciones transacciones)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transacciones).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CuentaBancariaId = new SelectList(db.CuentaBancaria, "id", "Moneda", transacciones.CuentaBancariaId);
            ViewBag.TipoTransaccionId = new SelectList(db.TipoTransaccion, "id", "Tipo_Transaccion", transacciones.TipoTransaccionId);
            return View(transacciones);
        }

        // GET: Transacciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transacciones transacciones = db.Transacciones.Find(id);
            if (transacciones == null)
            {
                return HttpNotFound();
            }
            return View(transacciones);
        }

        // POST: Transacciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Transacciones transacciones = db.Transacciones.Find(id);
            db.Transacciones.Remove(transacciones);
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
