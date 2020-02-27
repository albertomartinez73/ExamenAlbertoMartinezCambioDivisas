using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Models
{
    public partial class Rates
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Rate { get; set; }
        
    }
}