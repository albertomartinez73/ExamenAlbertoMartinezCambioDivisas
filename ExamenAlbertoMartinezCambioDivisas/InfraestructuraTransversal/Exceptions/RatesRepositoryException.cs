using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class RatesRepositoryException : Exception
    {
        public RatesRepositoryException() : base() { }
        public RatesRepositoryException(string message) : base(message) { }
        public RatesRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}