using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SERVICE_RESTITUZIONE_CD")]
    public partial class ServiceRestituzioneCd
    {
        public ServiceRestituzioneCd()
        {
            ServiceRestituzioneCdScatola = new HashSet<ServiceRestituzioneCdScatola>();
        }

        [Column("ID_CD")]
        public int IdCd { get; set; }
        [Column("ID_FILE")]
        public int IdFile { get; set; }
        [Column("NUMERO_CD")]
        public int NumeroCd { get; set; }
        [Column("ANNO_RIFERIMENTO")]
        public int AnnoRiferimento { get; set; }

        [ForeignKey("IdFile")]
        [InverseProperty("ServiceRestituzioneCd")]
        public virtual ServiceRestituzioneFile IdFileNavigation { get; set; }
        [InverseProperty("IdCdNavigation")]
        public virtual ICollection<ServiceRestituzioneCdScatola> ServiceRestituzioneCdScatola { get; set; }
    }
}
