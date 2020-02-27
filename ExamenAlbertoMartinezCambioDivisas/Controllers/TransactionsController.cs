using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExamenAlbertoMartinezCambioDivisas.DAL;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository;

namespace ExamenAlbertoMartinezCambioDivisas.Controllers
{
    public class TransactionsController : BaseController
    {
        //private CambioDivisasContext db = new CambioDivisasContext();
        private ITransactionsRepository transactionsRepository = null;

        public TransactionsController()
        {
            this.transactionsRepository = new TransactionsRepository();;
        }

        public TransactionsController(ITransactionsRepository repositorio)
        {
            this.transactionsRepository = repositorio;
        }

        // GET: Transactions
        public async Task<ActionResult> Index()
        {
            await this.transactionsRepository.CargarDatos();
            return View(await this.transactionsRepository.GetAll());
        }

        // GET: Transactions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactions = await this.transactionsRepository.GetById(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Transactions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Sku,Amount,Currency")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                this.transactionsRepository.Insert(transactions);
                await this.transactionsRepository.Save();
                return RedirectToAction("Index");
            }

            return View(transactions);
        }

        // GET: Transactions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactions = await this.transactionsRepository.GetById(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Sku,Amount,Currency")] Transactions transactions)
        {
            if (ModelState.IsValid)
            {
                this.transactionsRepository.Update(transactions);
                await this.transactionsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(transactions);
        }

        // GET: Transactions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var transactions = await this.transactionsRepository.GetById(id);
            if (transactions == null)
            {
                return HttpNotFound();
            }
            return View(transactions);
        }

        // POST: Transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await this.transactionsRepository.Delete(id);
            await this.transactionsRepository.Save();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
