using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    public partial class RaccEsitate
    {
        [StringLength(20)]
        public string CodiceRacc { get; set; }
        [StringLength(40)]
        public string Concessionaria { get; set; }
        [StringLength(50)]
        public string DataTracc { get; set; }
        [StringLength(20)]
        public string Dispaccio { get; set; }
        [Column("id")]
        public int Id { get; set; }
    }
}
