using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_MOTIVI_RESTITUZIONE")]
    public partial class ConfigMotiviRestituzione
    {
        [Key]
        [Column("CODICE")]
        [StringLength(2)]
        public string Codice { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
    }
}
