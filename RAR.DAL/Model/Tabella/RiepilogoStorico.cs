using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("RIEPILOGO_STORICO")]
    public partial class RiepilogoStorico
    {
        [Key]
        [Column("ID_FILE_NAME")]
        public int IdFileName { get; set; }
        [Required]
        [Column("FILE_NAME")]
        [StringLength(28)]
        public string FileName { get; set; }
        [Required]
        [Column("FLAG_TIPO_DOC")]
        [StringLength(2)]
        public string FlagTipoDoc { get; set; }
        [Column("TOT_LETTERE")]
        public int TotLettere { get; set; }
        [Column("TOT_STORICO")]
        public int TotStorico { get; set; }
        [Column("TOT_CONSEGNATI_A")]
        public int TotConsegnatiA { get; set; }
        [Column("TOT_CONSEGNATI_B")]
        public int TotConsegnatiB { get; set; }
        [Column("TOT_CONSEGNATI_C")]
        public int TotConsegnatiC { get; set; }
        [Column("TOT_CONSEGNATI_E")]
        public int TotConsegnatiE { get; set; }
        [Column("TOT_RESTITUITI_B")]
        public int TotRestituitiB { get; set; }
        [Column("TOT_RESTITUITI_C")]
        public int TotRestituitiC { get; set; }
        [Column("TOT_RESTITUITI_E")]
        public int TotRestituitiE { get; set; }
        [Column("TOT_RESTITUITI_D")]
        public int TotRestituitiD { get; set; }
        [Column("MOTIVO_01")]
        public int Motivo01 { get; set; }
        [Column("MOTIVO_02")]
        public int Motivo02 { get; set; }
        [Column("MOTIVO_03")]
        public int Motivo03 { get; set; }
        [Column("MOTIVO_04")]
        public int Motivo04 { get; set; }
        [Column("MOTIVO_05")]
        public int Motivo05 { get; set; }
        [Column("MOTIVO_06")]
        public int Motivo06 { get; set; }
        [Column("MOTIVO_07")]
        public int Motivo07 { get; set; }
        [Column("MOTIVO_08")]
        public int Motivo08 { get; set; }
        [Column("MOTIVO_09")]
        public int Motivo09 { get; set; }
        [Column("MOTIVO_10")]
        public int Motivo10 { get; set; }
        [Column("MOTIVO_99")]
        public int Motivo99 { get; set; }
        [Column("FLAG_AR_DATA_B")]
        public int FlagArDataB { get; set; }
        [Column("DATA_INIZIO_STORICO", TypeName = "smalldatetime")]
        public DateTime DataInizioStorico { get; set; }
        [Column("DATA_ULTIMO_STORICO", TypeName = "smalldatetime")]
        public DateTime DataUltimoStorico { get; set; }
        [Column("ARCHIVIO")]
        [StringLength(250)]
        public string Archivio { get; set; }
        [Required]
        [Column("FLAG_STORE_DIS_POSTEL")]
        [StringLength(2)]
        public string FlagStoreDisPostel { get; set; }
    }
}
