using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SOST_CONFIG_REND")]
    public partial class SostConfigRend
    {
        [Column("ID")]
        public int Id { get; set; }
        [Column("ID_BANCA")]
        public int IdBanca { get; set; }
        [Column("CODE_UTENTE")]
        [StringLength(8)]
        public string CodeUtente { get; set; }
        [Column("ID_CONCESSIONE")]
        public int? IdConcessione { get; set; }
        [Required]
        [Column("FLAG_TIPO_REND")]
        [StringLength(1)]
        public string FlagTipoRend { get; set; }
    }
}
