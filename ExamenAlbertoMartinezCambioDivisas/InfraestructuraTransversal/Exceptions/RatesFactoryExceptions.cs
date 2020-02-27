using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class RatesFactoryExceptions : Exception
    {
        public RatesFactoryExceptions() : base() { }
        public RatesFactoryExceptions(string message) : base(message) { }
        public RatesFactoryExceptions(string message, Exception innerException) : base(message, innerException) { }
    }
}