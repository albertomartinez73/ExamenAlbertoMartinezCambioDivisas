using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class TransactionsFactoryExceptions : Exception
    {
        public TransactionsFactoryExceptions() : base() { }
        public TransactionsFactoryExceptions(string message) : base(message) { }
        public TransactionsFactoryExceptions(string message, Exception innerException) : base(message, innerException) { }
    }
}