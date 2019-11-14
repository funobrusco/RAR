using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("VIARIO_UR")]
    public partial class ViarioUr
    {
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("DENOM_UR")]
        [StringLength(60)]
        public string DenomUr { get; set; }
    }
}
