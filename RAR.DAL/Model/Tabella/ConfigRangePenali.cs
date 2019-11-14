using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_RANGE_PENALI")]
    public partial class ConfigRangePenali
    {
        [Key]
        [Column("ID_RANGE")]
        public int IdRange { get; set; }
        [Required]
        [Column("DESCRIZIONE_RANGE")]
        [StringLength(100)]
        public string DescrizioneRange { get; set; }
        [Required]
        [Column("CONDIZIONE_RANGE")]
        [StringLength(400)]
        public string CondizioneRange { get; set; }
    }
}
