using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Rendicontazione_Esiti_NSIN")]
    public partial class NewRendicontazioneEsitiNsin
    {
        [Key]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("esito")]
        [StringLength(2)]
        public string Esito { get; set; }
        [Column("motivo")]
        [StringLength(2)]
        public string Motivo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataConsegna { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataEsito { get; set; }
        [StringLength(1)]
        public string FonteEsito { get; set; }
        [Column("lavorato")]
        public byte Lavorato { get; set; }
        [Column("data_inserimento", TypeName = "datetime")]
        public DateTime? DataInserimento { get; set; }
    }
}
