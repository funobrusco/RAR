using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RAR.DAL.Model.CustomModel
{
    public partial class EseguiQuery
    {
        [Column("code_racc")]
        public string CodeRacc { get; set; }
        [Column("id_file_name")]
        public int IdFileName { get; set; }
        [Column("ID_DISPACCIO_OUT")]
        public int? IdDispaccioOut { get; set; }
        [Column("progressivo_utente")]
        public string ProgressivoUtente { get; set; }
        [Column("data_elab", TypeName = "smalldatetime")]
        public DateTime? DataElab { get; set; }
        [Column("data_load_dati", TypeName = "smalldatetime")]
        public DateTime? DataLoadDati { get; set; }
        [Column("code_uff_recap")]
        public string CodeUffRecap { get; set; }
        [Column("LOCALITA")]
        public string Localita { get; set; }
        [Column("data_notifica", TypeName = "smalldatetime")]
        public DateTime? DataNotifica { get; set; }
        [Column("destinatario")]
        public string Destinatario { get; set; }
        [Column("code_cap_dest")]
        public string CodeCapDest { get; set; }
        [Column("loc_dest")]
        public string LocDest { get; set; }
        [Column("via_dest")]
        public string ViaDest { get; set; }
        [Column("codice_esito")]
        public string CodiceEsito { get; set; }
        [Column("flag_fonte_esito")]
        public string FlagFonteEsito { get; set; }
        [Column("codice_motivo")]
        public string CodiceMotivo { get; set; }
        [Column("flag_ar_data")]
        public string FlagArData { get; set; }
        [Column("file_name_ar")]
        public string FileNameAr { get; set; }
        [Column("code_ope_de")]
        public string CodeOpeDe { get; set; }
        [Column("DA_TIMBRO")]
        public string DaTimbro { get; set; }
        [Column("INDICATIVO_FESTIVO")]
        public string IndicativoFestivo { get; set; }
        [Column("CODE_UPDATE")]
        public string CodeUpdate { get; set; }
        [Column("ID_UFF_RECAP")]
        public int? IdUffRecap { get; set; }
        [Column("TS")]
        public byte? Ts { get; set; }
        [Column("Flag_Vecchie_Raccomandate")]
        public string FlagVecchieRaccomandate { get; set; }
        [Column("CODE_UTENTE")]
        public string CodeUtente { get; set; }
        [Column("FILE_NAME")]
        public string FileName { get; set; }
        [Column("ID_UTENTE")]
        public string IdUtente { get; set; }
        [Column("NOME_LOTTO")]
        public string NomeLotto { get; set; }
        [Column("TOT_LETTERE")]
        public int TotLettere { get; set; }
        [Column("DATA_LOAD_DIST_POSTEL", TypeName = "smalldatetime")]
        public DateTime DataLoadDistPostel { get; set; }
        [Column("SOTTO_CODICE_UTENTE")]
        public string SottoCodiceUtente { get; set; }
        [Column("NUMERO_DISTINTA")]
        public string NumeroDistinta { get; set; }
        [Column("DATA_SPEDIZIONE", TypeName = "smalldatetime")]
        public DateTime? DataSpedizione { get; set; }
        [Column("DATA_FILE_RISPOSTA", TypeName = "smalldatetime")]
        public DateTime? DataFileRisposta { get; set; }
        [Column("FLAG_NUMERO_INVIO")]
        public int FlagNumeroInvio { get; set; }
        [Column("DATA_ULTIMA_INTER_SCONOSCIUTI", TypeName = "smalldatetime")]
        public DateTime? DataUltimaInterSconosciuti { get; set; }
        [Column("DATA_COMUNICAZIONE_ESITI", TypeName = "smalldatetime")]
        public DateTime? DataComunicazioneEsiti { get; set; }
        [Column("DATA_COMUNICAZIONE_ESITI_PREC", TypeName = "smalldatetime")]
        public DateTime? DataComunicazioneEsitiPrec { get; set; }
        [Column("FLAG_TIPO_DOC")]
        public string FlagTipoDoc { get; set; }
        [Column("FLAG_STATO_TT")]
        public string FlagStatoTt { get; set; }
        [Column("FLAG_STATO_TERR")]
        public string FlagStatoTerr { get; set; }
        [Column("NUMERO_RIFERIMENTO")]
        public string NumeroRiferimento { get; set; }
        [Column("GRAMMATURA")]
        public string Grammatura { get; set; }
    }
}
