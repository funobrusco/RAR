using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_TIPO_SCATOLA")]
    public partial class ConfigFlagTipoScatola
    {
        public ConfigFlagTipoScatola()
        {
            Scatola = new HashSet<Scatola>();
        }

        [Key]
        [Column("FLAG_TIPO_SCATOLA")]
        [StringLength(1)]
        public string FlagTipoScatola { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagTipoScatolaNavigation")]
        public virtual ICollection<Scatola> Scatola { get; set; }
    }
}
