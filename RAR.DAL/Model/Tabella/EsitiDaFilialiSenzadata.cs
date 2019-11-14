using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ESITI_DA_FILIALI_SENZADATA")]
    public partial class EsitiDaFilialiSenzadata
    {
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime DataNotifica { get; set; }
        [Required]
        [Column("FILE_NAME")]
        [StringLength(50)]
        public string FileName { get; set; }
        [Column("DATA_LOAD_DATI", TypeName = "smalldatetime")]
        public DateTime DataLoadDati { get; set; }
    }
}
