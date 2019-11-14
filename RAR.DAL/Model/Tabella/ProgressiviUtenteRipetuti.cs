using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("PROGRESSIVI_UTENTE_RIPETUTI")]
    public partial class ProgressiviUtenteRipetuti
    {
        [Column("progressivo_utente")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
    }
}
