using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions
{
    public class TransactionRepositoryException : Exception
    {
        public TransactionRepositoryException() : base() { }
        public TransactionRepositoryException(string message) : base(message) { }
        public TransactionRepositoryException(string message, Exception innerException) : base(message, innerException) { }
    }
}