using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ESA_RACC_CMP")]
    public partial class EsaRaccCmp
    {
        [Key]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Required]
        [Column("file_name_ar")]
        [StringLength(30)]
        public string FileNameAr { get; set; }
        [Column("id_CMP")]
        public int IdCmp { get; set; }
        [Required]
        [Column("codice_esito")]
        [StringLength(12)]
        public string CodiceEsito { get; set; }
        [Column("data_elab", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
    }
}
