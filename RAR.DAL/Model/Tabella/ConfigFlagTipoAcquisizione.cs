using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_TIPO_ACQUISIZIONE")]
    public partial class ConfigFlagTipoAcquisizione
    {
        public ConfigFlagTipoAcquisizione()
        {
            ArchivioRelata = new HashSet<ArchivioRelata>();
        }

        [Key]
        [Column("FLAG_TIPO_ACQUISIZIONE")]
        [StringLength(1)]
        public string FlagTipoAcquisizione { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagTipoAcquisizioneNavigation")]
        public virtual ICollection<ArchivioRelata> ArchivioRelata { get; set; }
    }
}
