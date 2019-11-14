using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_MOTIVO_SCARTO_AR")]
    public partial class ConfigMotivoScartoAr
    {
        [Key]
        [Column("CODICE_MOTIVO")]
        [StringLength(2)]
        public string CodiceMotivo { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
    }
}
