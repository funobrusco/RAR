using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_CMP")]
    public partial class ConfigCmp
    {
        public ConfigCmp()
        {
            MessiAnagrafica = new HashSet<MessiAnagrafica>();
            Scatola = new HashSet<Scatola>();
        }

        [Key]
        [Column("ID_CMP")]
        public int IdCmp { get; set; }
        [Required]
        [Column("NOME")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [Column("INDIRIZZO")]
        [StringLength(50)]
        public string Indirizzo { get; set; }
        [Required]
        [Column("CAP")]
        [StringLength(5)]
        public string Cap { get; set; }
        [Required]
        [Column("LOCALITA")]
        [StringLength(50)]
        public string Localita { get; set; }
        [Required]
        [Column("PROVINCIA")]
        [StringLength(2)]
        public string Provincia { get; set; }

        [InverseProperty("IdCmpNavigation")]
        public virtual ICollection<MessiAnagrafica> MessiAnagrafica { get; set; }
        [InverseProperty("IdCmpNavigation")]
        public virtual ICollection<Scatola> Scatola { get; set; }
    }
}
