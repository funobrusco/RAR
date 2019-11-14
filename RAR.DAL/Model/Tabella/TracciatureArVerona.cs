using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("TRACCIATURE_AR_VERONA")]
    public partial class TracciatureArVerona
    {
        [Key]
        [Column("PROGR_UTENTE")]
        [StringLength(20)]
        public string ProgrUtente { get; set; }
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("CODE_RACC_SERVIZIO")]
        [StringLength(12)]
        public string CodeRaccServizio { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Column("DATA_INVIO_RACC", TypeName = "smalldatetime")]
        public DateTime? DataInvioRacc { get; set; }
        [Column("DATA_ARR_RACC", TypeName = "smalldatetime")]
        public DateTime? DataArrRacc { get; set; }
        [Column("DATA_LAVORAZIONE_CMP", TypeName = "smalldatetime")]
        public DateTime? DataLavorazioneCmp { get; set; }
        [Required]
        [Column("FLAG_PROD_REPORT_AR_NO_RACC")]
        [StringLength(1)]
        public string FlagProdReportArNoRacc { get; set; }
        [Column("DATA_PROD_REPORT_AR_NO_RACC", TypeName = "smalldatetime")]
        public DateTime? DataProdReportArNoRacc { get; set; }
        [Column("DATA_LOAD_CGE", TypeName = "smalldatetime")]
        public DateTime DataLoadCge { get; set; }
        [Required]
        [Column("FLAG_MATCH_ESA_RACC")]
        [StringLength(1)]
        public string FlagMatchEsaRacc { get; set; }
        [Required]
        [Column("FILE_NAME_XLS")]
        [StringLength(70)]
        public string FileNameXls { get; set; }
        [Required]
        [Column("FLAG_INCOMPLETI")]
        [StringLength(1)]
        public string FlagIncompleti { get; set; }
        [Required]
        [Column("FLAG_LAV_OLD")]
        [StringLength(1)]
        public string FlagLavOld { get; set; }
        [Column("DATA_LAVORAZIONE_SERVICE", TypeName = "smalldatetime")]
        public DateTime? DataLavorazioneService { get; set; }
        [Column("DATA_LOAD_AR", TypeName = "smalldatetime")]
        public DateTime? DataLoadAr { get; set; }
        [Column("FILE_NAME_AR")]
        [StringLength(16)]
        public string FileNameAr { get; set; }
        [Column("ID_DISPACCIO")]
        public int? IdDispaccio { get; set; }
    }
}
