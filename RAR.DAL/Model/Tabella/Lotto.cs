using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("LOTTO")]
    public partial class Lotto
    {
        [Column("scatola")]
        public int Scatola { get; set; }
        [Column("lotto")]
        public short Lotto1 { get; set; }
        [Column("dim")]
        public short Dim { get; set; }
        [Column("id_udr")]
        public int IdUdr { get; set; }

        [ForeignKey("Scatola")]
        [InverseProperty("Lotto")]
        public virtual Scatola ScatolaNavigation { get; set; }
    }
}
