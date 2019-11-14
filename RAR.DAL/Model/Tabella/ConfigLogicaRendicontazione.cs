using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_LOGICA_RENDICONTAZIONE")]
    public partial class ConfigLogicaRendicontazione
    {
        public ConfigLogicaRendicontazione()
        {
            Banca = new HashSet<Banca>();
        }

        [Key]
        [Column("LOGICA_RENDICONTAZIONE")]
        [StringLength(1)]
        public string LogicaRendicontazione { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(100)]
        public string Descrizione { get; set; }

        [InverseProperty("LogicaRendicontazioneNavigation")]
        public virtual ICollection<Banca> Banca { get; set; }
    }
}
