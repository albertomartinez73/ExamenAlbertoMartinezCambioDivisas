using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Models
{
    public class RatesMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo From no puede estar vacío.")]
        [DisplayName("From")]
        public string From { get; set; }

        [Required(ErrorMessage = "El campo To no puede estar vacío.")]
        [DisplayName("To")]
        public string To { get; set; }

        [Required(ErrorMessage = "El campo Rate no puede estar vacío.")]
        [DisplayName("Rate")]
        public decimal Rate { get; set; }

    }

    [MetadataType(typeof(RatesMetadata))]
    public partial class Rates
    {
    }
}