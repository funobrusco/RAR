using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("DIPENDENZE")]
    public partial class Dipendenze
    {
        [Key]
        [Column("ID_DIPENDENZE")]
        public int IdDipendenze { get; set; }
        [Required]
        [Column("CODE_DIPENDENZE")]
        [StringLength(3)]
        public string CodeDipendenze { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("VIA_DIPENDENZE")]
        [StringLength(44)]
        public string ViaDipendenze { get; set; }
        [Column("CODE_CAP_DIPENDENZE")]
        [StringLength(5)]
        public string CodeCapDipendenze { get; set; }
        [Column("LOC_DIPENDENZE")]
        [StringLength(44)]
        public string LocDipendenze { get; set; }
        [Column("PROVINCIA")]
        [StringLength(2)]
        public string Provincia { get; set; }
        [Column("E_MAIL")]
        [StringLength(40)]
        public string EMail { get; set; }
        [Column("ID_DISPACCIO_OUT")]
        public int? IdDispaccioOut { get; set; }
    }
}
