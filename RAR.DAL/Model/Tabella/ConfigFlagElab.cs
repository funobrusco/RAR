using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_ELAB")]
    public partial class ConfigFlagElab
    {
        public ConfigFlagElab()
        {
            ArchivioRelata = new HashSet<ArchivioRelata>();
        }

        [Key]
        [Column("FLAG_ELAB")]
        [StringLength(1)]
        public string FlagElab { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("FlagElabNavigation")]
        public virtual ICollection<ArchivioRelata> ArchivioRelata { get; set; }
    }
}
