using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("new_code_racc_storico_cartelle")]
    public partial class NewCodeRaccStoricoCartelle
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("Code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
    }
}
