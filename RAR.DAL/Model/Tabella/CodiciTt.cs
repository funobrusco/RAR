using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CODICI_TT")]
    public partial class CodiciTt
    {
        [Required]
        [Column("BANCA")]
        [StringLength(50)]
        public string Banca { get; set; }
        [Key]
        [Column("CODICE_INVIO")]
        [StringLength(12)]
        public string CodiceInvio { get; set; }
        [Column("DATA_ACCETTAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataAccettazione { get; set; }
        [Column("UFFICIO_ACCETTAZIONE")]
        [StringLength(50)]
        public string UfficioAccettazione { get; set; }
        [Required]
        [Column("ESITO")]
        [StringLength(2)]
        public string Esito { get; set; }
        [Column("UFFICIO1")]
        [StringLength(50)]
        public string Ufficio1 { get; set; }
        [Column("UFFICIO2")]
        [StringLength(50)]
        public string Ufficio2 { get; set; }
        [Column("DATA_ESITO", TypeName = "smalldatetime")]
        public DateTime? DataEsito { get; set; }
        [Required]
        [Column("FLAG")]
        [StringLength(1)]
        public string Flag { get; set; }
        [Required]
        [Column("FILENAME")]
        [StringLength(50)]
        public string Filename { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime DataElab { get; set; }
        [Column("FESTIVO")]
        [StringLength(1)]
        public string Festivo { get; set; }
    }
}
