using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("NEW_SERVICE_RESTITUZIONE_CD")]
    public partial class NewServiceRestituzioneCd
    {
        [Column("ID_CD")]
        public int IdCd { get; set; }
        [Column("ID_FILE")]
        public int IdFile { get; set; }
        [Required]
        [Column("NUMERO_CD")]
        [StringLength(12)]
        public string NumeroCd { get; set; }
        [Column("ANNO_RIFERIMENTO")]
        public int AnnoRiferimento { get; set; }
        [Required]
        [Column("CODE_CONCESSIONE")]
        [StringLength(3)]
        public string CodeConcessione { get; set; }
    }
}
