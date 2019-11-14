using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Scambio_Esiti_TT")]
    public partial class NewScambioEsitiTt
    {
        public int Id { get; set; }
        [Required]
        [Column("Nome_File")]
        [StringLength(50)]
        public string NomeFile { get; set; }
        [Column("Data_Arrivo_File", TypeName = "datetime")]
        public DateTime DataArrivoFile { get; set; }
        [Column("Data_Creazione_File_Esito", TypeName = "datetime")]
        public DateTime? DataCreazioneFileEsito { get; set; }
        [StringLength(1)]
        public string Esito { get; set; }
    }
}
