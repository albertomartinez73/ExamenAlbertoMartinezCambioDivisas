using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository;

namespace ExamenAlbertoMartinezCambioDivisas.Controllers.Consultas
{
    public class ListadoPorSkuController : Controller
    {
        private IRatesRespository ratesRespository;

        private ITransactionsRepository transactionsRepository;

        public ListadoPorSkuController()
        {
            this.ratesRespository = new RatesRepository();
            this.transactionsRepository = new TransactionsRepository();
        }

        public ListadoPorSkuController(IRatesRespository ratesRespository, ITransactionsRepository transactionsRepository)
        {
            this.ratesRespository = ratesRespository;
            this.transactionsRepository = transactionsRepository;
        }
        // GET: ListadoPorSku
        public async Task<ActionResult> Index()
        {
            await this.ratesRespository.CargarDatos();
            await this.transactionsRepository.CargarDatos();

            var query = this.transactionsRepository.ListadoSku();
            return View( query);
        }

        public ActionResult VerTransacciones(string sku)
        {
            
            var query = this.transactionsRepository.TransactionsPorSku(sku);
            return View(query.ToList());
        }
    }
}