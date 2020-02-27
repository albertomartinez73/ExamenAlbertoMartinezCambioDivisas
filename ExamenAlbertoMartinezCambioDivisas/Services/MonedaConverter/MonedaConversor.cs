using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository;
using ExamenAlbertoMartinezCambioDivisas.Services.Repository.RatesRepository;

namespace ExamenAlbertoMartinezCambioDivisas.Services.MonedaConverter
{
    public class MonedaConversor : IMonedaConversor
    {
        private List<Rates> ListadoRates;
        private decimal multiplicacion;

        public void CargarDatos(List<Rates> listadoRates)
        {
            this.ListadoRates = listadoRates;
        }

        public decimal ConversorMoneda(decimal amount, string currency, string to)
        {

            // AQUI HABRIA QUE IMPLEMENTAR EL GRAFO DE DIJKSTRA
            foreach (var item in this.ListadoRates)
            {
                
                if (item.From.Equals(currency) && item.To.Equals(to))
                {
                     this.multiplicacion = amount * item.Rate;
                }
                else
                {
                    this.multiplicacion = amount;
                }
            }

            return this.multiplicacion;
        }
    }
}