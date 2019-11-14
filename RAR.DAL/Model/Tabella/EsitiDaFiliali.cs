using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ESITI_DA_FILIALI")]
    public partial class EsitiDaFiliali
    {
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("ESITO")]
        [StringLength(2)]
        public string Esito { get; set; }
        [Column("DATA_ESITO", TypeName = "smalldatetime")]
        public DateTime? DataEsito { get; set; }
        [Required]
        [Column("FILE_NAME")]
        [StringLength(50)]
        public string FileName { get; set; }
        [Column("DATA_LOAD_DATI", TypeName = "smalldatetime")]
        public DateTime DataLoadDati { get; set; }
    }
}
