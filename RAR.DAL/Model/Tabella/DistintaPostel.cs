using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("DISTINTA_POSTEL")]
    public partial class DistintaPostel
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
        [StringLength(50)]
        public string FileName { get; set; }
        [Required]
        [Column("ID_UTENTE")]
        [StringLength(8)]
        public string IdUtente { get; set; }
        [Required]
        [Column("NOME_LOTTO")]
        [StringLength(8)]
        public string NomeLotto { get; set; }
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
        [StringLength(20)]
        public string NumeroDistinta { get; set; }
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime? DataSpedizione { get; set; }
        [Column("DATA_FILE_RISPOSTA", TypeName = "smalldatetime")]
        public DateTime? DataFileRisposta { get; set; }
        [Column("FLAG_NUMERO_INVIO")]
        public int FlagNumeroInvio { get; set; }
        [Column("DATA_ULTIMA_INTER_SCONOSCIUTI", TypeName = "smalldatetime")]
        public DateTime? DataUltimaInterSconosciuti { get; set; }
        [Column("DATA_COMUNICAZIONE_ESITI", TypeName = "smalldatetime")]
        public DateTime? DataComunicazioneEsiti { get; set; }
        [Column("DATA_COMUNICAZIONE_ESITI_PREC", TypeName = "smalldatetime")]
        public DateTime? DataComunicazioneEsitiPrec { get; set; }
        [Column("FLAG_TIPO_DOC")]
        [StringLength(2)]
        public string FlagTipoDoc { get; set; }
        [Required]
        [Column("FLAG_STATO_TT")]
        [StringLength(1)]
        public string FlagStatoTt { get; set; }
        [Required]
        [Column("FLAG_STATO_TERR")]
        [StringLength(1)]
        public string FlagStatoTerr { get; set; }
        [Column("NUMERO_RIFERIMENTO")]
        [StringLength(5)]
        public string NumeroRiferimento { get; set; }
        [Column("GRAMMATURA")]
        [StringLength(5)]
        public string Grammatura { get; set; }
    }
}
