using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("gam_AVVISI_MORA_INTESA")]
    public partial class GamAvvisiMoraIntesa
    {
        [Key]
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime DataSpedizione { get; set; }
        [Column("NUM_VOLTE")]
        public int NumVolte { get; set; }
        [Required]
        [Column("FLAG_ESTRATTO")]
        [StringLength(1)]
        public string FlagEstratto { get; set; }
    }
}
