using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("cap_distinti")]
    public partial class CapDistinti
    {
        [Column("cap")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Column("filiale")]
        [StringLength(50)]
        public string Filiale { get; set; }
        [Column("capoluogo")]
        [StringLength(15)]
        public string Capoluogo { get; set; }
        [Column("regione")]
        [StringLength(23)]
        public string Regione { get; set; }
    }
}
