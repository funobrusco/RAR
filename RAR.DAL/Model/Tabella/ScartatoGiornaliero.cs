using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SCARTATO_GIORNALIERO")]
    public partial class ScartatoGiornaliero
    {
        [Column("SCARTO")]
        public int Scarto { get; set; }
        [Key]
        [Column("DATA_SCARTO", TypeName = "smalldatetime")]
        public DateTime DataScarto { get; set; }
    }
}
