using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Elenco_Query")]
    public partial class NewElencoQuery
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("NOME")]
        [StringLength(150)]
        public string Nome { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(150)]
        public string Descrizione { get; set; }
        [Column("LINK")]
        [StringLength(150)]
        public string Link { get; set; }
    }
}
