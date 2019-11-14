using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_STATO_LAV_AR")]
    public partial class ConfigFlagStatoLavAr
    {
        public ConfigFlagStatoLavAr()
        {
            RaccAr = new HashSet<RaccAr>();
        }

        [Key]
        [Column("FLAG_STATO_LAV_AR")]
        [StringLength(1)]
        public string FlagStatoLavAr { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagStatoLavArNavigation")]
        public virtual ICollection<RaccAr> RaccAr { get; set; }
    }
}
