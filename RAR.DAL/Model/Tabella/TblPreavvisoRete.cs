using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("TBL_PREAVVISO_RETE")]
    public partial class TblPreavvisoRete
    {
        [Required]
        [Column("FILIALE")]
        [StringLength(50)]
        public string Filiale { get; set; }
        [Required]
        [Column("CAP")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Required]
        [Column("LOC_DEST")]
        [StringLength(50)]
        public string LocDest { get; set; }
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
    }
}
