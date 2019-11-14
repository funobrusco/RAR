using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("DISPACCIO_OUT")]
    public partial class DispaccioOut
    {
        [Key]
        [Column("ID_DISPACCIO_OUT")]
        public int IdDispaccioOut { get; set; }
        [Column("CODE_CLIENTE")]
        [StringLength(2)]
        public string CodeCliente { get; set; }
        [Column("CODE_CONCESSIONE")]
        [StringLength(3)]
        public string CodeConcessione { get; set; }
        [Column("CODE_DIPENDENZE")]
        [StringLength(3)]
        public string CodeDipendenze { get; set; }
        [Required]
        [Column("NUM_PEZZI")]
        [StringLength(5)]
        public string NumPezzi { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime DataElab { get; set; }
        [Required]
        [Column("CODICE_OPERATORE")]
        [StringLength(50)]
        public string CodiceOperatore { get; set; }
        [Column("CODE_RACC_SPEDIZ")]
        [StringLength(15)]
        public string CodeRaccSpediz { get; set; }
        [Required]
        [Column("PROVINCIA")]
        [StringLength(50)]
        public string Provincia { get; set; }
        [Required]
        [Column("FLAG_STATO_LAVORAZIONI")]
        [StringLength(1)]
        public string FlagStatoLavorazioni { get; set; }
        [Column("CODICE_SCATOLA")]
        [StringLength(12)]
        public string CodiceScatola { get; set; }
        [Column("DATA_LAVORAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataLavorazione { get; set; }
        [Column("CODICE_SITO")]
        [StringLength(10)]
        public string CodiceSito { get; set; }
        [Column("DATA_ACCT_SCATOLA", TypeName = "smalldatetime")]
        public DateTime? DataAcctScatola { get; set; }
    }
}
