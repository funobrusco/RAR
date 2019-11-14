using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ESA_RACC_TIPO_CONSEGNA")]
    public partial class EsaRaccTipoConsegna
    {
        [Key]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("TIPO_CONSEGNA")]
        [StringLength(2)]
        public string TipoConsegna { get; set; }
        [Column("DSCR_TIPO_CONSEGNA")]
        [StringLength(200)]
        public string DscrTipoConsegna { get; set; }
        [Column("DATA_INSE", TypeName = "datetime")]
        public DateTime? DataInse { get; set; }
        [Column("FLG_INSERIMENTO")]
        [StringLength(10)]
        public string FlgInserimento { get; set; }
    }
}
