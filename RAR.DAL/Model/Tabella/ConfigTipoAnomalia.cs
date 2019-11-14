using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_TIPO_ANOMALIA")]
    public partial class ConfigTipoAnomalia
    {
        public ConfigTipoAnomalia()
        {
            SostDati = new HashSet<SostDati>();
        }

        [Key]
        [Column("TIPO_ANOMALIA")]
        [StringLength(2)]
        public string TipoAnomalia { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }

        [InverseProperty("TipoAnomaliaNavigation")]
        public virtual ICollection<SostDati> SostDati { get; set; }
    }
}
