using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("cappario_uffici")]
    public partial class CapparioUffici
    {
        [Key]
        [Column("cap")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Column("n")]
        public int? N { get; set; }
        [Column("AGENZIA_RECAPITO")]
        [StringLength(50)]
        public string AgenziaRecapito { get; set; }
        [Column("TIPO")]
        [StringLength(1)]
        public string Tipo { get; set; }
    }
}
