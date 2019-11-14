using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SOST_DATI")]
    public partial class SostDati
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Required]
        [Column("FLAG_STATO")]
        [StringLength(1)]
        public string FlagStato { get; set; }
        [Column("DATA_INVIO", TypeName = "smalldatetime")]
        public DateTime DataInvio { get; set; }
        [Required]
        [Column("CODE_OP_INVIO")]
        [StringLength(5)]
        public string CodeOpInvio { get; set; }
        [Column("DATA_SCAN", TypeName = "smalldatetime")]
        public DateTime? DataScan { get; set; }
        [Column("CODE_OP_SCAN")]
        [StringLength(5)]
        public string CodeOpScan { get; set; }
        [Column("ID_SCATOLA")]
        public int? IdScatola { get; set; }
        [Required]
        [Column("FLAG_ELAB")]
        [StringLength(1)]
        public string FlagElab { get; set; }
        [Column("CODICE_ESITO")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
        [Column("N_COPIE")]
        public int NCopie { get; set; }
        [Required]
        [Column("FLAG_INCOMPLETO")]
        [StringLength(1)]
        public string FlagIncompleto { get; set; }
        [Required]
        [Column("FLAG_SOSPESO")]
        [StringLength(1)]
        public string FlagSospeso { get; set; }
        [Column("TIPO_ANOMALIA")]
        [StringLength(2)]
        public string TipoAnomalia { get; set; }

        [ForeignKey("FlagStato")]
        [InverseProperty("SostDati")]
        public virtual ConfigSostFlagStato FlagStatoNavigation { get; set; }
        [ForeignKey("IdScatola")]
        [InverseProperty("SostDati")]
        public virtual SostScatola IdScatolaNavigation { get; set; }
        [ForeignKey("TipoAnomalia")]
        [InverseProperty("SostDati")]
        public virtual ConfigTipoAnomalia TipoAnomaliaNavigation { get; set; }
    }
}
