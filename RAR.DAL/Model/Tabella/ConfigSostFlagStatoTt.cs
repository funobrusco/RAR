using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_SOST_FLAG_STATO_TT")]
    public partial class ConfigSostFlagStatoTt
    {
        [Key]
        [Column("FLAG_STATO_TT")]
        [StringLength(1)]
        public string FlagStatoTt { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }
    }
}
