using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_STATO_SCATOLA_RITORNO")]
    public partial class ConfigFlagStatoScatolaRitorno
    {
        public ConfigFlagStatoScatolaRitorno()
        {
            ScatolaAr = new HashSet<ScatolaAr>();
            ScatolaRitorno = new HashSet<ScatolaRitorno>();
        }

        [Column("FLAG_STATO_SCATOLA_RITORNO")]
        [StringLength(1)]
        public string FlagStatoScatolaRitorno { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoScatolaRitornoNavigation")]
        public virtual ICollection<ScatolaAr> ScatolaAr { get; set; }
        [InverseProperty("FlagStatoScatolaRitornoNavigation")]
        public virtual ICollection<ScatolaRitorno> ScatolaRitorno { get; set; }
    }
}
