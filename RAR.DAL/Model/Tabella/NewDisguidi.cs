using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Disguidi")]
    public partial class NewDisguidi
    {
        [Key]
        [Column("ID_DISGUIDO")]
        public int IdDisguido { get; set; }
        [Required]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("DATA_ELAB", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
        [Required]
        [Column("CODICE_ESITO")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Required]
        [Column("FLAG_FONTE_ESITO")]
        [StringLength(1)]
        public string FlagFonteEsito { get; set; }
        [Column("CODICE_MOTIVO")]
        [StringLength(2)]
        public string CodiceMotivo { get; set; }
        [Column("CODE_OPE_DE")]
        [StringLength(50)]
        public string CodeOpeDe { get; set; }
        [Column("DATA_NOTIFICA", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Column("DATA_DISGUIDO", TypeName = "smalldatetime")]
        public DateTime? DataDisguido { get; set; }
        [Column("DATA_ELABORAZIONE", TypeName = "smalldatetime")]
        public DateTime? DataElaborazione { get; set; }
        [Column("ELABORATO")]
        public bool? Elaborato { get; set; }
        [Column("ID_DISPACCIO_OUT")]
        public int? IdDispaccioOut { get; set; }
    }
}
