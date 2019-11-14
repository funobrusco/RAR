using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("FILE_LIVORNO")]
    public partial class FileLivorno
    {
        [Column("DESTINATARIO")]
        [StringLength(88)]
        public string Destinatario { get; set; }
        [Column("VIA_DEST")]
        [StringLength(44)]
        public string ViaDest { get; set; }
        [Column("CODE_CAP_DEST")]
        [StringLength(5)]
        public string CodeCapDest { get; set; }
        [Column("LOC_DEST")]
        [StringLength(44)]
        public string LocDest { get; set; }
        [Key]
        [Column("PROGRESSIVO_UTENTE")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
    }
}
