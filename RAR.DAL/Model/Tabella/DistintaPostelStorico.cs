using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("DISTINTA_POSTEL_STORICO")]
    public partial class DistintaPostelStorico
    {
        [Key]
        [Column("ID_FILE_NAME")]
        public int IdFileName { get; set; }
        [Required]
        [Column("CODE_UTENTE")]
        [StringLength(8)]
        public string CodeUtente { get; set; }
        [Required]
        [Column("FILE_NAME")]
        [StringLength(28)]
        public string FileName { get; set; }
        [Column("TOT_LETTERE")]
        public int TotLettere { get; set; }
        [Column("DATA_LOAD_DIST_POSTEL", TypeName = "smalldatetime")]
        public DateTime DataLoadDistPostel { get; set; }
        [Required]
        [Column("SOTTO_CODICE_UTENTE")]
        [StringLength(4)]
        public string SottoCodiceUtente { get; set; }
        [Required]
        [Column("NUMERO_DISTINTA")]
        [StringLength(5)]
        public string NumeroDistinta { get; set; }
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime DataSpedizione { get; set; }
        [Column("FLAG_TIPO_DOC")]
        [StringLength(2)]
        public string FlagTipoDoc { get; set; }
    }
}
