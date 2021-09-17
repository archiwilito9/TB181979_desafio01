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
    public class CuentaBancariasController : Controller
    {
        private banco db = new banco();

        // GET: CuentaBancarias
        public ActionResult Index()
        {
            var cuentaBancaria = db.CuentaBancaria.Include(c => c.Clientes).Include(c => c.TipoCuentaBancarias);
            return View(cuentaBancaria.ToList());
        }

        // GET: CuentaBancarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // GET: CuentaBancarias/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Cliente, "id", "nombres");
            ViewBag.TipoCuentaBancariaId = new SelectList(db.TipoCuentaBancaria, "id", "Tipo_Transaccion");
            return View();
        }

        // POST: CuentaBancarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ClienteId,Moneda,TipoCuentaBancariaId")] CuentaBancaria cuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.CuentaBancaria.Add(cuentaBancaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Cliente, "id", "nombres", cuentaBancaria.ClienteId);
            ViewBag.TipoCuentaBancariaId = new SelectList(db.TipoCuentaBancaria, "id", "Tipo_Transaccion", cuentaBancaria.TipoCuentaBancariaId);
            return View(cuentaBancaria);
        }

        // GET: CuentaBancarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "id", "nombres", cuentaBancaria.ClienteId);
            ViewBag.TipoCuentaBancariaId = new SelectList(db.TipoCuentaBancaria, "id", "Tipo_Transaccion", cuentaBancaria.TipoCuentaBancariaId);
            return View(cuentaBancaria);
        }

        // POST: CuentaBancarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ClienteId,Moneda,TipoCuentaBancariaId")] CuentaBancaria cuentaBancaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cuentaBancaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Cliente, "id", "nombres", cuentaBancaria.ClienteId);
            ViewBag.TipoCuentaBancariaId = new SelectList(db.TipoCuentaBancaria, "id", "Tipo_Transaccion", cuentaBancaria.TipoCuentaBancariaId);
            return View(cuentaBancaria);
        }

        // GET: CuentaBancarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            if (cuentaBancaria == null)
            {
                return HttpNotFound();
            }
            return View(cuentaBancaria);
        }

        // POST: CuentaBancarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CuentaBancaria cuentaBancaria = db.CuentaBancaria.Find(id);
            db.CuentaBancaria.Remove(cuentaBancaria);
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
