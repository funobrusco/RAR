using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("New_Esito_Corretto")]
    public partial class NewEsitoCorretto
    {
        public int Id { get; set; }
        [Required]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("id_file_name")]
        public int IdFileName { get; set; }
        [Column("ID_DISPACCIO_OUT")]
        public int? IdDispaccioOut { get; set; }
        [Required]
        [Column("progressivo_utente")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Column("data_elab", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
        [Column("data_load_dati", TypeName = "smalldatetime")]
        public DateTime? DataLoadDati { get; set; }
        [Column("data_notifica", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Required]
        [Column("codice_esito")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Required]
        [Column("flag_fonte_esito")]
        [StringLength(1)]
        public string FlagFonteEsito { get; set; }
        [Column("codice_motivo")]
        [StringLength(2)]
        public string CodiceMotivo { get; set; }
        [Column("file_name_ar")]
        [StringLength(25)]
        public string FileNameAr { get; set; }
        [Column("code_ope_de")]
        [StringLength(50)]
        public string CodeOpeDe { get; set; }
        [Column("TS")]
        public byte? Ts { get; set; }
        [Column("CODICE_ANOMALIA")]
        [StringLength(5)]
        public string CodiceAnomalia { get; set; }
        [Column("CHIAVE")]
        [StringLength(17)]
        public string Chiave { get; set; }
        [Column("Data_Operazione", TypeName = "smalldatetime")]
        public DateTime? DataOperazione { get; set; }
    }
}
