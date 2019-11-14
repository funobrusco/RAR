using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("DISPACCIO_IN")]
    public partial class DispaccioIn
    {
        [Key]
        [Column("ID_DISPACCIO_IN")]
        public int IdDispaccioIn { get; set; }
        [Required]
        [Column("CODE_DISPACCIO_IN")]
        [StringLength(20)]
        public string CodeDispaccioIn { get; set; }
        [Required]
        [Column("NUM_PEZZI")]
        [StringLength(5)]
        public string NumPezzi { get; set; }
        [Required]
        [Column("CODE_OP_DE")]
        [StringLength(3)]
        public string CodeOpDe { get; set; }
        [Column("DATA_DISTINTA", TypeName = "smalldatetime")]
        public DateTime DataDistinta { get; set; }
        [Required]
        [Column("MITTENTE")]
        [StringLength(255)]
        public string Mittente { get; set; }
        [Required]
        [Column("CODE_OPE_CSC")]
        [StringLength(5)]
        public string CodeOpeCsc { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime DataElab { get; set; }
    }
}
