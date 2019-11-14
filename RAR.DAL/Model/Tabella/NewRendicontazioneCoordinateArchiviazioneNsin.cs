using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Rendicontazione_Coordinate_Archiviazione_NSIN")]
    public partial class NewRendicontazioneCoordinateArchiviazioneNsin
    {
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("numero_scatola")]
        [StringLength(20)]
        public string NumeroScatola { get; set; }
        [Required]
        [Column("progressivo")]
        [StringLength(10)]
        public string Progressivo { get; set; }
        [Required]
        [Column("esito_ritorno")]
        [StringLength(2)]
        public string EsitoRitorno { get; set; }
        [Column("tipo_consegna")]
        [StringLength(30)]
        public string TipoConsegna { get; set; }
        [Column("lavorato")]
        public byte Lavorato { get; set; }
        [Column("data_inserimento", TypeName = "datetime")]
        public DateTime? DataInserimento { get; set; }
    }
}
