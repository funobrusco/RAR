using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CLIENTE")]
    public partial class Cliente
    {
        public Cliente()
        {
            Concessione = new HashSet<Concessione>();
        }

        [Key]
        [Column("CODE_UTENTE")]
        [StringLength(8)]
        public string CodeUtente { get; set; }
        [Column("ID_BANCA")]
        public int IdBanca { get; set; }
        [Column("CODE_CLIENTE")]
        [StringLength(2)]
        public string CodeCliente { get; set; }
        [Required]
        [Column("DESCRIZIONE")]
        [StringLength(50)]
        public string Descrizione { get; set; }
        [Column("VIA_CLIENTE")]
        [StringLength(44)]
        public string ViaCliente { get; set; }
        [Column("CODE_CAP_CLIENTE")]
        [StringLength(5)]
        public string CodeCapCliente { get; set; }
        [Column("LOC_CLIENTE")]
        [StringLength(44)]
        public string LocCliente { get; set; }
        [Column("PROVINCIA")]
        [StringLength(2)]
        public string Provincia { get; set; }
        [Column("E_MAIL")]
        [StringLength(40)]
        public string EMail { get; set; }
        [Column("REND_SENZA_DATA_NOTIF")]
        public bool RendSenzaDataNotif { get; set; }

        [ForeignKey("IdBanca")]
        [InverseProperty("Cliente")]
        public virtual Banca IdBancaNavigation { get; set; }
        [InverseProperty("CodeUtenteNavigation")]
        public virtual ICollection<Concessione> Concessione { get; set; }
    }
}
