using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_FlussiInputRAW")]
    public partial class NewFlussiInputRaw
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDFileInput")]
        public int? IdfileInput { get; set; }
        [Required]
        [StringLength(300)]
        public string RigaTrasmessa { get; set; }
    }
}
