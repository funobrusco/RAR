using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("FILIALI")]
    public partial class Filiali
    {
        [Required]
        [Column("FILIALE")]
        [StringLength(30)]
        public string Filiale { get; set; }
        [Key]
        [Column("CAP")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Column("PROV")]
        [StringLength(2)]
        public string Prov { get; set; }
        [Column("CAPOLUOGO")]
        [StringLength(15)]
        public string Capoluogo { get; set; }
        [Column("REGIONE")]
        [StringLength(30)]
        public string Regione { get; set; }
    }
}
