using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_FlussiOutputRAW")]
    public partial class NewFlussiOutputRaw
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("IDFileInput")]
        public int? IdfileInput { get; set; }
        [Column("IDFileOutput")]
        public int? IdfileOutput { get; set; }
        [Required]
        [StringLength(400)]
        public string RigaTrasmessa { get; set; }
    }
}
