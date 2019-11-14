using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_STATO_FLUSSO", Schema = "ETL")]
    public partial class ConfigStatoFlusso
    {
        [Column("ID_Stato_FLUSSO")]
        public int IdStatoFlusso { get; set; }
        [Required]
        [Column("Nome_Stato_FLUSSO")]
        [StringLength(200)]
        public string NomeStatoFlusso { get; set; }
        [Required]
        [Column("Codice_Stato_FLUSSO")]
        [StringLength(50)]
        public string CodiceStatoFlusso { get; set; }
        [Required]
        [Column("Scarto_parziale")]
        public bool? ScartoParziale { get; set; }
    }
}
