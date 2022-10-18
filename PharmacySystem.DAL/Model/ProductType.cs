using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Model
{
    [Table("ProductType")]
    public class ProductType
    {
        [Column(TypeName = "nchar")]
        [Required]
        [StringLength(15)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductTypeId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        [Required]
        public string ProductTypeName { get; set; }
    }
}
