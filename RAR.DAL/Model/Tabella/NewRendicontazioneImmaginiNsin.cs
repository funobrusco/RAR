using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Rendicontazione_Immagini_NSIN")]
    public partial class NewRendicontazioneImmaginiNsin
    {
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("img_fronte")]
        public byte[] ImgFronte { get; set; }
        [Column("img_retro")]
        public byte[] ImgRetro { get; set; }
        [Column("lavorato")]
        public byte? Lavorato { get; set; }
        [StringLength(2)]
        public string MacroEsito { get; set; }
        [Column("data_inserimento", TypeName = "datetime")]
        public DateTime? DataInserimento { get; set; }
    }
}
