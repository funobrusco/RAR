using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_STORICO_XML_TRACCIATURA")]
    public partial class NewStoricoXmlTracciatura
    {
        [Column("CODICE_DISPACCIO")]
        [StringLength(50)]
        public string CodiceDispaccio { get; set; }
        [Required]
        [Column("testoxml", TypeName = "xml")]
        public string Testoxml { get; set; }
    }
}
