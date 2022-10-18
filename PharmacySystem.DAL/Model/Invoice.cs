using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Model
{
    [Table("Invoice")]
    public class Invoice
    {
        [Column(TypeName = "nchar")]
        [Required]
        [StringLength(15)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string InvoiceNo { get; set; }

        [Column(TypeName = "nchar")]
        [StringLength(15)]
        [Required]
        public string CustomerId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int TotalAmount { get; set; }
    }
}
