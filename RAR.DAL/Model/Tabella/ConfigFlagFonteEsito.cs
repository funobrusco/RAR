using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_FONTE_ESITO")]
    public partial class ConfigFlagFonteEsito
    {
        [Key]
        [Column("FLAG_FONTE_ESITO")]
        [StringLength(1)]
        public string FlagFonteEsito { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
    }
}
