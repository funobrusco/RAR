using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Dispaccio_In")]
    public partial class NewDispaccioIn
    {
        public long Id { get; set; }
        [Column("Code_Racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("Data_Arrivo", TypeName = "smalldatetime")]
        public DateTime DataArrivo { get; set; }
        [Column("Data_Apertura", TypeName = "smalldatetime")]
        public DateTime? DataApertura { get; set; }
        [Column("Data_Chiusura", TypeName = "smalldatetime")]
        public DateTime? DataChiusura { get; set; }
        [StringLength(255)]
        public string Mittente { get; set; }
        [Column("Usr_Arrivo")]
        [StringLength(50)]
        public string UsrArrivo { get; set; }
        [Column("Usr_Apertura")]
        [StringLength(50)]
        public string UsrApertura { get; set; }
        [Column("Usr_Chiusura")]
        [StringLength(50)]
        public string UsrChiusura { get; set; }
    }
}
