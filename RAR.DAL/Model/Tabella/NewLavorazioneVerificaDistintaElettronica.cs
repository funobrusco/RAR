using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Lavorazione_Verifica_Distinta_Elettronica")]
    public partial class NewLavorazioneVerificaDistintaElettronica
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_ELENCO_FILEOUTPUT")]
        public int? IdElencoFileoutput { get; set; }
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("IDENTIFICATIVO_FLUSSO_INVIO")]
        [StringLength(20)]
        public string IdentificativoFlussoInvio { get; set; }
        [Column("ESITO_INVIO")]
        [StringLength(1)]
        public string EsitoInvio { get; set; }
        [Column("ERRORE")]
        [StringLength(100)]
        public string Errore { get; set; }
        [Column("TIPOLOGIA_CONTESTAZIONE")]
        [StringLength(1)]
        public string TipologiaContestazione { get; set; }
        [Column("DATA_INVIO", TypeName = "datetime")]
        public DateTime? DataInvio { get; set; }
        [Column("DATA_RISPOSTA", TypeName = "datetime")]
        public DateTime? DataRisposta { get; set; }
        [Column("PROGRESSIVO_RECORD")]
        [StringLength(7)]
        public string ProgressivoRecord { get; set; }
        [Column("IDENTIFICATIVO_FILE_CONTROLLATO")]
        public int? IdentificativoFileControllato { get; set; }
    }
}
