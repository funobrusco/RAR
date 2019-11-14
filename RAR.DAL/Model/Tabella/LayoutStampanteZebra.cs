using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("LAYOUT_STAMPANTE_ZEBRA")]
    public partial class LayoutStampanteZebra
    {
        [Key]
        [Column("ID_LAYOUT")]
        public int IdLayout { get; set; }
        [Required]
        [Column("LAYOUT", TypeName = "text")]
        public string Layout { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(300)]
        public string Descrizione { get; set; }
    }
}
