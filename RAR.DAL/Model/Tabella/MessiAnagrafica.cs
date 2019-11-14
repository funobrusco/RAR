using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("MESSI_ANAGRAFICA")]
    public partial class MessiAnagrafica
    {
        [Key]
        [Column("ID_MESSO")]
        public int IdMesso { get; set; }
        [Required]
        [Column("NOMINATIVO")]
        [StringLength(60)]
        public string Nominativo { get; set; }
        [Column("FLAG_ATTIVO")]
        public bool FlagAttivo { get; set; }
        [Column("DATA_FINE_ATTIVITA", TypeName = "smalldatetime")]
        public DateTime? DataFineAttivita { get; set; }
        [Column("ID_CMP")]
        public int IdCmp { get; set; }

        [ForeignKey("IdCmp")]
        [InverseProperty("MessiAnagrafica")]
        public virtual ConfigCmp IdCmpNavigation { get; set; }
    }
}
