using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("aggiorna_intesa_filiali")]
    public partial class AggiornaIntesaFiliali
    {
        [Key]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("esito")]
        [StringLength(2)]
        public string Esito { get; set; }
        [Column("data_esito")]
        [StringLength(15)]
        public string DataEsito { get; set; }
    }
}
