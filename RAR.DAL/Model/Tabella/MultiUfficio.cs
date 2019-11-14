using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("multi_ufficio")]
    public partial class MultiUfficio
    {
        [Key]
        [Column("cap")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Column("tot")]
        public int Tot { get; set; }
        [Column("ufficio")]
        [StringLength(50)]
        public string Ufficio { get; set; }
    }
}
