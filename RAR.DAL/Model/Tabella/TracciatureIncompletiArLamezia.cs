using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("TRACCIATURE_INCOMPLETI_AR_LAMEZIA")]
    public partial class TracciatureIncompletiArLamezia
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("CODICE_DISPACCIO")]
        [StringLength(12)]
        public string CodiceDispaccio { get; set; }
        [Column("DATA_LAVORAZIONE_CMP", TypeName = "smalldatetime")]
        public DateTime DataLavorazioneCmp { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
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
        [Column("FLAG_PROD_REPORT")]
        [StringLength(1)]
        public string FlagProdReport { get; set; }
        [Column("DATA_PROD_REPORT", TypeName = "smalldatetime")]
        public DateTime? DataProdReport { get; set; }
        [Required]
        [Column("FLAG_INCOMPLETI")]
        [StringLength(1)]
        public string FlagIncompleti { get; set; }
    }
}
