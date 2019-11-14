using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("BANCA")]
    public partial class Banca
    {
        public Banca()
        {
            Cliente = new HashSet<Cliente>();
        }

        [Key]
        [Column("ID_BANCA")]
        public int IdBanca { get; set; }
        [Required]
        [Column("DESCRIZIONE_BANCA")]
        [StringLength(255)]
        public string DescrizioneBanca { get; set; }
        [Column("VIA_BANCA")]
        [StringLength(44)]
        public string ViaBanca { get; set; }
        [Column("CODE_CAP_BANCA")]
        [StringLength(5)]
        public string CodeCapBanca { get; set; }
        [Column("LOC_BANCA")]
        [StringLength(44)]
        public string LocBanca { get; set; }
        [Column("PROVINCIA")]
        [StringLength(2)]
        public string Provincia { get; set; }
        [Column("E_MAIL")]
        [StringLength(40)]
        public string EMail { get; set; }
        [Column("ID_INSIEME_BANCHE")]
        public int IdInsiemeBanche { get; set; }
        [Required]
        [Column("DESCRIZIONE_INSIEME_BANCHE")]
        [StringLength(100)]
        public string DescrizioneInsiemeBanche { get; set; }
        [Column("LOGICA_RENDICONTAZIONE")]
        [StringLength(1)]
        public string LogicaRendicontazione { get; set; }
        [Column("INTESTAZIONE")]
        [StringLength(50)]
        public string Intestazione { get; set; }

        [ForeignKey("LogicaRendicontazione")]
        [InverseProperty("Banca")]
        public virtual ConfigLogicaRendicontazione LogicaRendicontazioneNavigation { get; set; }
        [InverseProperty("IdBancaNavigation")]
        public virtual ICollection<Cliente> Cliente { get; set; }
    }
}
