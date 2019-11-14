using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_STATO_RACC", Schema = "ETL")]
    public partial class ConfigStatoRacc
    {
        [Column("ID_Stato_Racc")]
        public int IdStatoRacc { get; set; }
        [Required]
        [Column("Nome_Stato_Racc")]
        [StringLength(200)]
        public string NomeStatoRacc { get; set; }
        [Required]
        [Column("Codice_Stato_Racc")]
        [StringLength(50)]
        public string CodiceStatoRacc { get; set; }
        [Required]
        [Column("Scarto_parziale")]
        public bool? ScartoParziale { get; set; }
    }
}
