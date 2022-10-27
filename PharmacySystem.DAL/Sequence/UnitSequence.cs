using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PharmacySystem.DAL.Sequence
{
    public class UnitSequence
    {
        [Column("Unit_Sequence", TypeName = "int")]
        [Key]
        public int Unit_Sequence { get; set; }
    }
}
