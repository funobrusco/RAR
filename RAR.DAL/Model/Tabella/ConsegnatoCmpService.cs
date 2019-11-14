using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONSEGNATO_CMP_SERVICE")]
    public partial class ConsegnatoCmpService
    {
        [Column("CP")]
        public int Cp { get; set; }
        [Required]
        [Column("BANCA")]
        [StringLength(20)]
        public string Banca { get; set; }
        [Column("MESE", TypeName = "smalldatetime")]
        public DateTime Mese { get; set; }
        [Column("TOTALE")]
        public int Totale { get; set; }
        [Column("MITTENTE")]
        [StringLength(50)]
        public string Mittente { get; set; }
        [Column("ULTIMO_INVIO", TypeName = "smalldatetime")]
        public DateTime? UltimoInvio { get; set; }
    }
}
