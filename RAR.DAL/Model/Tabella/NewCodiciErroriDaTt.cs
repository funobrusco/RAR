using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("NEW_CODICI_ERRORI_da_TT")]
    public partial class NewCodiciErroriDaTt
    {
        [Key]
        [Column("Codice_Errore")]
        [StringLength(3)]
        public string CodiceErrore { get; set; }
        [Required]
        [StringLength(200)]
        public string Descrizione { get; set; }
    }
}
