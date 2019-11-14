using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using System.Linq;

namespace RAR.DAL.Model.Tabella
{
    public partial class RARContext : DbContext, IRARContext
    {
        public RARContext()
        {
        }

        public RARContext(DbContextOptions<RARContext> options)
            : base(options)
        {
            ConnectionString = options.FindExtension<SqlServerOptionsExtension>().ConnectionString;
        }
        public string ConnectionString { get; private set; }
        public virtual DbSet<AggiornaIntesaFiliali> AggiornaIntesaFiliali { get; set; }
        public virtual DbSet<AmbitoProvinciale> AmbitoProvinciale { get; set; }
        public virtual DbSet<ArchivioRelata> ArchivioRelata { get; set; }
        public virtual DbSet<Banca> Banca { get; set; }
        public virtual DbSet<CapDistinti> CapDistinti { get; set; }
        public virtual DbSet<CapparioUffici> CapparioUffici { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<CodiciSmarriti> CodiciSmarriti { get; set; }
        public virtual DbSet<CodiciTt> CodiciTt { get; set; }
        public virtual DbSet<ComunicazioneEsiti> ComunicazioneEsiti { get; set; }
        public virtual DbSet<Concessione> Concessione { get; set; }
        public virtual DbSet<ConcessioniAttive> ConcessioniAttive { get; set; }
        public virtual DbSet<ConfigCmp> ConfigCmp { get; set; }
        public virtual DbSet<ConfigCodiceEsito> ConfigCodiceEsito { get; set; }
        public virtual DbSet<ConfigCodiciCmp> ConfigCodiciCmp { get; set; }
        public virtual DbSet<ConfigFlagArData> ConfigFlagArData { get; set; }
        public virtual DbSet<ConfigFlagElab> ConfigFlagElab { get; set; }
        public virtual DbSet<ConfigFlagEsito> ConfigFlagEsito { get; set; }
        public virtual DbSet<ConfigFlagFonteEsito> ConfigFlagFonteEsito { get; set; }
        public virtual DbSet<ConfigFlagSottoEsito> ConfigFlagSottoEsito { get; set; }
        public virtual DbSet<ConfigFlagStatoComunicazione> ConfigFlagStatoComunicazione { get; set; }
        public virtual DbSet<ConfigFlagStatoLav> ConfigFlagStatoLav { get; set; }
        public virtual DbSet<ConfigFlagStatoLavAr> ConfigFlagStatoLavAr { get; set; }
        public virtual DbSet<ConfigFlagStatoPlico> ConfigFlagStatoPlico { get; set; }
        public virtual DbSet<ConfigFlagStatoScatola> ConfigFlagStatoScatola { get; set; }
        public virtual DbSet<ConfigFlagStatoScatolaRitorno> ConfigFlagStatoScatolaRitorno { get; set; }
        public virtual DbSet<ConfigFlagTipoAcquisizione> ConfigFlagTipoAcquisizione { get; set; }
        public virtual DbSet<ConfigFlagTipoPersona> ConfigFlagTipoPersona { get; set; }
        public virtual DbSet<ConfigFlagTipoScatola> ConfigFlagTipoScatola { get; set; }
        public virtual DbSet<ConfigFlagTipoScatolaRitorno> ConfigFlagTipoScatolaRitorno { get; set; }
        public virtual DbSet<ConfigLogicaRendicontazione> ConfigLogicaRendicontazione { get; set; }
        public virtual DbSet<ConfigMotiviRestituzione> ConfigMotiviRestituzione { get; set; }
        public virtual DbSet<ConfigMotivoScartoAr> ConfigMotivoScartoAr { get; set; }
        public virtual DbSet<ConfigRangePenali> ConfigRangePenali { get; set; }
        public virtual DbSet<ConfigSostFlagStato> ConfigSostFlagStato { get; set; }
        public virtual DbSet<ConfigSostFlagStatoScatola> ConfigSostFlagStatoScatola { get; set; }
        public virtual DbSet<ConfigSostFlagStatoTt> ConfigSostFlagStatoTt { get; set; }
        public virtual DbSet<ConfigStatoFlusso> ConfigStatoFlusso { get; set; }
        public virtual DbSet<ConfigStatoRacc> ConfigStatoRacc { get; set; }
        public virtual DbSet<ConfigTipoAnomalia> ConfigTipoAnomalia { get; set; }
        public virtual DbSet<ConfigTipoConsegna> ConfigTipoConsegna { get; set; }
        public virtual DbSet<ConsegnatoCmpService> ConsegnatoCmpService { get; set; }
        public virtual DbSet<DatiFlashNews> DatiFlashNews { get; set; }
        public virtual DbSet<DenominazioneSociale> DenominazioneSociale { get; set; }
        public virtual DbSet<Dipendenze> Dipendenze { get; set; }
        public virtual DbSet<DispaccioIn> DispaccioIn { get; set; }
        public virtual DbSet<DispaccioOut> DispaccioOut { get; set; }
        public virtual DbSet<DistintaPostel> DistintaPostel { get; set; }
        public virtual DbSet<DistintaPostelStorico> DistintaPostelStorico { get; set; }
        public virtual DbSet<EsaRacc> EsaRacc { get; set; }
        public virtual DbSet<EsaRaccBkp> EsaRaccBkp { get; set; }
        public virtual DbSet<EsaRaccCmp> EsaRaccCmp { get; set; }
        public virtual DbSet<EsaRaccStore> EsaRaccStore { get; set; }
        public virtual DbSet<EsaRaccStorico> EsaRaccStorico { get; set; }
        public virtual DbSet<EsaRaccTipoConsegna> EsaRaccTipoConsegna { get; set; }
        public virtual DbSet<EsitiDaFiliali> EsitiDaFiliali { get; set; }
        public virtual DbSet<EsitiDaFilialiSenzadata> EsitiDaFilialiSenzadata { get; set; }
        public virtual DbSet<FileLivorno> FileLivorno { get; set; }
        public virtual DbSet<Filiali> Filiali { get; set; }
        public virtual DbSet<GamAvvisiMoraIntesa> GamAvvisiMoraIntesa { get; set; }
        public virtual DbSet<GamCodiciTt> GamCodiciTt { get; set; }
        public virtual DbSet<GsAccettazioneArIncomplete> GsAccettazioneArIncomplete { get; set; }
        public virtual DbSet<GsDatiImgAr> GsDatiImgAr { get; set; }
        public virtual DbSet<GsRiepilogoScatole> GsRiepilogoScatole { get; set; }
        public virtual DbSet<GsSostitutiviAr> GsSostitutiviAr { get; set; }
        public virtual DbSet<ImgAr> ImgAr { get; set; }
        public virtual DbSet<ImgRelata> ImgRelata { get; set; }
        public virtual DbSet<IndicizzazioneEsaRacc> IndicizzazioneEsaRacc { get; set; }
        public virtual DbSet<LayoutStampanteZebra> LayoutStampanteZebra { get; set; }
        public virtual DbSet<LocalTemp> LocalTemp { get; set; }
        public virtual DbSet<Lotto> Lotto { get; set; }
        public virtual DbSet<MessiAnagrafica> MessiAnagrafica { get; set; }
        public virtual DbSet<MessoCodiciLivorno> MessoCodiciLivorno { get; set; }
        public virtual DbSet<MultiCap> MultiCap { get; set; }
        public virtual DbSet<MultiUfficio> MultiUfficio { get; set; }
        public virtual DbSet<NewAmbitoProvinciale> NewAmbitoProvinciale { get; set; }
        public virtual DbSet<NewAnagraficaFlussiPostel> NewAnagraficaFlussiPostel { get; set; }
        public virtual DbSet<NewBufferDistintaFittizia> NewBufferDistintaFittizia { get; set; }
        public virtual DbSet<NewBufferFileCorrotti> NewBufferFileCorrotti { get; set; }
        public virtual DbSet<NewBufferFileSelettivoCorrotti> NewBufferFileSelettivoCorrotti { get; set; }
        public virtual DbSet<NewCartolineDispaccioIn> NewCartolineDispaccioIn { get; set; }
        public virtual DbSet<NewCodeRaccStoricoCartelle> NewCodeRaccStoricoCartelle { get; set; }
        public virtual DbSet<NewCodiciAnomalia> NewCodiciAnomalia { get; set; }
        public virtual DbSet<NewCodiciCmp> NewCodiciCmp { get; set; }
        public virtual DbSet<NewCodiciErroriDaTt> NewCodiciErroriDaTt { get; set; }
        public virtual DbSet<NewDenominazioneSociale> NewDenominazioneSociale { get; set; }
        public virtual DbSet<NewDisguidi> NewDisguidi { get; set; }
        public virtual DbSet<NewDispacciJobCancellati> NewDispacciJobCancellati { get; set; }
        public virtual DbSet<NewDispaccioIn> NewDispaccioIn { get; set; }
        public virtual DbSet<NewElencoFileInput> NewElencoFileInput { get; set; }
        public virtual DbSet<NewElencoFileOutput> NewElencoFileOutput { get; set; }
        public virtual DbSet<NewElencoQuery> NewElencoQuery { get; set; }
        public virtual DbSet<NewEsitiDaTt> NewEsitiDaTt { get; set; }
        public virtual DbSet<NewEsitiDaTtBkp> NewEsitiDaTtBkp { get; set; }
        public virtual DbSet<NewEsitoCorretto> NewEsitoCorretto { get; set; }
        public virtual DbSet<NewFlussiInputRaw> NewFlussiInputRaw { get; set; }
        public virtual DbSet<NewFlussiOutputRaw> NewFlussiOutputRaw { get; set; }
        public virtual DbSet<NewImmagini> NewImmagini { get; set; }
        public virtual DbSet<NewImmaginiA99> NewImmaginiA99 { get; set; }
        public virtual DbSet<NewImmaginiPmr> NewImmaginiPmr { get; set; }
        public virtual DbSet<NewLavorazioneVerificaDistintaElettronica> NewLavorazioneVerificaDistintaElettronica { get; set; }
        public virtual DbSet<NewParametri> NewParametri { get; set; }
        public virtual DbSet<NewRendicontazioneCoordinateArchiviazioneNsin> NewRendicontazioneCoordinateArchiviazioneNsin { get; set; }
        public virtual DbSet<NewRendicontazioneEsitiNsin> NewRendicontazioneEsitiNsin { get; set; }
        public virtual DbSet<NewRendicontazioneImmaginiNsin> NewRendicontazioneImmaginiNsin { get; set; }
        public virtual DbSet<NewScambioEsitiTt> NewScambioEsitiTt { get; set; }
        public virtual DbSet<NewScambioNapoliImmagini> NewScambioNapoliImmagini { get; set; }
        public virtual DbSet<NewScartiTt> NewScartiTt { get; set; }
        public virtual DbSet<NewServiceRestituzioneAr> NewServiceRestituzioneAr { get; set; }
        public virtual DbSet<NewServiceRestituzioneCd> NewServiceRestituzioneCd { get; set; }
        public virtual DbSet<NewServiceRestituzioneCdScatola> NewServiceRestituzioneCdScatola { get; set; }
        public virtual DbSet<NewServiceRestituzioneFile> NewServiceRestituzioneFile { get; set; }
        public virtual DbSet<NewStagingPostelFlussi> NewStagingPostelFlussi { get; set; }
        public virtual DbSet<NewStagingPostelImmagini> NewStagingPostelImmagini { get; set; }
        public virtual DbSet<NewStoricoXmlTracciatura> NewStoricoXmlTracciatura { get; set; }
        public virtual DbSet<NewTipoesitoDaTt> NewTipoesitoDaTt { get; set; }
        public virtual DbSet<Param> Param { get; set; }
        public virtual DbSet<PatentiLibretti> PatentiLibretti { get; set; }
        public virtual DbSet<ProgressiviUtenteRipetuti> ProgressiviUtenteRipetuti { get; set; }
        public virtual DbSet<QualitaArLamezia> QualitaArLamezia { get; set; }
        public virtual DbSet<QualitaArVerona> QualitaArVerona { get; set; }
        public virtual DbSet<Query> Query { get; set; }
        public virtual DbSet<Querynew> Querynew { get; set; }
        public virtual DbSet<RaccAr> RaccAr { get; set; }
        public virtual DbSet<RaccEsitate> RaccEsitate { get; set; }
        public virtual DbSet<RaccPlichiMesso> RaccPlichiMesso { get; set; }
        public virtual DbSet<RaccTemp> RaccTemp { get; set; }
        public virtual DbSet<RendicontazioneMesso> RendicontazioneMesso { get; set; }
        public virtual DbSet<RiepilogoStorico> RiepilogoStorico { get; set; }
        public virtual DbSet<ScartatoGiornaliero> ScartatoGiornaliero { get; set; }
        public virtual DbSet<Scatola> Scatola { get; set; }
        public virtual DbSet<ScatolaAr> ScatolaAr { get; set; }
        public virtual DbSet<ScatolaRitorno> ScatolaRitorno { get; set; }
        public virtual DbSet<ServiceDispaccio> ServiceDispaccio { get; set; }
        public virtual DbSet<ServiceRestituzioneAr> ServiceRestituzioneAr { get; set; }
        public virtual DbSet<ServiceRestituzioneCd> ServiceRestituzioneCd { get; set; }
        public virtual DbSet<ServiceRestituzioneCdScatola> ServiceRestituzioneCdScatola { get; set; }
        public virtual DbSet<ServiceRestituzioneFile> ServiceRestituzioneFile { get; set; }
        public virtual DbSet<SostConfigRend> SostConfigRend { get; set; }
        public virtual DbSet<SostDati> SostDati { get; set; }
        public virtual DbSet<SostImg> SostImg { get; set; }
        public virtual DbSet<SostScatola> SostScatola { get; set; }
        public virtual DbSet<Sysdtslog90> Sysdtslog90 { get; set; }
        public virtual DbSet<TFlussi> TFlussi { get; set; }
        public virtual DbSet<TRaccInvioSelettivoPostel> TRaccInvioSelettivoPostel { get; set; }
        public virtual DbSet<TblPreavvisoCorrispondenza> TblPreavvisoCorrispondenza { get; set; }
        public virtual DbSet<TblPreavvisoRete> TblPreavvisoRete { get; set; }
        public virtual DbSet<TentatoRecapito> TentatoRecapito { get; set; }
        public virtual DbSet<TracciatureArVerona> TracciatureArVerona { get; set; }
        public virtual DbSet<TracciatureIncompletiArLamezia> TracciatureIncompletiArLamezia { get; set; }
        public virtual DbSet<TracciatureIncompletiArVerona> TracciatureIncompletiArVerona { get; set; }
        public virtual DbSet<ViarioUr> ViarioUr { get; set; }
        public virtual DbSet<XmlIndiceImgTemp> XmlIndiceImgTemp { get; set; }
        public virtual DbSet<XmlTemp> XmlTemp { get; set; }
        public virtual DbSet<XmlTempCorrotti> XmlTempCorrotti { get; set; }
        public virtual DbSet<XmlTempFittizia> XmlTempFittizia { get; set; }

        // Unable to generate entity type for table 'dbo.DISTINTA_POSTEL_TEMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Provincie'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Appoggio'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Racc'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Numeri_Riferimento'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Province'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Racc_temp1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Temporanea_Query_40'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RaccTemp'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.glc'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Regione'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.glc01'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.AGGIORNATI_SENZADATA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Regioni'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ALT_RAM_PROV'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.RENDICONTAZIONE_ESITI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Amministratori'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.REPORT_PENALI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.gs_IMG_AR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.report_restituiti'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.gs_IMG_SOST'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Report_Storicizzazione'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.gs_REST_AR_COMPLETE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.aux'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Backlog_NO_CompiutaGiacenza'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.APPO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SCARTI_AR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.appo1'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Elenco_File_GAA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Flussi_GAA_Storico'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPGENERICI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.immagini_da_bonificare'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Log_Caricarimento_Immagini_Postel'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.immagini_doppie'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO_2'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.IMMAGINI_SENZA_ESITO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO_2_CORR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Codici_Immagini'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO_2_OLD'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO_2_RETE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO_OLD'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CAPPARIO_TERRITORIO_CORR_ESA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.cappario_territorio_rete_esa'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Localita'. Please see the warning messages.
        // Unable to generate entity type for table 'ETL.NEW_TMP_Corrotti_Select_Postel_DataEntrySelettivo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.capregione'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Errore_Rendicontazione_Esito'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.appo_elena'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SOST_DATI_STORICO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SOST_DATI_STORICO_TEMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SOST_DATI_TEMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SOST_DATI_TEMP_INCOMPLETI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_AR_INC_FLAG_ANOMALIA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Appoggio_Scarico_Immagini'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_AR_INC_FLAG_MATCH_ESA_RACC'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SOST_PARAMETER'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Anagrafica_GU'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NEW_Calendario'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_AR_INC_FLAG_SCARTO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NEW_CAPGENERICI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_AR_INC_FLAG_STATO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Cappario_Province'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_AR_INC_FLAG_STATO_SCATOLA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.SPACCATURE_UFFICI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Cartelle_Anomale'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Storicizzazione_Log'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_CheckSemantico'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_CheckSintattico'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.new_TMP_VisualizzaAnomalie'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Temporanea_Query_38'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Codici_Errori'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Lavorazione_DataEntrySelettivo'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Temporanea_Query_39'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Config_Flag_Esito_Invio_XML_DISTINTA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.temp_storico_cartelle'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_CONFIG_FLAG_TIPO_DOC'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.new_controllo_applicativi'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Config_ID_Flusso_Postel'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TERR_TEMPLATE_REC_CORR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TERR_TEMPLATE_REC_RETE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NEW_CONFIG_MGMTFLUSSI_POSTEL'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TipoDoc'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TMP_REPORT_CAP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.tmp_report_cap2'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TRACCIATURE_AR_LAMEZIA'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.TRACCIATURE_AR_LAMEZIA_CMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Errori_Decodificati'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UfficiRecapito'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.UR_CAP_Serviti'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiOutput_CAPGENERICI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiOutput_GU'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiOutput_SALTICODICE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiOutput_SCARTI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_FLAG_STATO_UDR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.APPO_VALE'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiOutputAccettazione'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiOutputPostel'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_FLAG_TIPO_DOC'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Lotti_Territoriali'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_immagini_parcheggiate'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Invio_Flusso_Immagini'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Lavorazione_RENDICONTAZIONE_ESITI'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Lavorazione_RENDICONTAZIONE_Immagini'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Lavorazione_Scambio_Postel'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Log'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_SCARTO_UDR'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Pozzo_Esitazioni'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Profilazione_Utenti'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Report_Immagini'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.CONFIG_SOST_FLAG_TIPO_REND'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Report_Scatole'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NEW_Scambio_Immagini_EQT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NEW_Scambio_Postel'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Configurazione'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.T_FILE_ELAB_DTSX_NSIN'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.ESA_RACC_TIPO_CONSEGNA_POZZO'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Scambio_Postel_Immagini'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.new_config_fornitore'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.GU_TMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_SemaforiJobs'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Esiti_Da_TT_Bonificati'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_FlussiBonificheTracking'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Invio_Flusso_Immagini_Pmr'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Log_CaricamentoRendicontazioneNSIN'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Temp_Mio'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Dispacci'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Tracciature_CMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.DISTINTA_POSTEL_CMP'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.distinta_postel_da_lavorare'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Scambio_Flussi_TT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.NEW_Scambio_Immagini_PMR_EQT'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.New_Scarti_AR_Postel'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
           //     optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["equitaliadb"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity<AggiornaIntesaFiliali>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DataEsito).IsUnicode(false);

                entity.Property(e => e.Esito).IsUnicode(false);
            });

            modelBuilder.Entity<AmbitoProvinciale>(entity =>
            {
                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.SottoCodiceUtente).IsUnicode(false);

                entity.HasOne(d => d.IdDenominazioneSocialeNavigation)
                    .WithMany(p => p.AmbitoProvinciale)
                    .HasForeignKey(d => d.IdDenominazioneSociale)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ambito_Provinciale_Denominazione_Sociale");
            });

            modelBuilder.Entity<ArchivioRelata>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeOpMast).IsUnicode(false);

                entity.Property(e => e.CodeOpScan).IsUnicode(false);

                entity.Property(e => e.FlagElab).IsUnicode(false);

                entity.Property(e => e.FlagStatoLav).IsUnicode(false);

                entity.Property(e => e.FlagTipoAcquisizione).IsUnicode(false);

                entity.HasOne(d => d.CodeRaccNavigation)
                    .WithOne(p => p.ArchivioRelata)
                    .HasForeignKey<ArchivioRelata>(d => d.CodeRacc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARCHIVIO_RELATA_RACC_PLICHI_MESSO");

                entity.HasOne(d => d.FlagElabNavigation)
                    .WithMany(p => p.ArchivioRelata)
                    .HasForeignKey(d => d.FlagElab)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARCHIVIO_RELATA_CONFIG_FLAG_ELAB");

                entity.HasOne(d => d.FlagStatoLavNavigation)
                    .WithMany(p => p.ArchivioRelata)
                    .HasForeignKey(d => d.FlagStatoLav)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARCHIVIO_RELATA_CONFIG_FLAG_STATO_LAV");

                entity.HasOne(d => d.FlagTipoAcquisizioneNavigation)
                    .WithMany(p => p.ArchivioRelata)
                    .HasForeignKey(d => d.FlagTipoAcquisizione)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARCHIVIO_RELATA_CONFIG_FLAG_TIPO_ACQUISIZIONE");

                entity.HasOne(d => d.IdScatolaRitornoNavigation)
                    .WithMany(p => p.ArchivioRelata)
                    .HasForeignKey(d => d.IdScatolaRitorno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ARCHIVIO_RELATA_SCATOLA_RITORNO");
            });

            modelBuilder.Entity<Banca>(entity =>
            {
                entity.HasKey(e => e.IdBanca)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeCapBanca).IsUnicode(false);

                entity.Property(e => e.DescrizioneBanca).IsUnicode(false);

                entity.Property(e => e.DescrizioneInsiemeBanche).IsUnicode(false);

                entity.Property(e => e.EMail).IsUnicode(false);

                entity.Property(e => e.Intestazione).IsUnicode(false);

                entity.Property(e => e.LocBanca).IsUnicode(false);

                entity.Property(e => e.LogicaRendicontazione).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.ViaBanca).IsUnicode(false);

                entity.HasOne(d => d.LogicaRendicontazioneNavigation)
                    .WithMany(p => p.Banca)
                    .HasForeignKey(d => d.LogicaRendicontazione)
                    .HasConstraintName("FK_BANCA_CONFIG_LOGICA_RENDICONTAZIONE");
            });

            modelBuilder.Entity<CapDistinti>(entity =>
            {
                entity.HasKey(e => e.Cap)
                    .HasName("PK_Results");

                entity.Property(e => e.Cap)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Capoluogo).IsUnicode(false);

                entity.Property(e => e.Filiale).IsUnicode(false);

                entity.Property(e => e.Regione).IsUnicode(false);
            });

            modelBuilder.Entity<CapparioUffici>(entity =>
            {
                entity.Property(e => e.Cap)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AgenziaRecapito).IsUnicode(false);

                entity.Property(e => e.Tipo).IsUnicode(false);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.CodeUtente)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.CodeUtente, e.RendSenzaDataNotif })
                    .HasName("IX_CLIENTE_SPEED_1");

                entity.Property(e => e.CodeUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeCapCliente).IsUnicode(false);

                entity.Property(e => e.CodeCliente).IsUnicode(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.EMail).IsUnicode(false);

                entity.Property(e => e.LocCliente).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.ViaCliente).IsUnicode(false);

                entity.HasOne(d => d.IdBancaNavigation)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.IdBanca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CLIENTE_BANCA");
            });

            modelBuilder.Entity<CodiciSmarriti>(entity =>
            {
                entity.HasKey(e => new { e.CodiceInvio, e.DataDenuncia });

                entity.Property(e => e.CodiceInvio).IsUnicode(false);

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.Filename).IsUnicode(false);
            });

            modelBuilder.Entity<CodiciTt>(entity =>
            {
                entity.Property(e => e.CodiceInvio)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Banca).IsUnicode(false);

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.Festivo).IsUnicode(false);

                entity.Property(e => e.Filename).IsUnicode(false);

                entity.Property(e => e.Flag).IsUnicode(false);

                entity.Property(e => e.Ufficio1).IsUnicode(false);

                entity.Property(e => e.Ufficio2).IsUnicode(false);

                entity.Property(e => e.UfficioAccettazione).IsUnicode(false);
            });

            modelBuilder.Entity<ComunicazioneEsiti>(entity =>
            {
                entity.Property(e => e.CodeConcessione).IsUnicode(false);

                entity.Property(e => e.CodeUtente).IsUnicode(false);
            });

            modelBuilder.Entity<Concessione>(entity =>
            {
                entity.HasKey(e => e.IdConcessione)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeCapConcessione).IsUnicode(false);

                entity.Property(e => e.CodeConcessione).IsUnicode(false);

                entity.Property(e => e.CodeUtente).IsUnicode(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.EMail).IsUnicode(false);

                entity.Property(e => e.IndirizzoSpedizioneFile).IsUnicode(false);

                entity.Property(e => e.LocConcessione).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.ViaConcessione).IsUnicode(false);

                entity.HasOne(d => d.CodeUtenteNavigation)
                    .WithMany(p => p.Concessione)
                    .HasForeignKey(d => d.CodeUtente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONCESSIONE_CLIENTE");
            });

            modelBuilder.Entity<ConcessioniAttive>(entity =>
            {
                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigCmp>(entity =>
            {
                entity.Property(e => e.IdCmp).ValueGeneratedNever();

                entity.Property(e => e.Cap).IsUnicode(false);

                entity.Property(e => e.Indirizzo).IsUnicode(false);

                entity.Property(e => e.Localita).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigCodiceEsito>(entity =>
            {
                entity.Property(e => e.CodiceEsito)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigCodiciCmp>(entity =>
            {
                entity.Property(e => e.DescrizioneUo).IsUnicode(false);

                entity.Property(e => e.Frazionario).IsUnicode(false);

                entity.Property(e => e.NomeImpianto).IsUnicode(false);

                entity.Property(e => e.Polo).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.SiglaProvincia).IsUnicode(false);

                entity.Property(e => e.UnitaOperativa).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagArData>(entity =>
            {
                entity.Property(e => e.CodeFlagArData)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DescrFlagArData).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagElab>(entity =>
            {
                entity.Property(e => e.FlagElab)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagEsito>(entity =>
            {
                entity.Property(e => e.FlagEsito)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagFonteEsito>(entity =>
            {
                entity.Property(e => e.FlagFonteEsito)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagSottoEsito>(entity =>
            {
                entity.Property(e => e.FlagSottoEsito)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.FlagEsito).IsUnicode(false);

                entity.HasOne(d => d.FlagEsitoNavigation)
                    .WithMany(p => p.ConfigFlagSottoEsito)
                    .HasForeignKey(d => d.FlagEsito)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CONFIG_FLAG_SOTTO_ESITO_CONFIG_FLAG_ESITO");
            });

            modelBuilder.Entity<ConfigFlagStatoComunicazione>(entity =>
            {
                entity.HasKey(e => new { e.FlagStatoComunicazione, e.FlagEsito });

                entity.Property(e => e.FlagStatoComunicazione).IsUnicode(false);

                entity.Property(e => e.FlagEsito).IsUnicode(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagStatoLav>(entity =>
            {
                entity.Property(e => e.FlagStatoLav)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagStatoLavAr>(entity =>
            {
                entity.Property(e => e.FlagStatoLavAr)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagStatoPlico>(entity =>
            {
                entity.Property(e => e.FlagStatoPlico)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagStatoScatola>(entity =>
            {
                entity.Property(e => e.FlagStatoScatola)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagStatoScatolaRitorno>(entity =>
            {
                entity.HasKey(e => e.FlagStatoScatolaRitorno)
                    .HasName("PK_COFIG_FLAG_STATO_SCATOLA_RITORNO");

                entity.Property(e => e.FlagStatoScatolaRitorno)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagTipoAcquisizione>(entity =>
            {
                entity.Property(e => e.FlagTipoAcquisizione)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagTipoPersona>(entity =>
            {
                entity.Property(e => e.FlagTipoPersona)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagTipoScatola>(entity =>
            {
                entity.Property(e => e.FlagTipoScatola)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigFlagTipoScatolaRitorno>(entity =>
            {
                entity.Property(e => e.FlagTipoScatolaRitorno)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigLogicaRendicontazione>(entity =>
            {
                entity.Property(e => e.LogicaRendicontazione)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigMotiviRestituzione>(entity =>
            {
                entity.Property(e => e.Codice)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigMotivoScartoAr>(entity =>
            {
                entity.Property(e => e.CodiceMotivo)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigRangePenali>(entity =>
            {
                entity.Property(e => e.CondizioneRange).IsUnicode(false);

                entity.Property(e => e.DescrizioneRange).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigSostFlagStato>(entity =>
            {
                entity.Property(e => e.FlagStato)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigSostFlagStatoScatola>(entity =>
            {
                entity.HasKey(e => e.FlagStatoScatola)
                    .HasName("PK_CONFIG_FLAG_SCATOLA_SOST");

                entity.Property(e => e.FlagStatoScatola)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigSostFlagStatoTt>(entity =>
            {
                entity.Property(e => e.FlagStatoTt)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigStatoFlusso>(entity =>
            {
                entity.HasKey(e => e.IdStatoFlusso)
                    .HasName("PK_ETL_ID_STATO_FLUSSO.CONFIG_STATO_FLUSSO");

                entity.HasIndex(e => e.CodiceStatoFlusso)
                    .IsUnique();

                entity.Property(e => e.CodiceStatoFlusso).IsUnicode(false);

                entity.Property(e => e.NomeStatoFlusso).IsUnicode(false);

                entity.Property(e => e.ScartoParziale).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ConfigStatoRacc>(entity =>
            {
                entity.HasKey(e => e.IdStatoRacc)
                    .HasName("PK_ETL_ID_STATO_RACC.CONFIG_STATO_RACC");

                entity.HasIndex(e => new { e.NomeStatoRacc, e.CodiceStatoRacc })
                    .HasName("IX_CONFIG_STATO_FLUSSO_Codice_Stato_RACC")
                    .IsUnique();

                entity.Property(e => e.CodiceStatoRacc).IsUnicode(false);

                entity.Property(e => e.NomeStatoRacc).IsUnicode(false);

                entity.Property(e => e.ScartoParziale).HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ConfigTipoAnomalia>(entity =>
            {
                entity.Property(e => e.TipoAnomalia)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConfigTipoConsegna>(entity =>
            {
                entity.HasKey(e => e.CodiceTipoConsegna)
                    .HasName("PK__CONFIG_TIPO_CONS__153294EC");

                entity.Property(e => e.CodiceTipoConsegna)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<ConsegnatoCmpService>(entity =>
            {
                entity.HasKey(e => new { e.Cp, e.Mese });

                entity.Property(e => e.Banca).IsUnicode(false);

                entity.Property(e => e.Mittente).IsUnicode(false);
            });

            modelBuilder.Entity<DatiFlashNews>(entity =>
            {
                entity.Property(e => e.Descrizione)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<DenominazioneSociale>(entity =>
            {
                entity.Property(e => e.CodiceZeta).IsUnicode(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<Dipendenze>(entity =>
            {
                entity.HasKey(e => e.IdDipendenze)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeCapDipendenze).IsUnicode(false);

                entity.Property(e => e.CodeDipendenze).IsUnicode(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.EMail).IsUnicode(false);

                entity.Property(e => e.LocDipendenze).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.ViaDipendenze).IsUnicode(false);
            });

            modelBuilder.Entity<DispaccioIn>(entity =>
            {
                entity.HasKey(e => e.IdDispaccioIn)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeDispaccioIn).IsUnicode(false);

                entity.Property(e => e.CodeOpDe).IsUnicode(false);

                entity.Property(e => e.CodeOpeCsc).IsUnicode(false);

                entity.Property(e => e.Mittente).IsUnicode(false);

                entity.Property(e => e.NumPezzi).IsUnicode(false);
            });

            modelBuilder.Entity<DispaccioOut>(entity =>
            {
                entity.HasKey(e => e.IdDispaccioOut)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeCliente).IsUnicode(false);

                entity.Property(e => e.CodeConcessione).IsUnicode(false);

                entity.Property(e => e.CodeDipendenze).IsUnicode(false);

                entity.Property(e => e.CodeRaccSpediz).IsUnicode(false);

                entity.Property(e => e.CodiceOperatore).IsUnicode(false);

                entity.Property(e => e.CodiceScatola).IsUnicode(false);

                entity.Property(e => e.CodiceSito).IsUnicode(false);

                entity.Property(e => e.FlagStatoLavorazioni)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.NumPezzi).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);
            });

            modelBuilder.Entity<DistintaPostel>(entity =>
            {
                entity.HasKey(e => e.IdFileName)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.DataSpedizione, e.IdFileName })
                    .HasName("IX_DISTINTA_POSTEL_ID_FILE_NAME");

                entity.HasIndex(e => new { e.IdFileName, e.DataSpedizione })
                    .HasName("IX_DISTINTA_POSTEL_DATA_SPEDIZIONE");

                entity.Property(e => e.CodeUtente).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.FlagNumeroInvio).HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagStatoTerr)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagStatoTt)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagTipoDoc).IsUnicode(false);

                entity.Property(e => e.Grammatura).IsUnicode(false);

                entity.Property(e => e.IdUtente).IsUnicode(false);

                entity.Property(e => e.NomeLotto).IsUnicode(false);

                entity.Property(e => e.NumeroDistinta).IsUnicode(false);

                entity.Property(e => e.NumeroRiferimento).IsUnicode(false);

                entity.Property(e => e.SottoCodiceUtente).IsUnicode(false);
            });

            modelBuilder.Entity<DistintaPostelStorico>(entity =>
            {
                entity.Property(e => e.IdFileName).ValueGeneratedNever();

                entity.Property(e => e.CodeUtente).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.FlagTipoDoc).IsUnicode(false);

                entity.Property(e => e.NumeroDistinta).IsUnicode(false);

                entity.Property(e => e.SottoCodiceUtente).IsUnicode(false);
            });

            modelBuilder.Entity<EsaRacc>(entity =>
            {
                entity.HasKey(e => e.CodeRacc)
                    .ForSqlServerIsClustered(false);

                entity.HasIndex(e => new { e.CodeRacc, e.FlagVecchieRaccomandate })
                    .HasName("IX_ESA_RACC__Flag_Vecchie_Raccomandate_code_racc");

                entity.HasIndex(e => new { e.DataElab, e.CodiceEsito })
                    .HasName("IX_esa_racc__data_elab_codice_esito");

                entity.HasIndex(e => new { e.DataLoadDati, e.DataElab, e.FileNameAr })
                    .HasName("ix_esa_racc__data_elab_file_name_ar");

                entity.HasIndex(e => new { e.DataLoadDati, e.CodiceEsito, e.CodeRacc, e.IdFileName, e.FlagArData })
                    .HasName("IX_esa_racc_25_new")
                    .ForSqlServerIsClustered();

                entity.HasIndex(e => new { e.CodeRacc, e.CodiceEsito, e.FlagFonteEsito, e.Ts, e.IdFileName, e.DataNotifica })
                    .HasName("ix_ESA_RACC_id_file_namedata_notifica");

                entity.HasIndex(e => new { e.Localita, e.Destinatario, e.CodeCapDest, e.LocDest, e.ViaDest, e.CodiceMotivo, e.DataElab, e.ProgressivoUtente })
                    .HasName("IX_ESA_RACC_Progressivo");

                entity.HasIndex(e => new { e.CodeRacc, e.ProgressivoUtente, e.DataElab, e.Destinatario, e.CodeCapDest, e.LocDest, e.ViaDest, e.CodiceEsito, e.FlagFonteEsito, e.CodiceMotivo, e.IdDispaccioOut })
                    .HasName("ix_ESA_RACC_ID_DISPACCIO_OUT");

                entity.HasIndex(e => new { e.CodeRacc, e.IdFileName, e.IdDispaccioOut, e.ProgressivoUtente, e.DataElab, e.DataLoadDati, e.Localita, e.DataNotifica, e.Destinatario, e.CodeCapDest, e.LocDest, e.ViaDest, e.CodiceEsito, e.FlagFonteEsito, e.CodiceMotivo, e.FileNameAr, e.Ts, e.FlagVecchieRaccomandate })
                    .HasName("ix_ESA_RACC__TS_Flag_Vecchie_Raccomandate");

                entity.HasIndex(e => new { e.CodeRacc, e.IdDispaccioOut, e.ProgressivoUtente, e.DataElab, e.DataLoadDati, e.CodeUffRecap, e.Localita, e.DataNotifica, e.Destinatario, e.CodeCapDest, e.LocDest, e.ViaDest, e.CodiceEsito, e.FlagFonteEsito, e.CodiceMotivo, e.FlagArData, e.FileNameAr, e.CodeOpeDe, e.DaTimbro, e.IndicativoFestivo, e.CodeUpdate, e.IdUffRecap, e.Ts, e.FlagVecchieRaccomandate, e.IdFileName })
                    .HasName("ix_ESA_RACC_id_file_name___id_file_name");

                entity.HasIndex(e => new { e.CodeRacc, e.IdFileName, e.IdDispaccioOut, e.ProgressivoUtente, e.DataElab, e.DataLoadDati, e.CodeUffRecap, e.Localita, e.DataNotifica, e.Destinatario, e.CodeCapDest, e.LocDest, e.ViaDest, e.CodiceEsito, e.FlagFonteEsito, e.CodiceMotivo, e.FlagArData, e.FileNameAr, e.CodeOpeDe, e.DaTimbro, e.IndicativoFestivo, e.CodeUpdate, e.IdUffRecap, e.FlagVecchieRaccomandate, e.Ts })
                    .HasName("ix_ESA_RACC___TS");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.CodeOpeDe).IsUnicode(false);

                entity.Property(e => e.CodeUffRecap).IsUnicode(false);

                entity.Property(e => e.CodeUpdate).IsUnicode(false);

                entity.Property(e => e.CodiceEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('99')");

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.DaTimbro).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FlagArData).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Z')");

                entity.Property(e => e.FlagVecchieRaccomandate).IsUnicode(false);

                entity.Property(e => e.IndicativoFestivo).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.Localita).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.Ts).HasDefaultValueSql("((0))");

                entity.Property(e => e.ViaDest).IsUnicode(false);
            });

            modelBuilder.Entity<EsaRaccBkp>(entity =>
            {
                entity.HasKey(e => new { e.CodeRacc, e.DataBonifica })
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.CodeOpeDe).IsUnicode(false);

                entity.Property(e => e.CodeUffRecap).IsUnicode(false);

                entity.Property(e => e.CodeUpdate).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.DaTimbro).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FlagArData).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito).IsUnicode(false);

                entity.Property(e => e.IndicativoFestivo).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.Localita).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.Ts).IsRowVersion();

                entity.Property(e => e.ViaDest).IsUnicode(false);
            });

            modelBuilder.Entity<EsaRaccCmp>(entity =>
            {
                entity.HasKey(e => e.CodeRacc)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);
            });

            modelBuilder.Entity<EsaRaccStore>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.CodeOpeDe).IsUnicode(false);

                entity.Property(e => e.CodeUffRecap).IsUnicode(false);

                entity.Property(e => e.CodeUpdate).IsUnicode(false);

                entity.Property(e => e.CodiceEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('99')");

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.DaTimbro).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FlagArData).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Z')");

                entity.Property(e => e.IndicativoFestivo).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.Localita).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.Ts).IsRowVersion();

                entity.Property(e => e.ViaDest).IsUnicode(false);
            });

            modelBuilder.Entity<EsaRaccStorico>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.CodiceEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('99')");

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.DaTimbro).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FlagArData).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Z')");

                entity.Property(e => e.IndicativoFestivo).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.ViaDest).IsUnicode(false);
            });

            modelBuilder.Entity<EsaRaccTipoConsegna>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DscrTipoConsegna).IsUnicode(false);

                entity.Property(e => e.FlgInserimento).IsUnicode(false);

                entity.Property(e => e.TipoConsegna).IsUnicode(false);
            });

            modelBuilder.Entity<EsitiDaFiliali>(entity =>
            {
                entity.HasKey(e => e.CodeRacc)
                    .HasName("PK_ESITI_DA_FILIALI_F2");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);
            });

            modelBuilder.Entity<EsitiDaFilialiSenzadata>(entity =>
            {
                entity.HasKey(e => e.CodeRacc)
                    .HasName("PK_ESITI_DA_FILILALI_SENZADATA");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.FileName).IsUnicode(false);
            });

            modelBuilder.Entity<FileLivorno>(entity =>
            {
                entity.Property(e => e.ProgressivoUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.ViaDest).IsUnicode(false);
            });

            modelBuilder.Entity<Filiali>(entity =>
            {
                entity.Property(e => e.Cap)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Capoluogo).IsUnicode(false);

                entity.Property(e => e.Filiale).IsUnicode(false);

                entity.Property(e => e.Prov).IsUnicode(false);

                entity.Property(e => e.Regione).IsUnicode(false);
            });

            modelBuilder.Entity<GamAvvisiMoraIntesa>(entity =>
            {
                entity.Property(e => e.FlagEstratto).IsUnicode(false);
            });

            modelBuilder.Entity<GamCodiciTt>(entity =>
            {
                entity.Property(e => e.CodiceInvio)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Banca).IsUnicode(false);

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.Filename).IsUnicode(false);

                entity.Property(e => e.Flag).IsUnicode(false);

                entity.Property(e => e.Ufficio1).IsUnicode(false);

                entity.Property(e => e.Ufficio2).IsUnicode(false);

                entity.Property(e => e.UfficioAccettazione).IsUnicode(false);
            });

            modelBuilder.Entity<GsAccettazioneArIncomplete>(entity =>
            {
                entity.Property(e => e.CodiceDispArrivo)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeOperatore).IsUnicode(false);

                entity.HasOne(d => d.NumScatolaNavigation)
                    .WithMany(p => p.GsAccettazioneArIncomplete)
                    .HasForeignKey(d => d.NumScatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_gs_ACCETTAZIONE_AR_INCOMPLETE_gs_RIEPILOGO_SCATOLE");
            });

            modelBuilder.Entity<GsDatiImgAr>(entity =>
            {
                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.FlagMatchEsaRacc).IsUnicode(false);

                entity.Property(e => e.FlagMatchTracc).IsUnicode(false);

                entity.Property(e => e.FlagRecDataNot).IsUnicode(false);

                entity.Property(e => e.FlagScarto).IsUnicode(false);

                entity.Property(e => e.FlagSostitutivo).IsUnicode(false);

                entity.Property(e => e.FlagStato).IsUnicode(false);

                entity.Property(e => e.NomeCdArchivio).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.TipoAnomalia).IsUnicode(false);
            });

            modelBuilder.Entity<GsRiepilogoScatole>(entity =>
            {
                entity.Property(e => e.Cmp).IsUnicode(false);

                entity.Property(e => e.CodeOpAnomalia).IsUnicode(false);

                entity.Property(e => e.CodeOpArchiviazione).IsUnicode(false);

                entity.Property(e => e.CodeOpRecDate).IsUnicode(false);

                entity.Property(e => e.CodeOpRestComplete).IsUnicode(false);

                entity.Property(e => e.CodeOpRipartizione).IsUnicode(false);

                entity.Property(e => e.CodeOpScansione).IsUnicode(false);

                entity.Property(e => e.CodeOperatoreAttuale).IsUnicode(false);

                entity.Property(e => e.FlagStatoScatola).IsUnicode(false);
            });

            modelBuilder.Entity<GsSostitutiviAr>(entity =>
            {
                entity.Property(e => e.CodeOperatore).IsUnicode(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.FileNameRendicontazione).IsUnicode(false);

                entity.Property(e => e.FlagTipoSostitutivo).IsUnicode(false);

                entity.Property(e => e.NomeCdArchivio).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.UffRecapito).IsUnicode(false);
            });

            modelBuilder.Entity<ImgAr>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<ImgRelata>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.CodeRaccNavigation)
                    .WithOne(p => p.ImgRelata)
                    .HasForeignKey<ImgRelata>(d => d.CodeRacc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IMG_RELATA_RACC_PLICHI_MESSO");
            });

            modelBuilder.Entity<IndicizzazioneEsaRacc>(entity =>
            {
                entity.Property(e => e.ProgressivoUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeRacc).IsUnicode(false);
            });

            modelBuilder.Entity<LayoutStampanteZebra>(entity =>
            {
                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<LocalTemp>(entity =>
            {
                entity.Property(e => e.Cap)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Localita).IsUnicode(false);

                entity.Property(e => e.Prov).IsUnicode(false);
            });

            modelBuilder.Entity<Lotto>(entity =>
            {
                entity.HasKey(e => new { e.Scatola, e.Lotto1 });

                entity.HasOne(d => d.ScatolaNavigation)
                    .WithMany(p => p.Lotto)
                    .HasForeignKey(d => d.Scatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LOTTO_SCATOLA");
            });

            modelBuilder.Entity<MessiAnagrafica>(entity =>
            {
                entity.Property(e => e.Nominativo).IsUnicode(false);

                entity.HasOne(d => d.IdCmpNavigation)
                    .WithMany(p => p.MessiAnagrafica)
                    .HasForeignKey(d => d.IdCmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MESSI_ANAGRAFICA_CONFIG_CMP");
            });

            modelBuilder.Entity<MessoCodiciLivorno>(entity =>
            {
                entity.Property(e => e.ProgressivoUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceFiscale).IsUnicode(false);

                entity.Property(e => e.FlagTipoPersona).IsUnicode(false);
            });

            modelBuilder.Entity<MultiCap>(entity =>
            {
                entity.Property(e => e.UfficioRecapito)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cap).IsUnicode(false);
            });

            modelBuilder.Entity<MultiUfficio>(entity =>
            {
                entity.Property(e => e.Cap)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Ufficio).IsUnicode(false);
            });

            modelBuilder.Entity<NewAmbitoProvinciale>(entity =>
            {
                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.Sigla).IsUnicode(false);

                entity.Property(e => e.SottoCodiceUtente).IsUnicode(false);
            });

            modelBuilder.Entity<NewAnagraficaFlussiPostel>(entity =>
            {
                entity.Property(e => e.FileAck).IsUnicode(false);

                entity.Property(e => e.FileEsito).IsUnicode(false);

                entity.Property(e => e.FileEsitoack).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.StatoFlusso).IsUnicode(false);

                entity.Property(e => e.TipoFile).IsUnicode(false);
            });

            modelBuilder.Entity<NewBufferDistintaFittizia>(entity =>
            {
                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Dispaccio).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.StatoLavorazione).IsUnicode(false);
            });

            modelBuilder.Entity<NewBufferFileCorrotti>(entity =>
            {
                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.StatoLavorazione).IsUnicode(false);
            });

            modelBuilder.Entity<NewBufferFileSelettivoCorrotti>(entity =>
            {
                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.StatoLavorazione).IsUnicode(false);
            });

            modelBuilder.Entity<NewCartolineDispaccioIn>(entity =>
            {
                entity.HasKey(e => new { e.IdDispaccioIn, e.CodeRacc });

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceTipoConsegna).IsUnicode(false);

                entity.Property(e => e.DataTracciatura).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<NewCodeRaccStoricoCartelle>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("new_code_racc_storico_cartelle_Code_Racc");

                entity.Property(e => e.CodeRacc).IsUnicode(false);
            });

            modelBuilder.Entity<NewCodiciAnomalia>(entity =>
            {
                entity.HasIndex(e => new { e.DescrizioneAnomalia, e.CodiceAnomalia })
                    .HasName("New_Codici_Anomalia_Codice_Anomalia")
                    .IsUnique();

                entity.Property(e => e.CodiceAnomalia).IsUnicode(false);

                entity.Property(e => e.DescrizioneAnomalia).IsUnicode(false);
            });

            modelBuilder.Entity<NewCodiciCmp>(entity =>
            {
                entity.Property(e => e.EmailCc).IsUnicode(false);

                entity.Property(e => e.EmailTo).IsUnicode(false);

                entity.Property(e => e.Frazionario).IsUnicode(false);

                entity.Property(e => e.NomeImpianto).IsUnicode(false);

                entity.Property(e => e.OggettoEmail).IsUnicode(false);

                entity.Property(e => e.Polo).IsUnicode(false);

                entity.Property(e => e.Provincia).IsUnicode(false);

                entity.Property(e => e.TestoEmail).IsUnicode(false);
            });

            modelBuilder.Entity<NewCodiciErroriDaTt>(entity =>
            {
                entity.Property(e => e.CodiceErrore)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<NewDenominazioneSociale>(entity =>
            {
                entity.Property(e => e.CodiceZeta).IsUnicode(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);
            });

            modelBuilder.Entity<NewDisguidi>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("New_Disguidi_Code_Racc");

                entity.Property(e => e.CodeOpeDe).IsUnicode(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.Elaborato).HasDefaultValueSql("((0))");

                entity.Property(e => e.FlagFonteEsito).IsUnicode(false);
            });

            modelBuilder.Entity<NewDispacciJobCancellati>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("New_Dispacci_Job_Cancellati_Code_Racc");

                entity.Property(e => e.IdTabellaDispacciIn).ValueGeneratedNever();

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Mittente).IsUnicode(false);

                entity.Property(e => e.UsrApertura).IsUnicode(false);

                entity.Property(e => e.UsrArrivo).IsUnicode(false);

                entity.Property(e => e.UsrChiusura).IsUnicode(false);
            });

            modelBuilder.Entity<NewDispaccioIn>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("IDX_New_Dispaccio_In__Code_Racc");

                entity.HasIndex(e => e.Id)
                    .HasName("IX_New_Dispaccio_In");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.DataArrivo).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<NewElencoFileInput>(entity =>
            {
                entity.Property(e => e.EsitoSpostamentoFile).IsUnicode(false);

                entity.Property(e => e.FlussiKo).IsUnicode(false);

                entity.Property(e => e.FlussiOk).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.StatoFile).IsUnicode(false);

                entity.Property(e => e.StatoFileDesc).IsUnicode(false);

                entity.Property(e => e.TipoFile).IsUnicode(false);

                entity.Property(e => e.Utente).IsUnicode(false);
            });

            modelBuilder.Entity<NewElencoFileOutput>(entity =>
            {
                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.TipoFile).IsUnicode(false);

                entity.Property(e => e.Utente).IsUnicode(false);
            });

            modelBuilder.Entity<NewElencoQuery>(entity =>
            {
                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.Link).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<NewEsitiDaTt>(entity =>
            {
                entity.HasIndex(e => new { e.CodeRacc, e.Canale })
                    .HasName("New_Esiti_Da_TT_Code_Racc_Canale")
                    .IsUnique();

                entity.Property(e => e.Canale).IsUnicode(false);

                entity.Property(e => e.Chiave)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(upper(ltrim(rtrim([CANALE])))+upper(ltrim(rtrim([codice_ESITO]))))");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.DataLoadDati).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);
            });

            modelBuilder.Entity<NewEsitiDaTtBkp>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Canale).IsUnicode(false);

                entity.Property(e => e.Chiave)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(upper(ltrim(rtrim([CANALE])))+upper(ltrim(rtrim([codice_ESITO]))))");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.DataLoadDati).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);
            });

            modelBuilder.Entity<NewEsitoCorretto>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("New_New_Esito_Corretto_Code_Racc");

                entity.Property(e => e.Chiave)
                    .IsUnicode(false)
                    .HasComputedColumnSql("([code_racc]+upper([codice_anomalia]))");

                entity.Property(e => e.CodeOpeDe).IsUnicode(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceAnomalia).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);
            });

            modelBuilder.Entity<NewFlussiInputRaw>(entity =>
            {
                entity.HasIndex(e => e.IdfileInput)
                    .HasName("IX_New_FlussiInputRAW_ID_FileInput");

                entity.HasIndex(e => new { e.Id, e.RigaTrasmessa, e.IdfileInput })
                    .HasName("ix_New_FlussiInputRAW_IDFileInput");

                entity.Property(e => e.RigaTrasmessa).IsUnicode(false);
            });

            modelBuilder.Entity<NewFlussiOutputRaw>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.IdfileInput, e.RigaTrasmessa, e.IdfileOutput })
                    .HasName("ix_New_FlussiOutputRAW_IDFileOutput");

                entity.Property(e => e.RigaTrasmessa).IsUnicode(false);
            });

            modelBuilder.Entity<NewImmagini>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("IX_New_Immagini");

                entity.HasIndex(e => e.FlussoInvio);

                entity.HasIndex(e => new { e.CodeRacc, e.IdNewScambioPostel })
                    .HasName("IX_New_Immagini__ID_New_Scambio_Postel_Code_Racc");

                entity.HasIndex(e => new { e.CodeRacc, e.Errore, e.Inviato, e.Scatola })
                    .HasName("IX_New_Immagini__Inviato_code_racc");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.Inviato).HasDefaultValueSql("((0))");

                entity.Property(e => e.Scatola).IsUnicode(false);
            });

            modelBuilder.Entity<NewImmaginiA99>(entity =>
            {
                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.Scatola).IsUnicode(false);
            });

            modelBuilder.Entity<NewImmaginiPmr>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("new_immagini_pmr_COde_Racc");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Errore).IsUnicode(false);
            });

            modelBuilder.Entity<NewLavorazioneVerificaDistintaElettronica>(entity =>
            {
                entity.HasIndex(e => e.IdentificativoFlussoInvio)
                    .HasName("IX_New_Lavorazione_Verifica_Distinta_Elettronica__IDentificativo_Flusso_Invio");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.EsitoInvio).IsUnicode(false);

                entity.Property(e => e.IdentificativoFlussoInvio).IsUnicode(false);

                entity.Property(e => e.ProgressivoRecord).IsUnicode(false);

                entity.Property(e => e.TipologiaContestazione).IsUnicode(false);
            });

            modelBuilder.Entity<NewParametri>(entity =>
            {
                entity.HasKey(e => new { e.Nome, e.Modulo });

                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Modulo).IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Valore).IsUnicode(false);
            });

            modelBuilder.Entity<NewRendicontazioneCoordinateArchiviazioneNsin>(entity =>
            {
                entity.HasKey(e => e.CodeRacc)
                    .HasName("PK_New_Coordinate_Archiviazione");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.EsitoRitorno).IsUnicode(false);

                entity.Property(e => e.NumeroScatola).IsUnicode(false);

                entity.Property(e => e.Progressivo).IsUnicode(false);

                entity.Property(e => e.TipoConsegna).IsUnicode(false);
            });

            modelBuilder.Entity<NewRendicontazioneEsitiNsin>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.FonteEsito).IsUnicode(false);

                entity.Property(e => e.Motivo).IsUnicode(false);
            });

            modelBuilder.Entity<NewRendicontazioneImmaginiNsin>(entity =>
            {
                entity.HasKey(e => e.CodeRacc)
                    .HasName("PK_immagini_nsin");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.MacroEsito).IsUnicode(false);
            });

            modelBuilder.Entity<NewScambioEsitiTt>(entity =>
            {
                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);
            });

            modelBuilder.Entity<NewScambioNapoliImmagini>(entity =>
            {
                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.NomeFileXml).IsUnicode(false);

                entity.Property(e => e.NomeFileZip).IsUnicode(false);
            });

            modelBuilder.Entity<NewScartiTt>(entity =>
            {
                entity.Property(e => e.CodiceRaccomandata).IsUnicode(false);

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.FonteEsito).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);
            });

            modelBuilder.Entity<NewServiceRestituzioneAr>(entity =>
            {
                entity.HasKey(e => e.IdAr)
                    .HasName("PK_NEW_SERVICE_RESTITUZIONE_AR_1");

                entity.HasIndex(e => e.CodeRacc)
                    .HasName("code_racc");

                entity.Property(e => e.CodeRacc).IsUnicode(false);
            });

            modelBuilder.Entity<NewServiceRestituzioneCd>(entity =>
            {
                entity.HasKey(e => e.IdCd)
                    .HasName("PK_NEW_SERVICE_RESTITUZIONE_CDSCATOLA");

                entity.Property(e => e.CodeConcessione).IsUnicode(false);

                entity.Property(e => e.NumeroCd).IsUnicode(false);
            });

            modelBuilder.Entity<NewServiceRestituzioneCdScatola>(entity =>
            {
                entity.HasKey(e => e.IdCdScatola)
                    .HasName("PK_NEW_SERVICE_RESTITUZIONE_AR");

                entity.Property(e => e.ProgressivoScatola).IsUnicode(false);
            });

            modelBuilder.Entity<NewServiceRestituzioneFile>(entity =>
            {
                entity.Property(e => e.AnnoRiferimento).IsUnicode(false);

                entity.Property(e => e.CodeConcessione).IsUnicode(false);

                entity.Property(e => e.LetteraVettura).IsUnicode(false);

                entity.Property(e => e.NomeFile).IsUnicode(false);

                entity.Property(e => e.NomeVettore).IsUnicode(false);
            });

            modelBuilder.Entity<NewStagingPostelFlussi>(entity =>
            {
                entity.Property(e => e.NomeFlusso).IsUnicode(false);

                entity.Property(e => e.TipoFlusso).IsUnicode(false);
            });

            modelBuilder.Entity<NewStagingPostelImmagini>(entity =>
            {
                entity.Property(e => e.Anomalia).IsUnicode(false);

                entity.Property(e => e.Codconc).IsUnicode(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.Errore).IsUnicode(false);

                entity.Property(e => e.Nomefile).IsUnicode(false);

                entity.Property(e => e.Numcart).IsUnicode(false);

                entity.Property(e => e.Numscatola).IsUnicode(false);

                entity.Property(e => e.Prodotto).IsUnicode(false);
            });

            modelBuilder.Entity<NewStoricoXmlTracciatura>(entity =>
            {
                entity.HasKey(e => e.CodiceDispaccio)
                    .HasName("PK_STORICO_XML_TRACCIATURA");

                entity.Property(e => e.CodiceDispaccio)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<NewTipoesitoDaTt>(entity =>
            {
                entity.HasKey(e => new { e.Canale, e.Esito });

                entity.Property(e => e.Canale).IsUnicode(false);

                entity.Property(e => e.Esito).IsUnicode(false);

                entity.Property(e => e.Chiave)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(upper(ltrim(rtrim([CANALE])))+upper(ltrim(rtrim([ESITO]))))");

                entity.Property(e => e.CodiceAzione).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.CodiceOperatore).IsUnicode(false);

                entity.Property(e => e.DataNotificaObbl).HasDefaultValueSql("((1))");

                entity.Property(e => e.DescTipoEsito).IsUnicode(false);

                entity.Property(e => e.DescrizioneAzione).IsUnicode(false);

                entity.Property(e => e.FonteEsitoEqt).IsUnicode(false);

                entity.Property(e => e.Parametro).IsUnicode(false);

                entity.Property(e => e.Priorita).IsUnicode(false);
            });

            modelBuilder.Entity<Param>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<PatentiLibretti>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Flag).IsUnicode(false);

                entity.Property(e => e.MotivoRestituzione).IsUnicode(false);
            });

            modelBuilder.Entity<ProgressiviUtenteRipetuti>(entity =>
            {
                entity.HasKey(e => e.ProgressivoUtente)
                    .HasName("PK_progressivi_utente_ripetuti");

                entity.Property(e => e.ProgressivoUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<QualitaArLamezia>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AnAssenzaDataGuller).IsUnicode(false);

                entity.Property(e => e.AnAssenzaDataManuale).IsUnicode(false);

                entity.Property(e => e.AnAssenzaFirmaPlettere).IsUnicode(false);

                entity.Property(e => e.AnAssenzaFirmaRic).IsUnicode(false);

                entity.Property(e => e.AnAssenzaQualitaFirmatario).IsUnicode(false);

                entity.Property(e => e.AnDataDiffTimbroMan).IsUnicode(false);

                entity.Property(e => e.CodeRaccServizio).IsUnicode(false);

                entity.Property(e => e.DataLoad).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FileNameXls).IsUnicode(false);

                entity.Property(e => e.FlagLavOld)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagMatchEsaRacc).IsUnicode(false);

                entity.Property(e => e.FlagProdReportQualita)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagProdReportTempiLav)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<QualitaArVerona>(entity =>
            {
                entity.Property(e => e.ProgrUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AnAssenzaDataGuller).IsUnicode(false);

                entity.Property(e => e.AnAssenzaDataManuale).IsUnicode(false);

                entity.Property(e => e.AnAssenzaFirmaPlettere).IsUnicode(false);

                entity.Property(e => e.AnAssenzaFirmaRic).IsUnicode(false);

                entity.Property(e => e.AnAssenzaQualitaFirmatario).IsUnicode(false);

                entity.Property(e => e.AnDataDiffTimbroMan).IsUnicode(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodeRaccServizio).IsUnicode(false);

                entity.Property(e => e.DataLoad).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FileNameXls).IsUnicode(false);

                entity.Property(e => e.FlagLavOld)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagMatchEsaRacc).IsUnicode(false);

                entity.Property(e => e.FlagProdReportQualita)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagProdReportTempiLav)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<Query>(entity =>
            {
                entity.HasKey(e => e.IdQuery)
                    .HasName("PK_gs_QUERY");

                entity.Property(e => e.CodeOp).IsUnicode(false);

                entity.Property(e => e.DescQuery).IsUnicode(false);

                entity.Property(e => e.Testo).IsUnicode(false);
            });

            modelBuilder.Entity<Querynew>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK_QUERY")
                    .ForSqlServerIsClustered(false);

                entity.Property(e => e.Descrizione).IsUnicode(false);

                entity.Property(e => e.SqlText).IsUnicode(false);

                entity.Property(e => e.Users)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('V')");
            });

            modelBuilder.Entity<RaccAr>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("IX_RACC_AR_1")
                    .IsUnique();

                entity.HasIndex(e => e.IdScatolaRitorno)
                    .HasName("IX_RACC_AR");

                entity.Property(e => e.CodeAr)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeOpAr).IsUnicode(false);

                entity.Property(e => e.CodeOpMast).IsUnicode(false);

                entity.Property(e => e.CodeOpScan).IsUnicode(false);

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.DataEsito).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataInvio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlagEsito)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('00')");

                entity.Property(e => e.FlagStatoLavAr).IsUnicode(false);

                entity.HasOne(d => d.CodeRaccNavigation)
                    .WithOne(p => p.RaccAr)
                    .HasForeignKey<RaccAr>(d => d.CodeRacc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RACC_AR_RACC_PLICHI_MESSO");

                entity.HasOne(d => d.FlagStatoLavArNavigation)
                    .WithMany(p => p.RaccAr)
                    .HasForeignKey(d => d.FlagStatoLavAr)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RACC_AR_CONFIG_FLAG_STATO_LAV_AR");

                entity.HasOne(d => d.IdScatolaRitornoNavigation)
                    .WithMany(p => p.RaccAr)
                    .HasForeignKey(d => d.IdScatolaRitorno)
                    .HasConstraintName("FK_RACC_AR_SCATOLA_AR");
            });

            modelBuilder.Entity<RaccEsitate>(entity =>
            {
                entity.Property(e => e.CodiceRacc).IsUnicode(false);

                entity.Property(e => e.Concessionaria).IsUnicode(false);

                entity.Property(e => e.DataTracc).IsUnicode(false);

                entity.Property(e => e.Dispaccio).IsUnicode(false);
            });

            modelBuilder.Entity<RaccPlichiMesso>(entity =>
            {
                entity.HasIndex(e => e.Scatola)
                    .HasName("IX_RACC_PLICHI_MESSO");

                entity.HasIndex(e => new { e.CodeRacc, e.DataInsEsito })
                    .HasName("IX_RACC_PLICHI_MESSO_1");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CapNew).IsUnicode(false);

                entity.Property(e => e.CfPiva).IsUnicode(false);

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.CodeOpAssMessi).IsUnicode(false);

                entity.Property(e => e.CodeOpComunicazione).IsUnicode(false);

                entity.Property(e => e.CodeOpeDe).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.DestinatarioNew).IsUnicode(false);

                entity.Property(e => e.DispaccioCmpCge).IsUnicode(false);

                entity.Property(e => e.DispaccioMesso).IsUnicode(false);

                entity.Property(e => e.FlagEsito).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito).IsUnicode(false);

                entity.Property(e => e.FlagSottoEsito).IsUnicode(false);

                entity.Property(e => e.FlagStatoComunicazione)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FlagStatoPlico)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('I')");

                entity.Property(e => e.FlagTipoPersona).IsUnicode(false);

                entity.Property(e => e.FlagTipoPlico).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.LocDestNew).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.ViaDest).IsUnicode(false);

                entity.Property(e => e.ViaDestNew).IsUnicode(false);

                entity.HasOne(d => d.FlagEsitoNavigation)
                    .WithMany(p => p.RaccPlichiMesso)
                    .HasForeignKey(d => d.FlagEsito)
                    .HasConstraintName("FK_RACC_PLICHI_MESSO_CONFIG_FLAG_ESITO");

                entity.HasOne(d => d.FlagSottoEsitoNavigation)
                    .WithMany(p => p.RaccPlichiMesso)
                    .HasForeignKey(d => d.FlagSottoEsito)
                    .HasConstraintName("FK_RACC_PLICHI_MESSO_CONFIG_FLAG_SOTTO_ESITO");

                entity.HasOne(d => d.FlagStatoPlicoNavigation)
                    .WithMany(p => p.RaccPlichiMesso)
                    .HasForeignKey(d => d.FlagStatoPlico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RACC_PLICHI_MESSO_CONFIG_FLAG_STATO_PLICO");

                entity.HasOne(d => d.ScatolaNavigation)
                    .WithMany(p => p.RaccPlichiMesso)
                    .HasForeignKey(d => d.Scatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RACC_PLICHI_MESSO_SCATOLA");

                entity.HasOne(d => d.Flag)
                    .WithMany(p => p.RaccPlichiMesso)
                    .HasForeignKey(d => new { d.FlagStatoComunicazione, d.FlagEsito })
                    .HasConstraintName("FK_RACC_PLICHI_MESSO_CONFIG_FLAG_STATO_COMUNICAZIONE");
            });

            modelBuilder.Entity<RaccTemp>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeCapDest).IsUnicode(false);

                entity.Property(e => e.CodeOpDe).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.CodiceMotivo).IsUnicode(false);

                entity.Property(e => e.Destinatario).IsUnicode(false);

                entity.Property(e => e.FlagFonteEsito).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);

                entity.Property(e => e.Localita).IsUnicode(false);

                entity.Property(e => e.ProgressivoUtente).IsUnicode(false);

                entity.Property(e => e.TabellaProvenienza).IsUnicode(false);

                entity.Property(e => e.ViaDest).IsUnicode(false);
            });

            modelBuilder.Entity<RendicontazioneMesso>(entity =>
            {
                entity.Property(e => e.CodeOpRend).IsUnicode(false);

                entity.Property(e => e.CodeUtente).IsUnicode(false);
            });

            modelBuilder.Entity<RiepilogoStorico>(entity =>
            {
                entity.Property(e => e.IdFileName).ValueGeneratedNever();

                entity.Property(e => e.Archivio).IsUnicode(false);

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.FlagStoreDisPostel)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FlagTipoDoc).IsUnicode(false);
            });

            modelBuilder.Entity<Scatola>(entity =>
            {
                entity.HasIndex(e => e.CodiceScatola)
                    .HasName("IX_SCATOLA_2")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdCmp, e.Scatola1 })
                    .HasName("IX_SCATOLA")
                    .IsUnique();

                entity.HasIndex(e => new { e.Scatola1, e.FlagTipoScatola })
                    .HasName("IX_SCATOLA_1")
                    .IsUnique();

                entity.Property(e => e.Scatola1).ValueGeneratedNever();

                entity.Property(e => e.CodeOpAccPaccoMessi).IsUnicode(false);

                entity.Property(e => e.CodeOpeCh).IsUnicode(false);

                entity.Property(e => e.CodeOpeDisp).IsUnicode(false);

                entity.Property(e => e.CodiceScatola).IsUnicode(false);

                entity.Property(e => e.DataDisp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DimMax).HasDefaultValueSql("((100))");

                entity.Property(e => e.FlagStatoScatola)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('W')");

                entity.Property(e => e.FlagTipoScatola).IsUnicode(false);

                entity.HasOne(d => d.FlagStatoScatolaNavigation)
                    .WithMany(p => p.Scatola)
                    .HasForeignKey(d => d.FlagStatoScatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCATOLA_CONFIG_FLAG_STATO_SCATOLA");

                entity.HasOne(d => d.FlagTipoScatolaNavigation)
                    .WithMany(p => p.Scatola)
                    .HasForeignKey(d => d.FlagTipoScatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCATOLA_CONFIG_FLAG_TIPO_SCATOLA");

                entity.HasOne(d => d.IdCmpNavigation)
                    .WithMany(p => p.Scatola)
                    .HasForeignKey(d => d.IdCmp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCATOLA_CONFIG_CMP");
            });

            modelBuilder.Entity<ScatolaAr>(entity =>
            {
                entity.HasIndex(e => new { e.IdScatolaRitorno, e.DispaccioOut })
                    .HasName("IX_SCATOLA_AR_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.IdScatolaRitorno, e.NumScatolaRitorno, e.IdConcessione })
                    .HasName("IX_SCATOLA_AR")
                    .IsUnique();

                entity.Property(e => e.ComputerName).IsUnicode(false);

                entity.Property(e => e.DimMax).HasDefaultValueSql("((1000))");

                entity.Property(e => e.DispaccioOut).IsUnicode(false);

                entity.Property(e => e.FlagStatoScatolaRitorno)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('W')");

                entity.Property(e => e.FlagTipoScatolaRitorno).IsUnicode(false);

                entity.HasOne(d => d.FlagStatoScatolaRitornoNavigation)
                    .WithMany(p => p.ScatolaAr)
                    .HasForeignKey(d => d.FlagStatoScatolaRitorno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCATOLA_AR_COFIG_FLAG_STATO_SCATOLA_RITORNO");
            });

            modelBuilder.Entity<ScatolaRitorno>(entity =>
            {
                entity.HasIndex(e => new { e.IdScatolaRitorno, e.DispaccioOut })
                    .HasName("IX_SCATOLA_RITORNO_1")
                    .IsUnique();

                entity.HasIndex(e => new { e.NumScatolaRitorno, e.IdConcessione })
                    .HasName("IX_SCATOLA_RITORNO")
                    .IsUnique();

                entity.Property(e => e.ComputerName).IsUnicode(false);

                entity.Property(e => e.DimMax).HasDefaultValueSql("((1000))");

                entity.Property(e => e.DispaccioOut).IsUnicode(false);

                entity.Property(e => e.FlagStatoScatolaRitorno)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('W')");

                entity.Property(e => e.FlagTipoScatolaRitorno).IsUnicode(false);

                entity.HasOne(d => d.FlagStatoScatolaRitornoNavigation)
                    .WithMany(p => p.ScatolaRitorno)
                    .HasForeignKey(d => d.FlagStatoScatolaRitorno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCATOLA_RITORNO_COFIG_FLAG_STATO_SCATOLA_RITORNO");

                entity.HasOne(d => d.FlagTipoScatolaRitornoNavigation)
                    .WithMany(p => p.ScatolaRitorno)
                    .HasForeignKey(d => d.FlagTipoScatolaRitorno)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SCATOLA_RITORNO_CONFIG_FLAG_TIPO_SCATOLA_RITORNO");
            });

            modelBuilder.Entity<ServiceDispaccio>(entity =>
            {
                entity.HasIndex(e => e.CodiceDispaccio)
                    .HasName("IX_SERVICE_DISPACCIO__Codice_Dispaccio");

                entity.Property(e => e.CodiceDispaccio).IsUnicode(false);

                entity.Property(e => e.Service).IsUnicode(false);
            });

            modelBuilder.Entity<ServiceRestituzioneAr>(entity =>
            {
                entity.HasKey(e => e.IdAr)
                    .HasName("PK_SERVICE_RESTITUZIONE_AR_1");

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.HasOne(d => d.IdCdScatolaNavigation)
                    .WithMany(p => p.ServiceRestituzioneAr)
                    .HasForeignKey(d => d.IdCdScatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_RESTITUZIONE_AR_SERVICE_RESTITUZIONE_CD_SCATOLA");
            });

            modelBuilder.Entity<ServiceRestituzioneCd>(entity =>
            {
                entity.HasKey(e => e.IdCd)
                    .HasName("PK_SERVICE_RESTITUZIONE_CDSCATOLA");

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.ServiceRestituzioneCd)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_RESTITUZIONE_CD_SERVICE_RESTITUZIONE_FILE");
            });

            modelBuilder.Entity<ServiceRestituzioneCdScatola>(entity =>
            {
                entity.HasKey(e => e.IdCdScatola)
                    .HasName("PK_SERVICE_RESTITUZIONE_AR");

                entity.HasOne(d => d.IdCdNavigation)
                    .WithMany(p => p.ServiceRestituzioneCdScatola)
                    .HasForeignKey(d => d.IdCd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SERVICE_RESTITUZIONE_AR_SERVICE_RESTITUZIONE_CDSCATOLA");
            });

            modelBuilder.Entity<ServiceRestituzioneFile>(entity =>
            {
                entity.Property(e => e.CodeConcessione).IsUnicode(false);

                entity.Property(e => e.DataAcquisizione).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName).IsUnicode(false);

                entity.Property(e => e.LetteraVettura).IsUnicode(false);

                entity.Property(e => e.NomeVettore).IsUnicode(false);
            });

            modelBuilder.Entity<SostConfigRend>(entity =>
            {
                entity.Property(e => e.CodeUtente).IsUnicode(false);

                entity.Property(e => e.FlagTipoRend).IsUnicode(false);
            });

            modelBuilder.Entity<SostDati>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeOpInvio).IsUnicode(false);

                entity.Property(e => e.CodeOpScan).IsUnicode(false);

                entity.Property(e => e.CodiceEsito).IsUnicode(false);

                entity.Property(e => e.DataInvio).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FlagElab)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagIncompleto)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FlagSospeso)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.FlagStato)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('1')");

                entity.Property(e => e.NCopie).HasDefaultValueSql("((1))");

                entity.Property(e => e.TipoAnomalia).IsUnicode(false);

                entity.HasOne(d => d.FlagStatoNavigation)
                    .WithMany(p => p.SostDati)
                    .HasForeignKey(d => d.FlagStato)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOST_DATI_CONFIG_SOST_FLAG_STATO");

                entity.HasOne(d => d.IdScatolaNavigation)
                    .WithMany(p => p.SostDati)
                    .HasForeignKey(d => d.IdScatola)
                    .HasConstraintName("FK_SOST_DATI_SOST_SCATOLA");

                entity.HasOne(d => d.TipoAnomaliaNavigation)
                    .WithMany(p => p.SostDati)
                    .HasForeignKey(d => d.TipoAnomalia)
                    .HasConstraintName("FK_SOST_DATI_CONFIG_TIPO_ANOMALIA");
            });

            modelBuilder.Entity<SostImg>(entity =>
            {
                entity.HasIndex(e => e.IdScatola)
                    .HasName("IX_SOST_IMG");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdScatolaNavigation)
                    .WithMany(p => p.SostImg)
                    .HasForeignKey(d => d.IdScatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOST_IMG_SOST_SCATOLA");
            });

            modelBuilder.Entity<SostScatola>(entity =>
            {
                entity.HasIndex(e => new { e.NumScatola, e.IdConcessione })
                    .HasName("IX_SOST_SCATOLA")
                    .IsUnique();

                entity.Property(e => e.CodeOpLoad).IsUnicode(false);

                entity.Property(e => e.CodeOpMast).IsUnicode(false);

                entity.Property(e => e.DimMax).HasDefaultValueSql("((100))");

                entity.Property(e => e.DispaccioOut).IsUnicode(false);

                entity.Property(e => e.FlagStatoScatola).IsUnicode(false);

                entity.Property(e => e.FlagTipoScatola).IsUnicode(false);

                entity.Property(e => e.IdCd).IsUnicode(false);

                entity.HasOne(d => d.FlagStatoScatolaNavigation)
                    .WithMany(p => p.SostScatola)
                    .HasForeignKey(d => d.FlagStatoScatola)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SOST_SCATOLA_CONFIG_SOST_FLAG_STATO_SCATOLA");
            });

            modelBuilder.Entity<TFlussi>(entity =>
            {
                entity.HasKey(e => e.IdFlusso)
                    .HasName("PK_ETL.T_FLUSSI");

                entity.HasIndex(e => new { e.NomeFlusso, e.TipoFlusso })
                    .HasName("IX_T_FLUSSI_Nome_Flusso")
                    .IsUnique();

                entity.Property(e => e.EstensioneFlusso).IsUnicode(false);

                entity.Property(e => e.NomeFlusso).IsUnicode(false);

                entity.Property(e => e.NumeroElementi).HasComputedColumnSql("(isnull([etl].[getnumeroraccomandate]([Contenuto_Flusso]),(0)))");

                entity.Property(e => e.TipoFlusso).IsUnicode(false);

                entity.HasOne(d => d.IdFlussoParentNavigation)
                    .WithMany(p => p.InverseIdFlussoParentNavigation)
                    .HasForeignKey(d => d.IdFlussoParent)
                    .HasConstraintName("FK_ETL_T_FLUSSI_ETL_T_FLUSSI");
            });

            modelBuilder.Entity<TRaccInvioSelettivoPostel>(entity =>
            {
                entity.HasKey(e => e.IdRaccInvi)
                    .HasName("PK_ETL.T_RACC_INVIO_SELETTIVO_Postel");

                entity.HasIndex(e => new { e.IdFlusso, e.CodeRacc })
                    .HasName("IX_T_RACC_INVIO_SELETTIVO_Postel_ID_FLUSSO_Code_Racc")
                    .IsUnique();

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.HasOne(d => d.IdFlussoNavigation)
                    .WithMany(p => p.TRaccInvioSelettivoPostelIdFlussoNavigation)
                    .HasForeignKey(d => d.IdFlusso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ETL_T_RACC_INVIO_SELETTIVO_Postel_ETL_T_FLUSSI");

                entity.HasOne(d => d.IdFlussoEsitiNavigation)
                    .WithMany(p => p.TRaccInvioSelettivoPostelIdFlussoEsitiNavigation)
                    .HasForeignKey(d => d.IdFlussoEsiti)
                    .HasConstraintName("FK_ETL_T_RACC_INVIO_SELETTIVO_Postel_ETL_T_FLUSSI_ID_Fllusso_ESITI");
            });

            modelBuilder.Entity<TblPreavvisoCorrispondenza>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cap).IsUnicode(false);

                entity.Property(e => e.Capoluogo).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);
            });

            modelBuilder.Entity<TblPreavvisoRete>(entity =>
            {
                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Cap).IsUnicode(false);

                entity.Property(e => e.Filiale).IsUnicode(false);

                entity.Property(e => e.LocDest).IsUnicode(false);
            });

            modelBuilder.Entity<TentatoRecapito>(entity =>
            {
                entity.HasKey(e => e.Banca)
                    .HasName("PK_TENTATA_NOTIFICA");

                entity.Property(e => e.Banca)
                    .IsUnicode(false)
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<TracciatureArVerona>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("IDX_VERONA_RACC");

                entity.HasIndex(e => e.FileNameXls)
                    .HasName("IX_TRACCIATURE_AR_VERONA_FILEXLS");

                entity.HasIndex(e => new { e.CodeRacc, e.DataLavorazioneService })
                    .HasName("IDX_VERONA_PROG_DATA_SERVICE");

                entity.Property(e => e.ProgrUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodeRaccServizio).IsUnicode(false);

                entity.Property(e => e.DataLoadCge).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileNameAr).IsUnicode(false);

                entity.Property(e => e.FileNameXls).IsUnicode(false);

                entity.Property(e => e.FlagIncompleti)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagLavOld)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagMatchEsaRacc).IsUnicode(false);

                entity.Property(e => e.FlagProdReportArNoRacc)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<TracciatureIncompletiArLamezia>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("IDX_INC_LAMEZIA_RACC");

                entity.HasIndex(e => e.FileNameXls)
                    .HasName("IX_TRACCIATURE_INCOMPLETI_AR_LAMEZIA_FILEXLS");

                entity.Property(e => e.CodeRacc)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodiceDispaccio).IsUnicode(false);

                entity.Property(e => e.DataLoadCge).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileNameXls).IsUnicode(false);

                entity.Property(e => e.FlagIncompleti)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.FlagMatchEsaRacc).IsUnicode(false);

                entity.Property(e => e.FlagProdReport)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<TracciatureIncompletiArVerona>(entity =>
            {
                entity.HasIndex(e => e.CodeRacc)
                    .HasName("IDX_INC_VERONA_RACC");

                entity.HasIndex(e => e.FileNameXls)
                    .HasName("IX_TRACCIATURE_INCOMPLETI_AR_VERONA_FILEXLS");

                entity.Property(e => e.ProgrUtente)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.CodeRacc).IsUnicode(false);

                entity.Property(e => e.CodiceDispaccio).IsUnicode(false);

                entity.Property(e => e.FileNameXls).IsUnicode(false);

                entity.Property(e => e.FlagIncompleti).IsUnicode(false);

                entity.Property(e => e.FlagMatchEsaRacc).IsUnicode(false);

                entity.Property(e => e.FlagProdReport).IsUnicode(false);
            });

            modelBuilder.Entity<ViarioUr>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<XmlIndiceImgTemp>(entity =>
            {
                entity.Property(e => e.PercorsoCompleto).IsUnicode(false);

                entity.Property(e => e.TestoXml).IsUnicode(false);
            });

            modelBuilder.Entity<XmlTemp>(entity =>
            {
                entity.Property(e => e.PercorsoCompleto).IsUnicode(false);
            });

            modelBuilder.Entity<XmlTempCorrotti>(entity =>
            {
                entity.Property(e => e.PercorsoCompleto).IsUnicode(false);
            });

            modelBuilder.Entity<XmlTempFittizia>(entity =>
            {
                entity.Property(e => e.PercorsoCompleto).IsUnicode(false);
            });
        }

        //public async Task<List<SpGetProductByPriceGreaterThan1000>> GetProductByPriceGreaterThan1000Async()
        //{
        //    // Initialization.  
        //    List<SpGetProductByPriceGreaterThan1000> lst = new List<SpGetProductByPriceGreaterThan1000>();

        //    try
        //    {
        //        // Processing.  
        //        string sqlQuery = "EXEC [dbo].[GetProductByPriceGreaterThan1000] ";

        //        lst = await this.Query<SpGetProductByPriceGreaterThan1000>().FromSql(sqlQuery).ToListAsync();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    // Info.  
        //    return lst;
        //}

    }
}
