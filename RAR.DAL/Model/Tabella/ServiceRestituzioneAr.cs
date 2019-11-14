using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SERVICE_RESTITUZIONE_AR")]
    public partial class ServiceRestituzioneAr
    {
        [Column("ID_AR")]
        public int IdAr { get; set; }
        [Column("ID_CD_SCATOLA")]
        public int IdCdScatola { get; set; }
        [Required]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }

        [ForeignKey("IdCdScatola")]
        [InverseProperty("ServiceRestituzioneAr")]
        public virtual ServiceRestituzioneCdScatola IdCdScatolaNavigation { get; set; }
    }
}
