using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("MESSO_CODICI_LIVORNO")]
    public partial class MessoCodiciLivorno
    {
        [Key]
        [Column("PROGRESSIVO_UTENTE")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("CODICE_FISCALE")]
        [StringLength(17)]
        public string CodiceFiscale { get; set; }
        [Column("FLAG_TIPO_PERSONA")]
        [StringLength(1)]
        public string FlagTipoPersona { get; set; }
        [Column("ID_UDR")]
        public int? IdUdr { get; set; }
    }
}
