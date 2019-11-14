using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_AnagraficaFlussi_Postel")]
    public partial class NewAnagraficaFlussiPostel
    {
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string NomeFile { get; set; }
        [Required]
        [StringLength(6)]
        public string TipoFile { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DataLavorazione { get; set; }
        [Column("FileACK")]
        [StringLength(100)]
        public string FileAck { get; set; }
        [Column("DataLavorazioneACK", TypeName = "datetime")]
        public DateTime? DataLavorazioneAck { get; set; }
        [Column("FileESITO")]
        [StringLength(100)]
        public string FileEsito { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DataLavorazioneEsito { get; set; }
        [Column("FileESITOACK")]
        [StringLength(100)]
        public string FileEsitoack { get; set; }
        [Column("DataLavorazioneEsitoACK", TypeName = "datetime")]
        public DateTime? DataLavorazioneEsitoAck { get; set; }
        [StringLength(1)]
        public string StatoFlusso { get; set; }
    }
}
