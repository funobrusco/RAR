using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("gs_DATI_IMG_AR")]
    public partial class GsDatiImgAr
    {
        [Key]
        [Column("ID_DATI")]
        public int IdDati { get; set; }
        [Column("NUM_SCATOLA")]
        public int NumScatola { get; set; }
        [Column("NUM_LOTTO")]
        public int NumLotto { get; set; }
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("PROGRESSIVO_UTENTE")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Required]
        [Column("FLAG_SCARTO")]
        [StringLength(1)]
        public string FlagScarto { get; set; }
        [Required]
        [Column("FLAG_STATO")]
        [StringLength(1)]
        public string FlagStato { get; set; }
        [Required]
        [Column("TIPO_ANOMALIA")]
        [StringLength(1)]
        public string TipoAnomalia { get; set; }
        [Required]
        [Column("FLAG_SOSTITUTIVO")]
        [StringLength(1)]
        public string FlagSostitutivo { get; set; }
        [Column("DATA_ARCHIVIAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataArchiviazione { get; set; }
        [Column("NOME_CD_ARCHIVIO")]
        [StringLength(30)]
        public string NomeCdArchivio { get; set; }
        [Column("FLAG_MATCH_ESA_RACC")]
        [StringLength(1)]
        public string FlagMatchEsaRacc { get; set; }
        [Column("FLAG_MATCH_TRACC")]
        [StringLength(1)]
        public string FlagMatchTracc { get; set; }
        [Column("DATA_LOAD", TypeName = "smalldatetime")]
        public DateTime DataLoad { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Required]
        [Column("FLAG_REC_DATA_NOT")]
        [StringLength(1)]
        public string FlagRecDataNot { get; set; }
    }
}
