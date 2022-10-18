using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Model
{
    [Table("InvoiceDetail")]
    public class InvoiceDetails
    {
        [Column(TypeName = "nchar", Order ='1')]
        [Required]
        [StringLength(15)]
        [Key]
        public string InvoiceNo { get; set; }

        [Column(TypeName = "nchar", Order = '2')]
        [StringLength(10)]
        [Required]
        [Key]
        public string ProductId { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Quantity { get; set; }
    }
}
