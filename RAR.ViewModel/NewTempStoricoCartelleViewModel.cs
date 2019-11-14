using System;
using System.ComponentModel.DataAnnotations;


namespace RAR.ViewModel
{
    public class NewTempStoricoCartelleViewModel
    {

        public string CodeRaccEsaracc { get; set; }

        [Display(Name = "Id distinta")]
        public int? IdFileNameEsaracc { get; set; }

        [Display(Name = "ID dispaccio plichi al cliente")]
        public int? IdDispaccioOutEsaracc { get; set; }

        [Display(Name = "Numero Cartellazione")]
        public string ProgressivoUtenteEsaracc { get; set; }

        [Display(Name = "Data acquisizione esito")]
        public DateTime? DataElabEsaracc { get; set; }

        [Display(Name = "Data acquisizione distinta")]
        public DateTime? DataLoadDatiEsaracc { get; set; }

        [Display(Name = "Provincia")]
        public string LocalitaEsaracc { get; set; }

        [Display(Name = "Data Notifica")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificaEsaracc { get; set; }

        [Display(Name = "Destinatario")]
        public string DestinatarioEsaracc { get; set; }


        [Display(Name = "Codice Cap Destinatario")]
        public string CodeCapDestEsaracc { get; set; }

        [Display(Name = "Localita Destinatario")]
        public string LocDestEsaracc { get; set; }

        [Display(Name = "Via Destinatario")]
        public string ViaDestEsaracc { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoEsaracc { get; set; }

        [Display(Name = "Flag Fonte Esito")]
        public string FlagFonteEsitoEsaracc { get; set; }

        [Display(Name = "Motivo di Restituzione")]
        public string CodiceMotivoEsaracc { get; set; }

        [Display(Name = "File acquisizione Esito")]
        public string FileNameArEsaracc { get; set; }

        [Display(Name = "Codice Operatore")]
        public string CodeOpeDeEsaracc { get; set; }

        [Display(Name = "Codice Cliente")]
        public string CodiceZetaDistpostel { get; set; }

        [Display(Name = "Numero pezzi in Distinta")]
        public int? TotLettereDistpostel { get; set; }

        [Display(Name = "Data Caricamento Distinta")]
        public DateTime? DataLoadDistPostelDistpostel { get; set; }

        [Display(Name = "Nome Distinta")]
        public string NumeroDistintaDistpostel { get; set; }

        [Display(Name = "Data Spedizione")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataSpedizioneDistpostel { get; set; }

        [Display(Name = "Tipo di prodotto")]
        public string FlagTipoDocDistpostel { get; set; }

        [Display(Name = "Grammatura")]
        public string GrammaturaDistpostel { get; set; }

        [Display(Name = "ID dispaccio plichi al cliente")]
        public int? IdDispaccioOutNewpozzoes { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoNewpozzoes { get; set; }

        [Display(Name = "Flag Fonte Esito")]
        public string FlagFonteEsitoNewpozzoes { get; set; }

        [Display(Name = "File acquisizione esito")]
        public string FileNameArNewpozzoes { get; set; }

        [Display(Name = "Data acquisizione distinta")]
        public DateTime? DataLoadDatiNewpozzoes { get; set; }

        [Display(Name = "Data acquisizione esito")]
        public DateTime? DataElabNewpozzoes { get; set; }

        [Display(Name = "Data Notifica")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificaNewpozzoes { get; set; }

        [Display(Name = "Motivo di Restituzione")]
        public string CodiceMotivoNewpozzoes { get; set; }

        [Display(Name = "Codice Operatore")]
        public string CodeOpeDeNewpozzoes { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoRendes { get; set; }

        [Display(Name = "Flag Fonte Esito")]
        public string FlagFonteEsitoRendes { get; set; }

        [Display(Name = "File acquisizione esito")]
        public string FileNameArRendes { get; set; }

        [Display(Name = "Data Load Dati")]
        public DateTime? DataLoadDatiRendes { get; set; }

        [Display(Name = "Data rendicontazione finale")]
        public DateTime? DataElabRendes { get; set; }

        [Display(Name = "Data Notifica")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificaRendes { get; set; }

        [Display(Name = "ID dispaccio plichi al cliente")]
        public int? DispaccioOutRendes { get; set; }

        [Display(Name = "File inviato da Postel ad Eqs")]
        public string FileNameEstrattoRendes { get; set; }

        [Display(Name = "Data rendicontazione finale")]
        public DateTime? DataEstrazioneRendes { get; set; }

        [Display(Name = "Data acquisizione esito")]
        public DateTime? DataElabNewdisguidi { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoNewdisguidi { get; set; }

        [Display(Name = "Flag Fonte Esito")]
        public string FlagFonteEsitoNewdisguidi { get; set; }

        [Display(Name = "Motivo di Restituzione")]
        public string CodiceMotivoNewdisguidi { get; set; }

        [Display(Name = "Codice Operatore")]
        public string CodeOpeDeNewdisguidi { get; set; }

        [Display(Name = "Data Notifica")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificaNewdisguidi { get; set; }

        [Display(Name = "Data Disguido")]
        public DateTime? DataDisguidoNewdisguidi { get; set; }

        [Display(Name = "Data Elaborazione")]
        public DateTime? DataElaborazioneNewdisguidi { get; set; }

        [Display(Name = "Elaborato")]
        public bool? ElaboratoNewdisguidi { get; set; }

        [Display(Name = "ID dispaccio plichi al cliente")]
        public int? IdDispaccioOutNewdisguidi { get; set; }

        [Display(Name = "Id File Name")]
        public int? IdFileNameNewescorret { get; set; }

        [Display(Name = "Id Dispaccio Out")]
        public int? IdDispaccioOutNewescorret { get; set; }

        [Display(Name = "Progressivo Utente")]
        public string ProgressivoUtenteNewescorret { get; set; }

        [Display(Name = "Data Elab")]
        public DateTime? DataElabNewescorret { get; set; }

        [Display(Name = "Data Load Dati")]
        public DateTime? DataLoadDatiNewescorret { get; set; }

        [Display(Name = "Data Notifica")]
        public DateTime? DataNotificaNewescorret { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoNewescorret { get; set; }

        //public string FlagFonteEsitoNewescorret { get; set; }
        //public string CodiceMotivoNewescorret { get; set; }
        //public string FileNameArNewescorret { get; set; }
        //public string CodeOpeDeNewescorret { get; set; }
        //public byte? TsNewescorret { get; set; }
        //public string CodiceAnomaliaNewescorret { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoNewestt { get; set; }

        [Display(Name = "Canale")]
        public string CanaleNewestt { get; set; }

        [Display(Name = "File acquisizione esito T&T")]
        public string FileNameArNewestt { get; set; }

        [Display(Name = "Data acquisizione esito da T&T")]
        public DateTime? DataLoadDatiNewestt { get; set; }

        [Display(Name = "Data Traccia")]
        public DateTime? DataTracciaNewestt { get; set; }

        [Display(Name = "Data Notifica")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificaNewestt { get; set; }
        //public string NomeFileZipNewscapoimm { get; set; }
        //public DateTime? DataArrivoFileZipNewscapoimm { get; set; }
        //public DateTime? DataEsitoNewscaimmeqt { get; set; }
        //public DateTime? DataGenerazioneFileNewinvflussimm { get; set; }
        //public string NomeFileNewinvflussimm { get; set; }


        public string CodeRaccNlrendes { get; set; }

        [Display(Name = "Codice Esito")]
        public string CodiceEsitoNlrendes { get; set; }

        [Display(Name = "Flag Fonte Esito")]
        public string FlagFonteEsitoNlrendes { get; set; }

        [Display(Name = "Nome File AR")]
        public string FileNameArNlrendes { get; set; }

        [Display(Name = "Data Load Dati")]
        public DateTime? DataLoadDatiNlrendes { get; set; }

        [Display(Name = "Data Elaborazione")]
        public DateTime? DataElabNlrendes { get; set; }

        [Display(Name = "Data Notifica")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNotificaNlrendes { get; set; }

        [Display(Name = "Id Dispaccio out")]
        public int? DispaccioOutNlrendes { get; set; }

        [Display(Name = "File inviato da Postel ad Eqs")]
        public string FileNameEstrattoNlrendes { get; set; }
        [Display(Name = "Data Estrazione")]
        public DateTime? DataEstrazioneNlrendes { get; set; }

    }
}
