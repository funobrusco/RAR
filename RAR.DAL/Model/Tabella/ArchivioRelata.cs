using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ARCHIVIO_RELATA")]
    public partial class ArchivioRelata
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("ID_SCATOLA_RITORNO")]
        public int IdScatolaRitorno { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Required]
        [Column("FLAG_ELAB")]
        [StringLength(1)]
        public string FlagElab { get; set; }
        [Required]
        [Column("FLAG_STATO_LAV")]
        [StringLength(1)]
        public string FlagStatoLav { get; set; }
        [Required]
        [Column("CODE_OP_SCAN")]
        [StringLength(5)]
        public string CodeOpScan { get; set; }
        [Column("DATA_SCAN", TypeName = "datetime")]
        public DateTime DataScan { get; set; }
        [Required]
        [Column("FLAG_TIPO_ACQUISIZIONE")]
        [StringLength(1)]
        public string FlagTipoAcquisizione { get; set; }
        [Column("CODE_OP_MAST")]
        [StringLength(5)]
        public string CodeOpMast { get; set; }
        [Column("DATA_MAST", TypeName = "smalldatetime")]
        public DateTime? DataMast { get; set; }
        [Column("ID_CD")]
        public int? IdCd { get; set; }
        [Column("LOTTO")]
        public byte? Lotto { get; set; }

        [ForeignKey("CodeRacc")]
        [InverseProperty("ArchivioRelata")]
        public virtual RaccPlichiMesso CodeRaccNavigation { get; set; }
        [ForeignKey("FlagElab")]
        [InverseProperty("ArchivioRelata")]
        public virtual ConfigFlagElab FlagElabNavigation { get; set; }
        [ForeignKey("FlagStatoLav")]
        [InverseProperty("ArchivioRelata")]
        public virtual ConfigFlagStatoLav FlagStatoLavNavigation { get; set; }
        [ForeignKey("FlagTipoAcquisizione")]
        [InverseProperty("ArchivioRelata")]
        public virtual ConfigFlagTipoAcquisizione FlagTipoAcquisizioneNavigation { get; set; }
        [ForeignKey("IdScatolaRitorno")]
        [InverseProperty("ArchivioRelata")]
        public virtual ScatolaRitorno IdScatolaRitornoNavigation { get; set; }
    }
}
