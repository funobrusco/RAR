using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("gs_RIEPILOGO_SCATOLE")]
    public partial class GsRiepilogoScatole
    {
        public GsRiepilogoScatole()
        {
            GsAccettazioneArIncomplete = new HashSet<GsAccettazioneArIncomplete>();
        }

        [Key]
        [Column("NUM_SCATOLA")]
        public int NumScatola { get; set; }
        [Column("TOT_PEZZI_ATTUALE")]
        public int TotPezziAttuale { get; set; }
        [Column("TOT_PEZZI_REST")]
        public int TotPezziRest { get; set; }
        [Column("TOT_PEZZI_SCANSITI")]
        public int TotPezziScansiti { get; set; }
        [Column("TOT_COMPLETE_SOSPESE")]
        public int TotCompleteSospese { get; set; }
        [Required]
        [Column("CMP")]
        [StringLength(10)]
        public string Cmp { get; set; }
        [Required]
        [Column("FLAG_STATO_SCATOLA")]
        [StringLength(1)]
        public string FlagStatoScatola { get; set; }
        [Column("CODE_OPERATORE_ATTUALE")]
        [StringLength(5)]
        public string CodeOperatoreAttuale { get; set; }
        [Column("DATA_CREAZ_SCATOLA", TypeName = "smalldatetime")]
        public DateTime DataCreazScatola { get; set; }
        [Column("CODE_OP_RIPARTIZIONE")]
        [StringLength(5)]
        public string CodeOpRipartizione { get; set; }
        [Column("DATA_INIZIO_RIPARTIZIONE", TypeName = "smalldatetime")]
        public DateTime? DataInizioRipartizione { get; set; }
        [Column("DATA_FINE_RIPARTIZIONE", TypeName = "smalldatetime")]
        public DateTime? DataFineRipartizione { get; set; }
        [Column("CODE_OP_REST_COMPLETE")]
        [StringLength(5)]
        public string CodeOpRestComplete { get; set; }
        [Column("DATA_REST_COMPLETE", TypeName = "smalldatetime")]
        public DateTime? DataRestComplete { get; set; }
        [Column("CODE_OP_SCANSIONE")]
        [StringLength(5)]
        public string CodeOpScansione { get; set; }
        [Column("DATA_INIZIO_SCANSIONE", TypeName = "smalldatetime")]
        public DateTime? DataInizioScansione { get; set; }
        [Column("DATA_FINE_SCANSIONE", TypeName = "smalldatetime")]
        public DateTime? DataFineScansione { get; set; }
        [Column("CODE_OP_ANOMALIA")]
        [StringLength(5)]
        public string CodeOpAnomalia { get; set; }
        [Column("DATA_INIZIO_ANOMALIA", TypeName = "smalldatetime")]
        public DateTime? DataInizioAnomalia { get; set; }
        [Column("DATA_FINE_ANOMALIA", TypeName = "smalldatetime")]
        public DateTime? DataFineAnomalia { get; set; }
        [Column("CODE_OP_REC_DATE")]
        [StringLength(5)]
        public string CodeOpRecDate { get; set; }
        [Column("DATA_INIZIO_REC_DATE", TypeName = "smalldatetime")]
        public DateTime? DataInizioRecDate { get; set; }
        [Column("DATA_FINE_REC_DATE", TypeName = "smalldatetime")]
        public DateTime? DataFineRecDate { get; set; }
        [Column("CODE_OP_ARCHIVIAZIONE")]
        [StringLength(5)]
        public string CodeOpArchiviazione { get; set; }
        [Column("DATA_INIZIO_ARCHIVIAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataInizioArchiviazione { get; set; }
        [Column("DATA_FINE_ARCHIVIAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataFineArchiviazione { get; set; }

        [InverseProperty("NumScatolaNavigation")]
        public virtual ICollection<GsAccettazioneArIncomplete> GsAccettazioneArIncomplete { get; set; }
    }
}
