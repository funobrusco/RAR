using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("IMG_RELATA")]
    public partial class ImgRelata
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("IMMAGINE_1", TypeName = "image")]
        public byte[] Immagine1 { get; set; }
        [Required]
        [Column("IMMAGINE_2", TypeName = "image")]
        public byte[] Immagine2 { get; set; }

        [ForeignKey("CodeRacc")]
        [InverseProperty("ImgRelata")]
        public virtual RaccPlichiMesso CodeRaccNavigation { get; set; }
    }
}
