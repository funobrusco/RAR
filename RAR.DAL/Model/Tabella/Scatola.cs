using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("SCATOLA")]
    public partial class Scatola
    {
        public Scatola()
        {
            Lotto = new HashSet<Lotto>();
            RaccPlichiMesso = new HashSet<RaccPlichiMesso>();
        }

        [Key]
        [Column("SCATOLA")]
        public int Scatola1 { get; set; }
        [Required]
        [Column("FLAG_TIPO_SCATOLA")]
        [StringLength(1)]
        public string FlagTipoScatola { get; set; }
        [Column("DIM")]
        public int Dim { get; set; }
        [Column("DIM_MAX")]
        public int DimMax { get; set; }
        [Required]
        [Column("FLAG_STATO_SCATOLA")]
        [StringLength(1)]
        public string FlagStatoScatola { get; set; }
        [Column("ID_CMP")]
        public int IdCmp { get; set; }
        [Column("CODICE_SCATOLA")]
        [StringLength(12)]
        public string CodiceScatola { get; set; }
        [Required]
        [Column("CODE_OPE_DISP")]
        [StringLength(5)]
        public string CodeOpeDisp { get; set; }
        [Column("DATA_DISP", TypeName = "smalldatetime")]
        public DateTime DataDisp { get; set; }
        [Column("CODE_OPE_CH")]
        [StringLength(5)]
        public string CodeOpeCh { get; set; }
        [Column("DATA_CH", TypeName = "smalldatetime")]
        public DateTime? DataCh { get; set; }
        [Column("ID_CONCESSIONE")]
        public int IdConcessione { get; set; }
        [Column("CODE_OP_ACC_PACCO_MESSI")]
        [StringLength(5)]
        public string CodeOpAccPaccoMessi { get; set; }
        [Column("DATA_ACC_PACCO_MESSI", TypeName = "smalldatetime")]
        public DateTime? DataAccPaccoMessi { get; set; }

        [ForeignKey("FlagStatoScatola")]
        [InverseProperty("Scatola")]
        public virtual ConfigFlagStatoScatola FlagStatoScatolaNavigation { get; set; }
        [ForeignKey("FlagTipoScatola")]
        [InverseProperty("Scatola")]
        public virtual ConfigFlagTipoScatola FlagTipoScatolaNavigation { get; set; }
        [ForeignKey("IdCmp")]
        [InverseProperty("Scatola")]
        public virtual ConfigCmp IdCmpNavigation { get; set; }
        [InverseProperty("ScatolaNavigation")]
        public virtual ICollection<Lotto> Lotto { get; set; }
        [InverseProperty("ScatolaNavigation")]
        public virtual ICollection<RaccPlichiMesso> RaccPlichiMesso { get; set; }
    }
}
