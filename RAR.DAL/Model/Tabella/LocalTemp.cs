using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("local_temp")]
    public partial class LocalTemp
    {
        [Column("prov")]
        [StringLength(2)]
        public string Prov { get; set; }
        [Key]
        [Column("cap")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Column("localita")]
        [StringLength(200)]
        public string Localita { get; set; }
    }
}
