using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_SOTTO_ESITO")]
    public partial class ConfigFlagSottoEsito
    {
        public ConfigFlagSottoEsito()
        {
            RaccPlichiMesso = new HashSet<RaccPlichiMesso>();
        }

        [Key]
        [Column("FLAG_SOTTO_ESITO")]
        [StringLength(2)]
        public string FlagSottoEsito { get; set; }
        [Required]
        [Column("FLAG_ESITO")]
        [StringLength(2)]
        public string FlagEsito { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }

        [ForeignKey("FlagEsito")]
        [InverseProperty("ConfigFlagSottoEsito")]
        public virtual ConfigFlagEsito FlagEsitoNavigation { get; set; }
        [InverseProperty("FlagSottoEsitoNavigation")]
        public virtual ICollection<RaccPlichiMesso> RaccPlichiMesso { get; set; }
    }
}
