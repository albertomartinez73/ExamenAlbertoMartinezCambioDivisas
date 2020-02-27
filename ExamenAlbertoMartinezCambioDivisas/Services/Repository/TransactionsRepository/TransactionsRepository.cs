using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Models.ViewModel;
using ExamenAlbertoMartinezCambioDivisas.Services.Factory;
using ExamenAlbertoMartinezCambioDivisas.Services.JsonConverterService;
using ExamenAlbertoMartinezCambioDivisas.Services.MonedaConverter;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository
{
    public class TransactionsRepository : GenericRepository<Transactions>, ITransactionsRepository
    {
        private IMonedaConversor conversorMoneda;

        public TransactionsRepository()
        {
            this.conversorMoneda = new MonedaConversor();
        }
        public override async Task CargarDatos()
        {
            ITransactionsFactory factory = new TransactionFactory();
            using var cliente = new HttpClient();
            try
            {

                var response = cliente.GetAsync("http://quiet-stone-2094.herokuapp.com/transactions.json").Result;
                string contenido = response.Content.ReadAsStringAsync().Result;
                var listaJsonTransactions = Conversor.DeserializeJson(contenido);

                Table.RemoveRange(Table);

                listaJsonTransactions.ForEach(x => factory.CreateTransaction(x));
                Table.AddRange(factory.ListaTransactions());

                await Context.SaveChangesAsync();

                //this.conversorMoneda.CargarDatos(Context.Rates.ToList());

            }
            catch (HttpRequestException)
            {
                //this.conversorMoneda.CargarDatos(Context.Rates.ToList());
            }
            catch (Exception e)
            {
                throw  new TransactionRepositoryException("Error en TransactionRepository ", e);
            }
        }

        public List<ListadoPorSkuVM> ListadoSku()
        {
            var nuevaListaSkus = new List<ListadoPorSkuVM>();

            var query = from j in Table
                group j by j.Sku into Skus
                select new
                {
                    Sku = Skus.Key,
                    SumaAmounts = Skus.Sum(x => x.Amount),
                    //aqui usariamos el conversor de monedas
                    //SumaAmounts = Skus.Sum(x=> this.conversorMoneda.ConversorMoneda(x.Amount, x.Currency, "EUR")),
                    Moneda = "EUR"

                };

            foreach (var item in query)
            {
                var nuevoSku = new ListadoPorSkuVM
                {
                    Sku =  item.Sku,
                    SumaAmounts = item.SumaAmounts,
                    Moneda = "EUR"

                };

                nuevaListaSkus.Add(nuevoSku);

            }

            return nuevaListaSkus;
        }

        public IQueryable<Transactions> TransactionsPorSku(string sku)
        {
            var querySkuPor = from j in Table where j.Sku == sku select j;

            //foreach (var item in querySkuPor)
            //{
            //    item.Amount = this.conversorMoneda.ConversorMoneda(item.Amount, item.Currency, "EUR");
            //    item.Currency = "EUR";

            //}
            
            return querySkuPor;
        }
    }
}