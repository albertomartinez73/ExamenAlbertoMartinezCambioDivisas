using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Factory;
using Newtonsoft.Json;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository
{
    public class RatesRepository : GenericRepository<Rates>, IRatesRespository
    {
        IRateFactory factory = new RateFactory();
        public override async Task CargarDatos()
        {
            using var cliente = new HttpClient();
            try
            {

                var response = cliente.GetAsync("http://quiet-stone-2094.herokuapp.com/rates.json").Result;
                string contenido = response.Content.ReadAsStringAsync().Result;
                var ListaJsonRates = Conversor.DeserializeJson(contenido);

                Table.RemoveRange(Table);

                ListaJsonRates.ForEach(x => factory.CreateRate(x));
                Table.AddRange(factory.ListaRates());

                await Context.SaveChangesAsync();



            }
            catch (HttpRequestException)
            {
            }
            catch (Exception e)
            {
                throw new RatesRepositoryException("Error en RatesRepository ", e);
            }

        }
    }
}