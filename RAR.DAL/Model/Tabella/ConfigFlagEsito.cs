using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_ESITO")]
    public partial class ConfigFlagEsito
    {
        public ConfigFlagEsito()
        {
            ConfigFlagSottoEsito = new HashSet<ConfigFlagSottoEsito>();
            RaccPlichiMesso = new HashSet<RaccPlichiMesso>();
        }

        [Key]
        [Column("FLAG_ESITO")]
        [StringLength(2)]
        public string FlagEsito { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagEsitoNavigation")]
        public virtual ICollection<ConfigFlagSottoEsito> ConfigFlagSottoEsito { get; set; }
        [InverseProperty("FlagEsitoNavigation")]
        public virtual ICollection<RaccPlichiMesso> RaccPlichiMesso { get; set; }
    }
}
