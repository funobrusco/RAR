using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Codici_CMP")]
    public partial class NewCodiciCmp
    {
        [Key]
        [Column("ID_Codici_CMP")]
        public int IdCodiciCmp { get; set; }
        [Required]
        [StringLength(11)]
        public string Polo { get; set; }
        [Required]
        [StringLength(11)]
        public string Provincia { get; set; }
        [Required]
        [Column("Nome_Impianto")]
        [StringLength(25)]
        public string NomeImpianto { get; set; }
        [Required]
        [StringLength(5)]
        public string Frazionario { get; set; }
        [Required]
        [Column("EMail_TO")]
        [StringLength(400)]
        public string EmailTo { get; set; }
        [Required]
        [Column("EMail_CC")]
        [StringLength(400)]
        public string EmailCc { get; set; }
        [Required]
        [Column("Oggetto_EMail")]
        [StringLength(150)]
        public string OggettoEmail { get; set; }
        [Required]
        [Column("Testo_EMail")]
        [StringLength(1000)]
        public string TestoEmail { get; set; }
    }
}
