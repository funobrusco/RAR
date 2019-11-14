using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SCATOLA_RITORNO")]
    public partial class ScatolaRitorno
    {
        public ScatolaRitorno()
        {
            ArchivioRelata = new HashSet<ArchivioRelata>();
        }

        [Key]
        [Column("ID_SCATOLA_RITORNO")]
        public int IdScatolaRitorno { get; set; }
        [Column("NUM_SCATOLA_RITORNO")]
        public int NumScatolaRitorno { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Column("DIM")]
        public int Dim { get; set; }
        [Column("DIM_MAX")]
        public int DimMax { get; set; }
        [Required]
        [Column("FLAG_STATO_SCATOLA_RITORNO")]
        [StringLength(1)]
        public string FlagStatoScatolaRitorno { get; set; }
        [Required]
        [Column("COMPUTER_NAME")]
        [StringLength(50)]
        public string ComputerName { get; set; }
        [Required]
        [Column("FLAG_TIPO_SCATOLA_RITORNO")]
        [StringLength(1)]
        public string FlagTipoScatolaRitorno { get; set; }
        [Column("DISPACCIO_OUT")]
        [StringLength(12)]
        public string DispaccioOut { get; set; }

        [ForeignKey("FlagStatoScatolaRitorno")]
        [InverseProperty("ScatolaRitorno")]
        public virtual ConfigFlagStatoScatolaRitorno FlagStatoScatolaRitornoNavigation { get; set; }
        [ForeignKey("FlagTipoScatolaRitorno")]
        [InverseProperty("ScatolaRitorno")]
        public virtual ConfigFlagTipoScatolaRitorno FlagTipoScatolaRitornoNavigation { get; set; }
        [InverseProperty("IdScatolaRitornoNavigation")]
        public virtual ICollection<ArchivioRelata> ArchivioRelata { get; set; }
    }
}
