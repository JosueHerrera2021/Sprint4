using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sprint4;

namespace Sprint4.Controllers
{
    //CODIGO DE REQUISITO #139 DE SPRINT #4
    public class HuespedesController : Controller
    {
        private ProyectoISOHotelEntities db = new ProyectoISOHotelEntities();

        // GET: Huespedes
        public ActionResult Index()
        {
            return View(db.Huespeds.ToList());
        }

        // GET: Huespedes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huesped huesped = db.Huespeds.Find(id);
            if (huesped == null)
            {
                return HttpNotFound();
            }
            return View(huesped);
        }

        // GET: Huespedes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Huespedes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_Huesped,Nombre,Apellido,Habitacion,Edificio")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                db.Huespeds.Add(huesped);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(huesped);
        }

        // GET: Huespedes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huesped huesped = db.Huespeds.Find(id);
            if (huesped == null)
            {
                return HttpNotFound();
            }
            return View(huesped);
        }

        // POST: Huespedes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_Huesped,Nombre,Apellido,Habitacion,Edificio")] Huesped huesped)
        {
            if (ModelState.IsValid)
            {
                db.Entry(huesped).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(huesped);
        }

        // GET: Huespedes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Huesped huesped = db.Huespeds.Find(id);
            if (huesped == null)
            {
                return HttpNotFound();
            }
            return View(huesped);
        }

        // POST: Huespedes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Huesped huesped = db.Huespeds.Find(id);
            db.Huespeds.Remove(huesped);
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
