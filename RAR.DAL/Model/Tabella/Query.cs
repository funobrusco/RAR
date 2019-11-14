using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("QUERY")]
    public partial class Query
    {
        [Column("ID_QUERY")]
        public int IdQuery { get; set; }
        [Required]
        [Column("DESC_QUERY")]
        [StringLength(250)]
        public string DescQuery { get; set; }
        [Required]
        [Column("TESTO")]
        [StringLength(8000)]
        public string Testo { get; set; }
        [Required]
        [Column("CODE_OP")]
        [StringLength(5)]
        public string CodeOp { get; set; }
    }
}
