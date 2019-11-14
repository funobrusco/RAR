using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("INDICIZZAZIONE_ESA_RACC")]
    public partial class IndicizzazioneEsaRacc
    {
        [Key]
        [Column("progressivo_utente")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Required]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
    }
}
