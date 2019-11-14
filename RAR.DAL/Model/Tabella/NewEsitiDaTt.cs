using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Esiti_Da_TT")]
    public partial class NewEsitiDaTt
    {
        public int Id { get; set; }
        [Required]
        [Column("Code_Racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("Codice_Esito")]
        [StringLength(4)]
        public string CodiceEsito { get; set; }
        [Required]
        [StringLength(2)]
        public string Canale { get; set; }
        [Required]
        [Column("File_Name_AR")]
        [StringLength(25)]
        public string FileNameAr { get; set; }
        [Column("Data_Load_Dati", TypeName = "smalldatetime")]
        public DateTime DataLoadDati { get; set; }
        [Column("Data_Traccia", TypeName = "smalldatetime")]
        public DateTime DataTraccia { get; set; }
        [Column("Data_Notifica", TypeName = "smalldatetime")]
        public DateTime DataNotifica { get; set; }
        [StringLength(4)]
        public string Errore { get; set; }
        public int? Pompato { get; set; }
        [Column("data_pompaggio", TypeName = "smalldatetime")]
        public DateTime? DataPompaggio { get; set; }
        [Column("chiave")]
        [StringLength(6)]
        public string Chiave { get; set; }
    }
}
