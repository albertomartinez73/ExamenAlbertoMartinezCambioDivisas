using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExamenAlbertoMartinezCambioDivisas.Models.ValidationMetadata
{
    public class TransactionsMetadata
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo SKU no puede estar vacío.")]
        [DisplayName("SKU")]
        public string Sku { get; set; }

        [Required(ErrorMessage = "El campo Amount no puede estar vacío.")]
        [DisplayName("Amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "El campo Currency no puede estar vacío.")]
        [DisplayName("Currency")]
        public string Currency { get; set; }
    }
    [MetadataType(typeof(TransactionsMetadata))]
    public partial class Transactions
    {
    }
}