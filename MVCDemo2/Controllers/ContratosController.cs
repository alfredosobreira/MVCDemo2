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
    public class ContratosController : Controller
    {
        private Sample3Entities db = new Sample3Entities();

        // GET: Contratos Recebo id do Cliente e vusco contratos
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                var contratos = db.Contratos.Include(c => c.Cliente);
                return View(contratos.ToList());
            }
            else
            {
                //Pego todos os contratos de um tal cliente, passando id do cliente
                List<Contrato> contrato = db.Contratos.Where(x => x.ClienteId == id).ToList();
               
                // Pego o nome do Cliente pra passar pra a página informando que nao achei contratos daquele nome de cliente
                Cliente cliente = db.Clientes.Where(x => x.Id == id).First();
                

                if (contrato.Count == 0)
                {
                    ViewBag.Nome = "Não há contratos para o cliente " +  cliente.Nome ;
                    //return View("NaoEncontrado");
                    return View(contrato.ToList());

                }
                else
                {
                    ViewBag.Nome = "Detalhes do cliente" +  cliente.Nome;    
                    return View(contrato.ToList());
                }


               }
        }

        // GET: ContratosdoCliente/
        public ActionResult ContratosdoCliente(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Falta implementar o filtro de contratos apenas do cliente de id passado no parametro
            List<Contrato> contrato = db.Contratos.Where(x => x.ClienteId == id).ToList();
            Cliente cliente = db.Clientes.Where(x => x.Id == id).First();
            ViewBag.Nome = cliente.Nome;

            if (contrato.Count == 0)
            {
                return View("ContratodoClientenaoEncontrado");
            }

            return View(contrato);
        }




        // GET: Contratos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }



        //// GET: Contratos/AlarmesdoContrato/5
        //public ActionResult AlarmesdoContrato(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    //Falta implementar o filtro de contratos apenas do cliente de id passado no parametro
        //    List<Alarme> alarme = db.Alarmes.Where(x => x.ContratoId == id).ToList();

        //    //List<Contrato> contrato = db.Contratos.Where (x => x.ClienteId == id) ;

        //    //customers.Where(c => c.City == "London")

        //    Cliente cliente = db.Clientes.Where(x => x.Id == id).First();
        //    Contrato contrato = db.Contratos.Where(x => x.Id == id).First();
        //    ViewBag.Nome = cliente.Nome;
        //    ViewBag.Data = contrato.Data;

        //    if (alarme.Count == 0)
        //    {
        //        return View("AlarmeNaoEncontrado");
        //    }

        //    return View(alarme);
        //}



        // GET: Contratos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Dados,Data,ClienteId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contratos.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", contrato.ClienteId);
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", contrato.ClienteId);
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Dados,Data,ClienteId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", contrato.ClienteId);
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contratos.Find(id);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contrato contrato = db.Contratos.Find(id);
            db.Contratos.Remove(contrato);
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
