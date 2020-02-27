using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public class RateFactory : IRateFactory
    {
        private Rates Rates;
        public List<Rates> ListadoRates { get; set; } = new List<Rates>();
        public void CreateRate(Rates rate)
        {
            try
            {
                this.Rates = new Rates
                {
                    From = rate.From,
                    To = rate.To,
                    Rate = rate.Rate
                };

                this.ListadoRates.Add(this.Rates);

            }
            catch (Exception e)
            {
                throw new RatesFactoryExceptions("Error en RatesFactory ", e);
            }
        }

        public List<Rates> ListaRates()
        {
            return this.ListadoRates;
        }
    }
}