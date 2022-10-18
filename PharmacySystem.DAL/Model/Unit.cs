using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Model
{
    [Table("Unit")]
    public class Unit
    {
        [Column(TypeName = "nchar")]
        [Required]
        [StringLength(15)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string UnitId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Required]
        public string UnitName { get; set; }
    }
}
