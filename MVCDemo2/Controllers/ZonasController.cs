using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCDemo2.Models;

namespace MVCDemo2.Controllers
{
    public class ZonasController : Controller
    {
        private Sample3Entities db = new Sample3Entities();

        // GET: Zonas
        public ActionResult Index()
        {
            var zonas = db.Zonas.Include(z => z.Alarme);
            return View(zonas.ToList());
        }

        // GET: Zonas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // GET: Zonas/Create
        public ActionResult Create()
        {
            ViewBag.AlarmeId = new SelectList(db.Alarmes, "Id", "Nome");
            return View();
        }

        // POST: Zonas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Nome,AlarmeId")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Zonas.Add(zona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlarmeId = new SelectList(db.Alarmes, "Id", "Nome", zona.AlarmeId);
            return View(zona);
        }

        // GET: Zonas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlarmeId = new SelectList(db.Alarmes, "Id", "Nome", zona.AlarmeId);
            return View(zona);
        }

        // POST: Zonas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Nome,AlarmeId")] Zona zona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlarmeId = new SelectList(db.Alarmes, "Id", "Nome", zona.AlarmeId);
            return View(zona);
        }

        // GET: Zonas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return HttpNotFound();
            }
            return View(zona);
        }

        // POST: Zonas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zona zona = db.Zonas.Find(id);
            db.Zonas.Remove(zona);
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
