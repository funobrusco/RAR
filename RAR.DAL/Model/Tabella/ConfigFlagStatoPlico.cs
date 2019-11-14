using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_STATO_PLICO")]
    public partial class ConfigFlagStatoPlico
    {
        public ConfigFlagStatoPlico()
        {
            RaccPlichiMesso = new HashSet<RaccPlichiMesso>();
        }

        [Key]
        [Column("FLAG_STATO_PLICO")]
        [StringLength(1)]
        public string FlagStatoPlico { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoPlicoNavigation")]
        public virtual ICollection<RaccPlichiMesso> RaccPlichiMesso { get; set; }
    }
}
