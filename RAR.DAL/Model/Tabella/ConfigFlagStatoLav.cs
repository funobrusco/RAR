using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_STATO_LAV")]
    public partial class ConfigFlagStatoLav
    {
        public ConfigFlagStatoLav()
        {
            ArchivioRelata = new HashSet<ArchivioRelata>();
        }

        [Key]
        [Column("FLAG_STATO_LAV")]
        [StringLength(1)]
        public string FlagStatoLav { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoLavNavigation")]
        public virtual ICollection<ArchivioRelata> ArchivioRelata { get; set; }
    }
}
