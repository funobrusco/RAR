using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_SOST_FLAG_STATO")]
    public partial class ConfigSostFlagStato
    {
        public ConfigSostFlagStato()
        {
            SostDati = new HashSet<SostDati>();
        }

        [Key]
        [Column("FLAG_STATO")]
        [StringLength(1)]
        public string FlagStato { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoNavigation")]
        public virtual ICollection<SostDati> SostDati { get; set; }
    }
}
