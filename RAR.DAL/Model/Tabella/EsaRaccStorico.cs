using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ESA_RACC_STORICO")]
    public partial class EsaRaccStorico
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("ID_FILE_NAME")]
        public int IdFileName { get; set; }
        [Column("ID_DISPACCIO_OUT")]
        public int? IdDispaccioOut { get; set; }
        [Required]
        [Column("PROGRESSIVO_UTENTE")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
        [Column("DATA_LOAD_DATI", TypeName = "smalldatetime")]
        public DateTime? DataLoadDati { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Required]
        [Column("DESTINATARIO")]
        [StringLength(88)]
        public string Destinatario { get; set; }
        [Required]
        [Column("CODE_CAP_DEST")]
        [StringLength(5)]
        public string CodeCapDest { get; set; }
        [Required]
        [Column("LOC_DEST")]
        [StringLength(44)]
        public string LocDest { get; set; }
        [Required]
        [Column("VIA_DEST")]
        [StringLength(44)]
        public string ViaDest { get; set; }
        [Column("CODICE_ESITO")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Required]
        [Column("FLAG_FONTE_ESITO")]
        [StringLength(1)]
        public string FlagFonteEsito { get; set; }
        [Column("CODICE_MOTIVO")]
        [StringLength(2)]
        public string CodiceMotivo { get; set; }
        [Column("FLAG_AR_DATA")]
        [StringLength(1)]
        public string FlagArData { get; set; }
        [Column("FILE_NAME_AR")]
        [StringLength(16)]
        public string FileNameAr { get; set; }
        [Column("DA_TIMBRO")]
        [StringLength(1)]
        public string DaTimbro { get; set; }
        [Column("INDICATIVO_FESTIVO")]
        [StringLength(1)]
        public string IndicativoFestivo { get; set; }
    }
}
