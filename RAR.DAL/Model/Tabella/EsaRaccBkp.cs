using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("ESA_RACC_BKP")]
    public partial class EsaRaccBkp
    {
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
        [Column("code_uff_recap")]
        [StringLength(50)]
        public string CodeUffRecap { get; set; }
        [Column("LOCALITA")]
        [StringLength(50)]
        public string Localita { get; set; }
        [Column("data_notifica", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Required]
        [Column("destinatario")]
        [StringLength(88)]
        public string Destinatario { get; set; }
        [Required]
        [Column("code_cap_dest")]
        [StringLength(5)]
        public string CodeCapDest { get; set; }
        [Required]
        [Column("loc_dest")]
        [StringLength(44)]
        public string LocDest { get; set; }
        [Required]
        [Column("via_dest")]
        [StringLength(44)]
        public string ViaDest { get; set; }
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
        [Column("flag_ar_data")]
        [StringLength(1)]
        public string FlagArData { get; set; }
        [Column("file_name_ar")]
        [StringLength(16)]
        public string FileNameAr { get; set; }
        [Column("code_ope_de")]
        [StringLength(5)]
        public string CodeOpeDe { get; set; }
        [Column("DA_TIMBRO")]
        [StringLength(1)]
        public string DaTimbro { get; set; }
        [Column("INDICATIVO_FESTIVO")]
        [StringLength(1)]
        public string IndicativoFestivo { get; set; }
        [Column("CODE_UPDATE")]
        [StringLength(3)]
        public string CodeUpdate { get; set; }
        [Column("TS")]
        public byte[] Ts { get; set; }
        [Column("ID_UFF_RECAP")]
        public int? IdUffRecap { get; set; }
        [Column("data_Bonifica", TypeName = "datetime")]
        public DateTime DataBonifica { get; set; }
    }
}
