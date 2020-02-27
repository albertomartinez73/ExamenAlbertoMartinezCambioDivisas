using ExamenAlbertoMartinezCambioDivisas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExamenAlbertoMartinezCambioDivisas.InfraestructuraTransversal.Exceptions;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Factory
{
    public class TransactionFactory : ITransactionsFactory
    {
        private Transactions Transactions;
        public List<Transactions> ListadoTransanctions { get; set; } = new List<Transactions>();
        public void CreateTransaction(Transactions transaction)
        {
            try
            {
                this.Transactions = new Transactions
                {
                    Sku = transaction.Sku,
                    Currency = transaction.Currency,
                    Amount = transaction.Amount
                };

                this.ListadoTransanctions.Add(this.Transactions);

            }
            catch (Exception e)
            {
                throw new TransactionsFactoryExceptions("Error en TransactionsFactory ", e);
            }
        }

        public List<Transactions> ListaTransactions()
        {
            return this.ListadoTransanctions;
        }
    }
}