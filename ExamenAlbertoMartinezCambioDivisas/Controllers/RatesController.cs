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
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository;

namespace ExamenAlbertoMartinezCambioDivisas.Controllers
{
    public class RatesController : BaseController
    {
        //private CambioDivisasContext db = new CambioDivisasContext();
        private IRatesRespository ratesRepository = null;

        public RatesController()
        {
            this.ratesRepository = new RatesRepository();
        }

        public RatesController(IRatesRespository repositorio)
        {
            this.ratesRepository = repositorio;
        }

        // GET: Rates
        public async Task<ActionResult> Index()
        {
            await ratesRepository.CargarDatos();
            return View(await this.ratesRepository.GetAll());
        }

        // GET: Rates/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rates = await this.ratesRepository.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // GET: Rates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rates/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,From,To,Rate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                this.ratesRepository.Insert(rates);
                await this.ratesRepository.Save();
                return RedirectToAction("Index");
            }

            return View(rates);
        }

        // GET: Rates/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rates = await this.ratesRepository.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,From,To,Rate")] Rates rates)
        {
            if (ModelState.IsValid)
            {
                this.ratesRepository.Update(rates);
                await this.ratesRepository.Save();
                return RedirectToAction("Index");
            }
            return View(rates);
        }

        // GET: Rates/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var rates = await this.ratesRepository.GetById(id);
            if (rates == null)
            {
                return HttpNotFound();
            }
            return View(rates);
        }

        // POST: Rates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await this.ratesRepository.Delete(id);
            await this.ratesRepository.Save();
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
