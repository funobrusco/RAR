using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Scambio_Napoli_Immagini")]
    public partial class NewScambioNapoliImmagini
    {
        public int Id { get; set; }
        [Required]
        [Column("Nome_File_ZIP")]
        [StringLength(50)]
        public string NomeFileZip { get; set; }
        [Column("Data_Arrivo_File_ZIP", TypeName = "datetime")]
        public DateTime DataArrivoFileZip { get; set; }
        [Column("Nome_File_XML")]
        [StringLength(50)]
        public string NomeFileXml { get; set; }
        [Column("Testo_XML", TypeName = "xml")]
        public string TestoXml { get; set; }
        [Column("Data_Creazione_File_Esito", TypeName = "datetime")]
        public DateTime? DataCreazioneFileEsito { get; set; }
        [StringLength(1)]
        public string Esito { get; set; }
    }
}
