using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("DATI_FLASH_NEWS")]
    public partial class DatiFlashNews
    {
        [Key]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("VALORE")]
        public int? Valore { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
        [Column("INDICE")]
        public short? Indice { get; set; }
    }
}
