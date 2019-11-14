using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SOST_SCATOLA")]
    public partial class SostScatola
    {
        public SostScatola()
        {
            SostDati = new HashSet<SostDati>();
            SostImg = new HashSet<SostImg>();
        }

        [Key]
        [Column("ID_SCATOLA")]
        public int IdScatola { get; set; }
        [Column("NUM_SCATOLA")]
        public int NumScatola { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Column("DIM")]
        public int Dim { get; set; }
        [Column("DIM_MAX")]
        public int DimMax { get; set; }
        [Required]
        [Column("FLAG_STATO_SCATOLA")]
        [StringLength(1)]
        public string FlagStatoScatola { get; set; }
        [Column("DISPACCIO_OUT")]
        [StringLength(12)]
        public string DispaccioOut { get; set; }
        [Column("ID_CD")]
        [StringLength(10)]
        public string IdCd { get; set; }
        [Column("CODE_OP_MAST")]
        [StringLength(5)]
        public string CodeOpMast { get; set; }
        [Column("DATA_MAST", TypeName = "smalldatetime")]
        public DateTime? DataMast { get; set; }
        [Required]
        [Column("CODE_OP_LOAD")]
        [StringLength(22)]
        public string CodeOpLoad { get; set; }
        [Column("DATA_LOAD", TypeName = "smalldatetime")]
        public DateTime DataLoad { get; set; }
        [Required]
        [Column("FLAG_TIPO_SCATOLA")]
        [StringLength(1)]
        public string FlagTipoScatola { get; set; }

        [ForeignKey("FlagStatoScatola")]
        [InverseProperty("SostScatola")]
        public virtual ConfigSostFlagStatoScatola FlagStatoScatolaNavigation { get; set; }
        [InverseProperty("IdScatolaNavigation")]
        public virtual ICollection<SostDati> SostDati { get; set; }
        [InverseProperty("IdScatolaNavigation")]
        public virtual ICollection<SostImg> SostImg { get; set; }
    }
}
