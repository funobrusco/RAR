using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Buffer_Distinta_Fittizia")]
    public partial class NewBufferDistintaFittizia
    {
        public int Id { get; set; }
        [Column("Tipo_Flusso")]
        public int TipoFlusso { get; set; }
        [Column("nome_file")]
        [StringLength(50)]
        public string NomeFile { get; set; }
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("id_file_name")]
        public int? IdFileName { get; set; }
        [Column("dispaccio")]
        [StringLength(50)]
        public string Dispaccio { get; set; }
        [Column("data_esito", TypeName = "smalldatetime")]
        public DateTime? DataEsito { get; set; }
        [Column("data_load_dati", TypeName = "smalldatetime")]
        public DateTime? DataLoadDati { get; set; }
        [Required]
        [Column("stato_lavorazione")]
        [StringLength(1)]
        public string StatoLavorazione { get; set; }
    }
}
