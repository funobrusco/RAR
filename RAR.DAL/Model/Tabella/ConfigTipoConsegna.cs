using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_TIPO_CONSEGNA")]
    public partial class ConfigTipoConsegna
    {
        [Column("CODICE_TIPO_CONSEGNA")]
        [StringLength(2)]
        public string CodiceTipoConsegna { get; set; }
        [Column("DESCRIZIONE")]
        [StringLength(200)]
        public string Descrizione { get; set; }
    }
}
