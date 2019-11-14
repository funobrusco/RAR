using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_TIPO_PERSONA")]
    public partial class ConfigFlagTipoPersona
    {
        [Key]
        [Column("FLAG_TIPO_PERSONA")]
        [StringLength(1)]
        public string FlagTipoPersona { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }
    }
}
