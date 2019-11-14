using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONCESSIONE")]
    public partial class Concessione
    {
        [Key]
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Required]
        [Column("CODE_CONCESSIONE")]
        [StringLength(3)]
        public string CodeConcessione { get; set; }
        [Required]
        [Column("CODE_UTENTE")]
        [StringLength(8)]
        public string CodeUtente { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("VIA_CONCESSIONE")]
        [StringLength(44)]
        public string ViaConcessione { get; set; }
        [Column("CODE_CAP_CONCESSIONE")]
        [StringLength(5)]
        public string CodeCapConcessione { get; set; }
        [Column("LOC_CONCESSIONE")]
        [StringLength(44)]
        public string LocConcessione { get; set; }
        [Column("PROVINCIA")]
        [StringLength(2)]
        public string Provincia { get; set; }
        [Column("E_MAIL")]
        [StringLength(40)]
        public string EMail { get; set; }
        [Required]
        [Column("INDIRIZZO_SPEDIZIONE_FILE")]
        [StringLength(255)]
        public string IndirizzoSpedizioneFile { get; set; }
        [Column("ID_CMP")]
        public int IdCmp { get; set; }

        [ForeignKey("CodeUtente")]
        [InverseProperty("Concessione")]
        public virtual Cliente CodeUtenteNavigation { get; set; }
    }
}
