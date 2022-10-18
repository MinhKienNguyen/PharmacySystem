using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Model
{
    [Table("Customer")]
    public class Customer
    {
        [Column(TypeName = "nchar")]
        [Required]
        [StringLength(15)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string CustomerId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        [Required]
        public string CustomerName { get; set; }

        [Column(TypeName = "nchar")]
        [StringLength(12)]
        [Required]
        public string Phone { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        [Required]
        public string Address { get; set; }
    }
}
