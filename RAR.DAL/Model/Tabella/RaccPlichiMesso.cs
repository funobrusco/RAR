using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("RACC_PLICHI_MESSO")]
    public partial class RaccPlichiMesso
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("CODICE_ESITO")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Required]
        [Column("CODICE_MOTIVO")]
        [StringLength(2)]
        public string CodiceMotivo { get; set; }
        [Required]
        [Column("DESTINATARIO")]
        [StringLength(88)]
        public string Destinatario { get; set; }
        [Required]
        [Column("CODE_CAP_DEST")]
        [StringLength(5)]
        public string CodeCapDest { get; set; }
        [Required]
        [Column("VIA_DEST")]
        [StringLength(44)]
        public string ViaDest { get; set; }
        [Required]
        [Column("LOC_DEST")]
        [StringLength(44)]
        public string LocDest { get; set; }
        [Required]
        [Column("FLAG_FONTE_ESITO")]
        [StringLength(1)]
        public string FlagFonteEsito { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime DataElab { get; set; }
        [Required]
        [Column("CODE_OPE_DE")]
        [StringLength(5)]
        public string CodeOpeDe { get; set; }
        [Column("DATA_LOAD_DATI", TypeName = "smalldatetime")]
        public DateTime DataLoadDati { get; set; }
        [Required]
        [Column("FLAG_STATO_PLICO")]
        [StringLength(1)]
        public string FlagStatoPlico { get; set; }
        [Column("SCATOLA")]
        public int Scatola { get; set; }
        [Column("LOTTO")]
        public short Lotto { get; set; }
        [Required]
        [Column("FLAG_TIPO_PERSONA")]
        [StringLength(1)]
        public string FlagTipoPersona { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Column("ID_UDR")]
        public int IdUdr { get; set; }
        [Required]
        [Column("FLAG_TIPO_PLICO")]
        [StringLength(1)]
        public string FlagTipoPlico { get; set; }
        [Required]
        [Column("PROGRESSIVO_UTENTE")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Column("CAP_NEW")]
        [StringLength(5)]
        public string CapNew { get; set; }
        [Column("LOC_DEST_NEW")]
        [StringLength(44)]
        public string LocDestNew { get; set; }
        [Column("VIA_DEST_NEW")]
        [StringLength(44)]
        public string ViaDestNew { get; set; }
        [Column("DESTINATARIO_NEW")]
        [StringLength(88)]
        public string DestinatarioNew { get; set; }
        [Column("FLAG_ESITO")]
        [StringLength(2)]
        public string FlagEsito { get; set; }
        [Column("FLAG_SOTTO_ESITO")]
        [StringLength(2)]
        public string FlagSottoEsito { get; set; }
        [Column("DATA_ESITO", TypeName = "smalldatetime")]
        public DateTime? DataEsito { get; set; }
        [Column("DATA_EXPORT", TypeName = "smalldatetime")]
        public DateTime? DataExport { get; set; }
        [Column("DISPACCIO_CMP_CGE")]
        [StringLength(12)]
        public string DispaccioCmpCge { get; set; }
        [Column("ID_CARICAMENTO")]
        public int? IdCaricamento { get; set; }
        [Column("ID_SCATOLA_RITORNO")]
        public int? IdScatolaRitorno { get; set; }
        [Column("DATA_INS_ESITO", TypeName = "smalldatetime")]
        public DateTime? DataInsEsito { get; set; }
        [Column("id_file_name")]
        public int IdFileName { get; set; }
        [Column("ID_MESSO")]
        public int? IdMesso { get; set; }
        [Column("FLAG_CAMBIO_IND")]
        public bool FlagCambioInd { get; set; }
        [Column("DISPACCIO_MESSO")]
        [StringLength(12)]
        public string DispaccioMesso { get; set; }
        [Column("DATA_DISPACCIO_MESSO", TypeName = "smalldatetime")]
        public DateTime? DataDispaccioMesso { get; set; }
        [Required]
        [Column("FLAG_STATO_COMUNICAZIONE")]
        [StringLength(1)]
        public string FlagStatoComunicazione { get; set; }
        [Column("DATA_COMUNICAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataComunicazione { get; set; }
        [Column("CODE_OP_COMUNICAZIONE")]
        [StringLength(5)]
        public string CodeOpComunicazione { get; set; }
        [Column("CF_PIVA")]
        [StringLength(16)]
        public string CfPiva { get; set; }
        [Column("FLAG_IN_CARICO")]
        public bool FlagInCarico { get; set; }
        [Column("CODE_OP_ASS_MESSI")]
        [StringLength(10)]
        public string CodeOpAssMessi { get; set; }
        [Column("DATA_IN_CARICO", TypeName = "smalldatetime")]
        public DateTime? DataInCarico { get; set; }
        [Column("PROGR_INS_ESITO")]
        public int? ProgrInsEsito { get; set; }
        [Column("FLAG_STATO_IND")]
        public bool FlagStatoInd { get; set; }

        [ForeignKey("FlagStatoComunicazione,FlagEsito")]
        [InverseProperty("RaccPlichiMesso")]
        public virtual ConfigFlagStatoComunicazione Flag { get; set; }
        [ForeignKey("FlagEsito")]
        [InverseProperty("RaccPlichiMesso")]
        public virtual ConfigFlagEsito FlagEsitoNavigation { get; set; }
        [ForeignKey("FlagSottoEsito")]
        [InverseProperty("RaccPlichiMesso")]
        public virtual ConfigFlagSottoEsito FlagSottoEsitoNavigation { get; set; }
        [ForeignKey("FlagStatoPlico")]
        [InverseProperty("RaccPlichiMesso")]
        public virtual ConfigFlagStatoPlico FlagStatoPlicoNavigation { get; set; }
        [ForeignKey("Scatola")]
        [InverseProperty("RaccPlichiMesso")]
        public virtual Scatola ScatolaNavigation { get; set; }
        [InverseProperty("CodeRaccNavigation")]
        public virtual ArchivioRelata ArchivioRelata { get; set; }
        [InverseProperty("CodeRaccNavigation")]
        public virtual ImgRelata ImgRelata { get; set; }
        [InverseProperty("CodeRaccNavigation")]
        public virtual RaccAr RaccAr { get; set; }
    }
}
