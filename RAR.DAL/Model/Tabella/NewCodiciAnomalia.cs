using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Codici_Anomalia")]
    public partial class NewCodiciAnomalia
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("Codice_Anomalia")]
        [StringLength(5)]
        public string CodiceAnomalia { get; set; }
        [Column("Descrizione_Anomalia")]
        [StringLength(100)]
        public string DescrizioneAnomalia { get; set; }
    }
}
