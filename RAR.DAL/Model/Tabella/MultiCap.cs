using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("multi_cap")]
    public partial class MultiCap
    {
        [Key]
        [Column("ufficio_recapito")]
        [StringLength(50)]
        public string UfficioRecapito { get; set; }
        [Column("tot")]
        public int Tot { get; set; }
        [Column("cap")]
        [StringLength(5)]
        public string Cap { get; set; }
    }
}
