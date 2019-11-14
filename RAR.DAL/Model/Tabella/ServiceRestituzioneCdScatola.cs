using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SERVICE_RESTITUZIONE_CD_SCATOLA")]
    public partial class ServiceRestituzioneCdScatola
    {
        public ServiceRestituzioneCdScatola()
        {
            ServiceRestituzioneAr = new HashSet<ServiceRestituzioneAr>();
        }

        [Column("ID_CD_SCATOLA")]
        public int IdCdScatola { get; set; }
        [Column("ID_CD")]
        public int IdCd { get; set; }
        [Column("PROGRESSIVO_SCATOLA")]
        public int ProgressivoScatola { get; set; }

        [ForeignKey("IdCd")]
        [InverseProperty("ServiceRestituzioneCdScatola")]
        public virtual ServiceRestituzioneCd IdCdNavigation { get; set; }
        [InverseProperty("IdCdScatolaNavigation")]
        public virtual ICollection<ServiceRestituzioneAr> ServiceRestituzioneAr { get; set; }
    }
}
