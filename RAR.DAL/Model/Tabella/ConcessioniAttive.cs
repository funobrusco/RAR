using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("Concessioni_Attive")]
    public partial class ConcessioniAttive
    {
        [Key]
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("PROVINCIA")]
        [StringLength(2)]
        public string Provincia { get; set; }
    }
}
