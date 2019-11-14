using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("config_Codici_CMP")]
    public partial class ConfigCodiciCmp
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
        [Column("Sigla_Provincia")]
        [StringLength(3)]
        public string SiglaProvincia { get; set; }
        [Required]
        [Column("Nome_Impianto")]
        [StringLength(25)]
        public string NomeImpianto { get; set; }
        [Required]
        [StringLength(5)]
        public string Frazionario { get; set; }
        [Column("Unita_Operativa")]
        [StringLength(2)]
        public string UnitaOperativa { get; set; }
        [Column("Descrizione_UO")]
        [StringLength(25)]
        public string DescrizioneUo { get; set; }
    }
}
