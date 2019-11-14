using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_TIPOESITO_da_TT")]
    public partial class NewTipoesitoDaTt
    {
        [StringLength(2)]
        public string Canale { get; set; }
        [StringLength(4)]
        public string Esito { get; set; }
        [Required]
        [Column("DESC_TIPO_ESITO")]
        [StringLength(40)]
        public string DescTipoEsito { get; set; }
        [Required]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [StringLength(10)]
        public string CodiceMotivo { get; set; }
        [StringLength(4)]
        public string CodiceAzione { get; set; }
        [StringLength(100)]
        public string DescrizioneAzione { get; set; }
        [StringLength(3)]
        public string Parametro { get; set; }
        [StringLength(1)]
        public string Priorita { get; set; }
        [Column("FonteEsito_EQT")]
        [StringLength(1)]
        public string FonteEsitoEqt { get; set; }
        [Column("Codice_operatore")]
        [StringLength(10)]
        public string CodiceOperatore { get; set; }
        [Required]
        [Column("Data_Notifica_Obbl")]
        public bool? DataNotificaObbl { get; set; }
        [Column("chiave")]
        [StringLength(6)]
        public string Chiave { get; set; }
    }
}
