using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_STATO_COMUNICAZIONE")]
    public partial class ConfigFlagStatoComunicazione
    {
        public ConfigFlagStatoComunicazione()
        {
            RaccPlichiMesso = new HashSet<RaccPlichiMesso>();
        }

        [Column("FLAG_STATO_COMUNICAZIONE")]
        [StringLength(1)]
        public string FlagStatoComunicazione { get; set; }
        [Column("FLAG_ESITO")]
        [StringLength(2)]
        public string FlagEsito { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("Flag")]
        public virtual ICollection<RaccPlichiMesso> RaccPlichiMesso { get; set; }
    }
}
