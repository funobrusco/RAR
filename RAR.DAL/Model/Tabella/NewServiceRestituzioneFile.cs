using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("NEW_SERVICE_RESTITUZIONE_FILE")]
    public partial class NewServiceRestituzioneFile
    {
        [Key]
        [Column("ID_FILE")]
        public int IdFile { get; set; }
        [Required]
        [Column("NOME_FILE")]
        [StringLength(28)]
        public string NomeFile { get; set; }
        [Required]
        [Column("CODE_CONCESSIONE")]
        [StringLength(3)]
        public string CodeConcessione { get; set; }
        [Required]
        [Column("NOME_VETTORE")]
        [StringLength(50)]
        public string NomeVettore { get; set; }
        [Required]
        [Column("LETTERA_VETTURA")]
        [StringLength(20)]
        public string LetteraVettura { get; set; }
        [Column("TOT_CD")]
        public int TotCd { get; set; }
        [Column("TOT_SCATOLE")]
        public int TotScatole { get; set; }
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime DataSpedizione { get; set; }
        [Column("DATA_CARICAMENTO", TypeName = "smalldatetime")]
        public DateTime DataCaricamento { get; set; }
        [Required]
        [Column("ANNO_RIFERIMENTO")]
        [StringLength(4)]
        public string AnnoRiferimento { get; set; }
        [Required]
        [Column("TESTO_XML", TypeName = "xml")]
        public string TestoXml { get; set; }
        [Column("DATA_RICEZIONE", TypeName = "smalldatetime")]
        public DateTime? DataRicezione { get; set; }
    }
}
