using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CODICI_SMARRITI")]
    public partial class CodiciSmarriti
    {
        [Column("CODICE_INVIO")]
        [StringLength(12)]
        public string CodiceInvio { get; set; }
        [Column("DATA_DENUNCIA", TypeName = "smalldatetime")]
        public DateTime DataDenuncia { get; set; }
        [Column("DATA_LOAD_DATI", TypeName = "smalldatetime")]
        public DateTime DataLoadDati { get; set; }
        [Required]
        [Column("ESITO")]
        [StringLength(2)]
        public string Esito { get; set; }
        [Required]
        [Column("FILENAME")]
        [StringLength(50)]
        public string Filename { get; set; }
    }
}
