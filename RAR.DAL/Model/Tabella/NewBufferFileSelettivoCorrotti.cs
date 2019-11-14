using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Buffer_File_Selettivo_Corrotti", Schema = "ETL")]
    public partial class NewBufferFileSelettivoCorrotti
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
