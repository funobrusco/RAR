using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Parametri")]
    public partial class NewParametri
    {
        public int Id { get; set; }
        [StringLength(60)]
        public string Nome { get; set; }
        [StringLength(40)]
        public string Modulo { get; set; }
        [Required]
        [StringLength(8000)]
        public string Valore { get; set; }
    }
}
