using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("QUERYNEW")]
    public partial class Querynew
    {
        [Column("id")]
        public int Id { get; set; }
        [StringLength(255)]
        public string Descrizione { get; set; }
        [StringLength(8000)]
        public string SqlText { get; set; }
        [Required]
        [StringLength(9)]
        public string Users { get; set; }
    }
}
