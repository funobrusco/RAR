using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("QUALITA_AR_VERONA")]
    public partial class QualitaArVerona
    {
        [Key]
        [Column("PROGR_UTENTE")]
        [StringLength(20)]
        public string ProgrUtente { get; set; }
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("DATA_POSTALIZZAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataPostalizzazione { get; set; }
        [Column("CODE_RACC_SERVIZIO")]
        [StringLength(12)]
        public string CodeRaccServizio { get; set; }
        [Column("NUM_CARTOLINE")]
        public int? NumCartoline { get; set; }
        [Column("DATA_CONS_RACC", TypeName = "smalldatetime")]
        public DateTime? DataConsRacc { get; set; }
        [Column("DATA_INVIO_RACC", TypeName = "smalldatetime")]
        public DateTime? DataInvioRacc { get; set; }
        [Column("DATA_ARRIVO_RACC", TypeName = "smalldatetime")]
        public DateTime? DataArrivoRacc { get; set; }
        [Column("DATA_CONS_SERVICE", TypeName = "smalldatetime")]
        public DateTime? DataConsService { get; set; }
        [Column("AN_ASSENZA_DATA_MANUALE")]
        [StringLength(1)]
        public string AnAssenzaDataManuale { get; set; }
        [Column("AN_ASSENZA_DATA_GULLER")]
        [StringLength(1)]
        public string AnAssenzaDataGuller { get; set; }
        [Column("AN_DATA_DIFF_TIMBRO_MAN")]
        [StringLength(1)]
        public string AnDataDiffTimbroMan { get; set; }
        [Column("AN_ASSENZA_FIRMA_PLETTERE")]
        [StringLength(1)]
        public string AnAssenzaFirmaPlettere { get; set; }
        [Column("AN_ASSENZA_FIRMA_RIC")]
        [StringLength(1)]
        public string AnAssenzaFirmaRic { get; set; }
        [Column("AN_ASSENZA_QUALITA_FIRMATARIO")]
        [StringLength(1)]
        public string AnAssenzaQualitaFirmatario { get; set; }
        [Column("DATA_LOAD", TypeName = "smalldatetime")]
        public DateTime DataLoad { get; set; }
        [Required]
        [Column("FILE_NAME_XLS")]
        [StringLength(70)]
        public string FileNameXls { get; set; }
        [Required]
        [Column("FLAG_PROD_REPORT_TEMPI_LAV")]
        [StringLength(1)]
        public string FlagProdReportTempiLav { get; set; }
        [Column("DATA_PROD_REPORT_TEMPI_LAV", TypeName = "smalldatetime")]
        public DateTime? DataProdReportTempiLav { get; set; }
        [Required]
        [Column("FLAG_PROD_REPORT_QUALITA")]
        [StringLength(1)]
        public string FlagProdReportQualita { get; set; }
        [Column("DATA_PROD_REPORT_QUALITA", TypeName = "smalldatetime")]
        public DateTime? DataProdReportQualita { get; set; }
        [Required]
        [Column("FLAG_MATCH_ESA_RACC")]
        [StringLength(1)]
        public string FlagMatchEsaRacc { get; set; }
        [Column("FLAG_LAV_OLD")]
        [StringLength(1)]
        public string FlagLavOld { get; set; }
        [Column("DATA_LAVORAZIONE_SERVICE", TypeName = "smalldatetime")]
        public DateTime? DataLavorazioneService { get; set; }
        [Column("DATA_LAVORAZIONE_CMP", TypeName = "smalldatetime")]
        public DateTime? DataLavorazioneCmp { get; set; }
        [Column("DATA_LOAD_AR", TypeName = "smalldatetime")]
        public DateTime? DataLoadAr { get; set; }
        [Column("FILE_NAME_AR")]
        [StringLength(16)]
        public string FileNameAr { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
    }
}
