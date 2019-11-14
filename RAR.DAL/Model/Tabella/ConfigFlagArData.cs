using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("CONFIG_FLAG_AR_DATA")]
    public partial class ConfigFlagArData
    {
        [Key]
        [Column("code_flag_ar_data")]
        [StringLength(1)]
        public string CodeFlagArData { get; set; }
        [Required]
        [Column("descr_flag_ar_data")]
        [StringLength(50)]
        public string DescrFlagArData { get; set; }
    }
}
