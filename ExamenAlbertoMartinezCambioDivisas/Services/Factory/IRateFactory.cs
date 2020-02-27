using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.Models;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public interface IRateFactory
    {
        List<Rates> ListaRates();
        void CreateRate(Rates rate);
    }
}
