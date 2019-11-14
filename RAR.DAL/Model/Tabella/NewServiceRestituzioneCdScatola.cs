using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("NEW_SERVICE_RESTITUZIONE_CD_SCATOLA")]
    public partial class NewServiceRestituzioneCdScatola
    {
        [Column("ID_CD_SCATOLA")]
        public int IdCdScatola { get; set; }
        [Column("ID_CD")]
        public int IdCd { get; set; }
        [Required]
        [Column("PROGRESSIVO_SCATOLA")]
        [StringLength(12)]
        public string ProgressivoScatola { get; set; }
    }
}
