using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_CODICE_ESITO")]
    public partial class ConfigCodiceEsito
    {
        [Key]
        [Column("CODICE_ESITO")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
    }
}
