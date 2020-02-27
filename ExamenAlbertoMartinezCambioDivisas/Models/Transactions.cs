using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Models
{
    public partial class Transactions
    {
        public int Id { get; set; }
        public string Sku { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}