using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.Tabella
{
    [Table("RACC_TEMP")]
    public partial class RaccTemp
    {
        [Key]
        [Column("code_racc")]
        [StringLength(12)]
        public string CodeRacc { get; set; }
        [Column("id_file_name")]
        public int? IdFileName { get; set; }
        [Column("ID_DISPACCIO_OUT")]
        public int? IdDispaccioOut { get; set; }
        [Column("progressivo_utente")]
        [StringLength(20)]
        public string ProgressivoUtente { get; set; }
        [Column("destinatario")]
        [StringLength(88)]
        public string Destinatario { get; set; }
        [Column("code_cap_dest")]
        [StringLength(5)]
        public string CodeCapDest { get; set; }
        [Column("loc_dest")]
        [StringLength(44)]
        public string LocDest { get; set; }
        [Column("via_dest")]
        [StringLength(44)]
        public string ViaDest { get; set; }
        [Column("codice_esito")]
        [StringLength(2)]
        public string CodiceEsito { get; set; }
        [Column("flag_fonte_esito")]
        [StringLength(1)]
        public string FlagFonteEsito { get; set; }
        [Column("data_elab", TypeName = "datetime")]
        public DateTime? DataElab { get; set; }
        [Column("data_load_dati", TypeName = "datetime")]
        public DateTime? DataLoadDati { get; set; }
        [Column("data_notifica", TypeName = "datetime")]
        public DateTime? DataNotifica { get; set; }
        [Column("localita")]
        [StringLength(20)]
        public string Localita { get; set; }
        [Column("codice_motivo")]
        [StringLength(2)]
        public string CodiceMotivo { get; set; }
        [Column("code_op_de")]
        [StringLength(50)]
        public string CodeOpDe { get; set; }
        [Column("tabella_provenienza")]
        [StringLength(1)]
        public string TabellaProvenienza { get; set; }
    }
}
