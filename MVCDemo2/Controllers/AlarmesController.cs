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
    public class AlarmesController : Controller
    {
        private Sample3Entities db = new Sample3Entities();

        // GET: Alarmes
        public ActionResult Index()
        {
            var alarmes = db.Alarmes.Include(a => a.Contrato);
            return View(alarmes.ToList());
        }


        // GET: Contratos/AlarmesdoContrato/5
        public ActionResult AlarmesdoContrato(int? contratoid)
        {
            if (contratoid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Falta implementar o filtro de contratos apenas do cliente de id passado no parametro
            List<Alarme> alarme = db.Alarmes.Where(x => x.ContratoId == contratoid).ToList();
            
            //List<Contrato> contrato = db.Contratos.Where (x => x.ClienteId == id) ;

            if (alarme.Count == 0)
            {
                ViewBag.Mensagem = "Não encontrado alarmes para o contrato " +    contratoid;

                return View("NaoEncontrado");
            }
            //Contrato contrato = db.Contratos.Where(x => x.Id == id).First();
            //Não tenho ainda ...Contrato contrato = db.Contratos.Where(x => x.c == id).First();

            //Não tenho ainda ...Cliente cliente = db.Clientes.Where(x => x.Id == contrato.ClienteId).First();

            //ViewBag.Nome = cliente.Nome;
            //ViewBag.Data = contrato.Data;
            
 

            return View(alarme);
        }





        // GET: Alarmes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return HttpNotFound();
            }
            return View(alarme);
        }

        // GET: Alarmes/Create
        public ActionResult Create()
        {
            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Dados");
            return View();
        }

        // POST: Alarmes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,EnderecoInstalacao,DataInstalacao,ContratoId")] Alarme alarme)
        {
            if (ModelState.IsValid)
            {
                db.Alarmes.Add(alarme);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Dados", alarme.ContratoId);
            return View(alarme);
        }

        // GET: Alarmes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Dados", alarme.ContratoId);
            return View(alarme);
        }

        // POST: Alarmes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,EnderecoInstalacao,DataInstalacao,ContratoId")] Alarme alarme)
        {
            if (ModelState.IsValid)
            {
                db.Entry(alarme).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContratoId = new SelectList(db.Contratos, "Id", "Dados", alarme.ContratoId);
            return View(alarme);
        }

        // GET: Alarmes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alarme alarme = db.Alarmes.Find(id);
            if (alarme == null)
            {
                return HttpNotFound();
            }
            return View(alarme);
        }

        // POST: Alarmes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Alarme alarme = db.Alarmes.Find(id);
            db.Alarmes.Remove(alarme);
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
