using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("T_FLUSSI", Schema = "ETL")]
    public partial class TFlussi
    {
        public TFlussi()
        {
            InverseIdFlussoParentNavigation = new HashSet<TFlussi>();
            TRaccInvioSelettivoPostelIdFlussoEsitiNavigation = new HashSet<TRaccInvioSelettivoPostel>();
            TRaccInvioSelettivoPostelIdFlussoNavigation = new HashSet<TRaccInvioSelettivoPostel>();
        }

        [Column("ID_Flusso")]
        public int IdFlusso { get; set; }
        [Column("ID_Flusso_Parent")]
        public int? IdFlussoParent { get; set; }
        [Required]
        [Column("Nome_Flusso")]
        [StringLength(200)]
        public string NomeFlusso { get; set; }
        [Required]
        [Column("Estensione_Flusso")]
        [StringLength(10)]
        public string EstensioneFlusso { get; set; }
        [Column("ID_Stato_Flusso")]
        public short? IdStatoFlusso { get; set; }
        [Required]
        [Column("Tipo_Flusso")]
        [StringLength(50)]
        public string TipoFlusso { get; set; }
        [Column("Numero_Elementi")]
        public int NumeroElementi { get; set; }
        [Column("Contenuto_Flusso")]
        public string ContenutoFlusso { get; set; }
        [Column("Esito_Flusso")]
        public string EsitoFlusso { get; set; }
        [Column("DT_Creazione_Flusso", TypeName = "datetime")]
        public DateTime DtCreazioneFlusso { get; set; }
        [Column("DT_Inserimento_Flusso", TypeName = "datetime")]
        public DateTime DtInserimentoFlusso { get; set; }
        [Column("FlagEMailACK")]
        public bool FlagEmailAck { get; set; }
        [Column("FlagEMailEsiti")]
        public bool FlagEmailEsiti { get; set; }
        [Column("DataEMailACK", TypeName = "datetime")]
        public DateTime? DataEmailAck { get; set; }
        [Column("DataEMailEsiti", TypeName = "datetime")]
        public DateTime? DataEmailEsiti { get; set; }

        [ForeignKey("IdFlussoParent")]
        [InverseProperty("InverseIdFlussoParentNavigation")]
        public virtual TFlussi IdFlussoParentNavigation { get; set; }
        [InverseProperty("IdFlussoParentNavigation")]
        public virtual ICollection<TFlussi> InverseIdFlussoParentNavigation { get; set; }
        [InverseProperty("IdFlussoEsitiNavigation")]
        public virtual ICollection<TRaccInvioSelettivoPostel> TRaccInvioSelettivoPostelIdFlussoEsitiNavigation { get; set; }
        [InverseProperty("IdFlussoNavigation")]
        public virtual ICollection<TRaccInvioSelettivoPostel> TRaccInvioSelettivoPostelIdFlussoNavigation { get; set; }
    }
}
