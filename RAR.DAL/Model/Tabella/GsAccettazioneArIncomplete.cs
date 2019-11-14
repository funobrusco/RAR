using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("gs_ACCETTAZIONE_AR_INCOMPLETE")]
    public partial class GsAccettazioneArIncomplete
    {
        [Key]
        [Column("CODICE_DISP_ARRIVO")]
        [StringLength(12)]
        public string CodiceDispArrivo { get; set; }
        [Column("NUM_SCATOLA")]
        public int NumScatola { get; set; }
        [Column("N_AR_DA_FILE")]
        public int NArDaFile { get; set; }
        [Column("N_AR_DA_COUNT")]
        public int NArDaCount { get; set; }
        [Column("DATA_ACCETTAZ_DISPACCIO", TypeName = "smalldatetime")]
        public DateTime DataAccettazDispaccio { get; set; }
        [Required]
        [Column("CODE_OPERATORE")]
        [StringLength(5)]
        public string CodeOperatore { get; set; }

        [ForeignKey("NumScatola")]
        [InverseProperty("GsAccettazioneArIncomplete")]
        public virtual GsRiepilogoScatole NumScatolaNavigation { get; set; }
    }
}
