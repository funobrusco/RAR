using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("PARAM")]
    public partial class Param
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("Id_query")]
        public int IdQuery { get; set; }
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}
