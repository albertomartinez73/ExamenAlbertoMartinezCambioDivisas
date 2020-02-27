using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Models.ViewModel
{
    public class ListadoPorSkuVM
    {
        [Key]
        public string Sku { get; set; }
        public decimal SumaAmounts { get; set; }
        public string Moneda { get; set; }
    }
}