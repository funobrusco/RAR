using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SERVICE_DISPACCIO")]
    public partial class ServiceDispaccio
    {
        [Key]
        [Column("ID_DISPACCIO")]
        public int IdDispaccio { get; set; }
        [Required]
        [Column("CODICE_DISPACCIO")]
        [StringLength(12)]
        public string CodiceDispaccio { get; set; }
        [Column("DATA_LAVORAZIONE", TypeName = "smalldatetime")]
        public DateTime DataLavorazione { get; set; }
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime? DataSpedizione { get; set; }
        [Column("DATA_RICEZIONE", TypeName = "smalldatetime")]
        public DateTime? DataRicezione { get; set; }
        [Required]
        [Column("SERVICE")]
        [StringLength(20)]
        public string Service { get; set; }
    }
}
