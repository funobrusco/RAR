using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("TENTATO_RECAPITO")]
    public partial class TentatoRecapito
    {
        [Column("BANCA")]
        [StringLength(6)]
        public string Banca { get; set; }
        [Column("DATA_COMUNICAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataComunicazione { get; set; }
    }
}
