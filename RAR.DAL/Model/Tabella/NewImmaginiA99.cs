using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Immagini_a_99")]
    public partial class NewImmaginiA99
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [Column("Code_Racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("Img_Front")]
        public byte[] ImgFront { get; set; }
        [Column("Img_Retro")]
        public byte[] ImgRetro { get; set; }
        [Required]
        [StringLength(12)]
        public string Scatola { get; set; }
        public int Progressivo { get; set; }
        public byte? Inviato { get; set; }
        [Column("Flusso_Invio")]
        public int? FlussoInvio { get; set; }
        [Column("ID_New_Scambio_Postel")]
        public int IdNewScambioPostel { get; set; }
        [StringLength(4)]
        public string Errore { get; set; }
        [Column("Flag_Archiviazione_ADE")]
        public int? FlagArchiviazioneAde { get; set; }
    }
}
