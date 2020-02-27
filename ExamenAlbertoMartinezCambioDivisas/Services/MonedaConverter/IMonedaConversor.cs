using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.MonedaConverter
{
    public interface IMonedaConversor
    {
        decimal ConversorMoneda(decimal amount, string currency, string to);
        void CargarDatos(List<Rates> listadoRates);
    }
}
