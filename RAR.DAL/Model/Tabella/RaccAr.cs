using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("RACC_AR")]
    public partial class RaccAr
    {
        [Required]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("ID_SCATOLA_RITORNO")]
        public int? IdScatolaRitorno { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Required]
        [Column("FLAG_STATO_LAV_AR")]
        [StringLength(1)]
        public string FlagStatoLavAr { get; set; }
        [Column("CODE_OP_SCAN")]
        [StringLength(5)]
        public string CodeOpScan { get; set; }
        [Column("DATA_SCAN", TypeName = "datetime")]
        public DateTime? DataScan { get; set; }
        [Column("CODE_OP_MAST")]
        [StringLength(5)]
        public string CodeOpMast { get; set; }
        [Column("DATA_MAST", TypeName = "smalldatetime")]
        public DateTime? DataMast { get; set; }
        [Column("ID_CD")]
        public int? IdCd { get; set; }
        [Column("LOTTO")]
        public byte? Lotto { get; set; }
        [Required]
        [Column("FLAG_ESITO")]
        [StringLength(2)]
        public string FlagEsito { get; set; }
        [Column("DATA_ESITO", TypeName = "smalldatetime")]
        public DateTime DataEsito { get; set; }
        [Key]
        [Column("CODE_AR")]
        [StringLength(12)]
        public string CodeAr { get; set; }
        [Column("DATA_INVIO", TypeName = "smalldatetime")]
        public DateTime DataInvio { get; set; }
        [Required]
        [Column("CODE_OP_AR")]
        [StringLength(5)]
        public string CodeOpAr { get; set; }
        [Column("DATA_DEPOSITO", TypeName = "smalldatetime")]
        public DateTime? DataDeposito { get; set; }

        [ForeignKey("CodeRacc")]
        [InverseProperty("RaccAr")]
        public virtual RaccPlichiMesso CodeRaccNavigation { get; set; }
        [ForeignKey("FlagStatoLavAr")]
        [InverseProperty("RaccAr")]
        public virtual ConfigFlagStatoLavAr FlagStatoLavArNavigation { get; set; }
        [ForeignKey("IdScatolaRitorno")]
        [InverseProperty("RaccAr")]
        public virtual ScatolaAr IdScatolaRitornoNavigation { get; set; }
    }
}
