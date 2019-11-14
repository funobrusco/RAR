using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SOST_IMG")]
    public partial class SostImg
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("IMMAGINE", TypeName = "image")]
        public byte[] Immagine { get; set; }
        [Column("ID_SCATOLA")]
        public int IdScatola { get; set; }

        [ForeignKey("IdScatola")]
        [InverseProperty("SostImg")]
        public virtual SostScatola IdScatolaNavigation { get; set; }
    }
}
