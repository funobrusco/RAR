using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("T_RACC_INVIO_SELETTIVO_Postel", Schema = "ETL")]
    public partial class TRaccInvioSelettivoPostel
    {
        [Column("ID_RACC_INVI")]
        public int IdRaccInvi { get; set; }
        [Column("ID_STATO_RACC")]
        public short? IdStatoRacc { get; set; }
        [Column("ID_FLUSSO")]
        public int IdFlusso { get; set; }
        [Column("ID_FLUSSO_ACK")]
        public int? IdFlussoAck { get; set; }
        [Column("ID_FLUSSO_ESITI")]
        public int? IdFlussoEsiti { get; set; }
        [Required]
        [Column("CODE_RACC")]
        [StringLength(12)]
        public string CodeRacc { get; set; }

        [ForeignKey("IdFlussoEsiti")]
        [InverseProperty("TRaccInvioSelettivoPostelIdFlussoEsitiNavigation")]
        public virtual TFlussi IdFlussoEsitiNavigation { get; set; }
        [ForeignKey("IdFlusso")]
        [InverseProperty("TRaccInvioSelettivoPostelIdFlussoNavigation")]
        public virtual TFlussi IdFlussoNavigation { get; set; }
    }
}
