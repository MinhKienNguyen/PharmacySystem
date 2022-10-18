using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Model
{
    [Table("Product")]
    public class Product
    {
        [Column(TypeName = "nchar")]
        [Required]
        [StringLength(15)]
        public string ProductTypeId { get; set; }

        [Column(TypeName = "nchar")]
        [StringLength(15)]
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProductId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(500)]
        [Required]
        public string ProductName { get; set; }

        [Column(TypeName = "nchar")]
        [Required]
        [StringLength(15)]
        public string UnitId { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        [Required]
        public string Pharmaceutical { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        [Required]
        public string Concentrations { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(1000)]
        [Required]
        public string Manufacturer { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        [Required]
        public string CountryManufacture { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int Quantity { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int EntryPrice { get; set; }

        [Column(TypeName = "int")]
        [Required]
        public int ExportPrice { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(4000)]
        public string Remark { get; set; }

    }
}
