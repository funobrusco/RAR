using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("COMUNICAZIONE_ESITI")]
    public partial class ComunicazioneEsiti
    {
        [Key]
        [Column("ID_COMUNICAZIONE")]
        public int IdComunicazione { get; set; }
        [Column("ID_BANCA")]
        public int? IdBanca { get; set; }
        [Column("CODE_UTENTE")]
        [StringLength(8)]
        public string CodeUtente { get; set; }
        [Column("CODE_CONCESSIONE")]
        [StringLength(3)]
        public string CodeConcessione { get; set; }
        [Column("DATA_COMUNICAZIONE", TypeName = "smalldatetime")]
        public DateTime DataComunicazione { get; set; }
        [Column("DATA_INIZIO_INTERVALLO", TypeName = "smalldatetime")]
        public DateTime DataInizioIntervallo { get; set; }
        [Column("DATA_FINE_INTERVALLO", TypeName = "smalldatetime")]
        public DateTime DataFineIntervallo { get; set; }
        [Column("COMUNICATO")]
        public int Comunicato { get; set; }
    }
}
