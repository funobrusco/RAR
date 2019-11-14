using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("PATENTI_LIBRETTI")]
    public partial class PatentiLibretti
    {
        [Required]
        [Column("FLAG")]
        [StringLength(1)]
        public string Flag { get; set; }
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("MOTIVO_RESTITUZIONE")]
        [StringLength(2)]
        public string MotivoRestituzione { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime DataElab { get; set; }
    }
}
