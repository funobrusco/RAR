using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_SOST_FLAG_STATO_SCATOLA")]
    public partial class ConfigSostFlagStatoScatola
    {
        public ConfigSostFlagStatoScatola()
        {
            SostScatola = new HashSet<SostScatola>();
        }

        [Column("FLAG_STATO_SCATOLA")]
        [StringLength(1)]
        public string FlagStatoScatola { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoScatolaNavigation")]
        public virtual ICollection<SostScatola> SostScatola { get; set; }
    }
}
