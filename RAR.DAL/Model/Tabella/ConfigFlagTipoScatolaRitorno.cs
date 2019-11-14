using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_TIPO_SCATOLA_RITORNO")]
    public partial class ConfigFlagTipoScatolaRitorno
    {
        public ConfigFlagTipoScatolaRitorno()
        {
            ScatolaRitorno = new HashSet<ScatolaRitorno>();
        }

        [Key]
        [Column("FLAG_TIPO_SCATOLA_RITORNO")]
        [StringLength(1)]
        public string FlagTipoScatolaRitorno { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagTipoScatolaRitornoNavigation")]
        public virtual ICollection<ScatolaRitorno> ScatolaRitorno { get; set; }
    }
}
