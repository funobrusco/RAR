using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_STATO_SCATOLA")]
    public partial class ConfigFlagStatoScatola
    {
        public ConfigFlagStatoScatola()
        {
            Scatola = new HashSet<Scatola>();
        }

        [Key]
        [Column("FLAG_STATO_SCATOLA")]
        [StringLength(1)]
        public string FlagStatoScatola { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoScatolaNavigation")]
        public virtual ICollection<Scatola> Scatola { get; set; }
    }
}
