using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamenAlbertoMartinezCambioDivisas.Models;
using ExamenAlbertoMartinezCambioDivisas.Models.ViewModel;

namespace ExamenAlbertoMartinezCambioDivisas.Services.Repository.TransactionsRepository
{
    public interface ITransactionsRepository : IGenericRepository<Transactions>
    {
        List<ListadoPorSkuVM> ListadoSku();
        IQueryable<Transactions> TransactionsPorSku(string sku);
    }
}
