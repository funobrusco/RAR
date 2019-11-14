using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Cartoline_Dispaccio_In")]
    public partial class NewCartolineDispaccioIn
    {
        public int Id { get; set; }
        [Column("Id_Dispaccio_In")]
        public long IdDispaccioIn { get; set; }
        [Column("Code_Racc")]
        [StringLength(20)]
        public string CodeRacc { get; set; }
        [Column("Data_Tracciatura", TypeName = "smalldatetime")]
        public DateTime DataTracciatura { get; set; }
        [Column("Data_Notifica", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Required]
        [Column("Usr_Tracciatura")]
        [StringLength(50)]
        public string UsrTracciatura { get; set; }
        [Column("Codice_Tipo_Consegna")]
        [StringLength(2)]
        public string CodiceTipoConsegna { get; set; }
    }
}
