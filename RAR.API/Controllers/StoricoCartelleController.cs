using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RAR.DAL.Model.CustomModel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using RAR.DAL.Model.Tabella;
using RAR.Service;
using System.Collections.Generic;
using RAR.API.Utility;
using RAR.ViewModel;

namespace RAR.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StoricoCartelleController : RARController
    {
        private readonly IStoricoCartelleService _storicoCartelleService;

        // Inject dependencies in controller
        public StoricoCartelleController(IStoricoCartelleService storicoCartelleService, RARContext repositoryContext, IConfiguration configuration, ILogger<StoricoCartelleController> logger, IHostingEnvironment hostingEnvironment)
            : base(repositoryContext, configuration, logger, hostingEnvironment)
        {
            _storicoCartelleService = storicoCartelleService;
        }

        [HttpPost("RicercaPerCodiceRaccomandata")]
        public async Task<IActionResult> RicercaPerCodiceRaccomandata(NewStoricoCartelle filtroRicerca)
        {
            // POST /StoricoCartelle/RicercaPerCodiceRaccomandata
            Task<IEnumerable<NewStoricoCartelle.Raccomandata>> result = null;
            try
            {
                string seperator = ",";
                //string data = string.Join(seperator, filtroRicerca.codiciRaccomandata);
                string data = filtroRicerca.CodiciRaccomandata.Replace("\r\n", seperator);

                // esegue la query con i parametri passati da URL
                _logger.LogInformation("Query insert execution");

                var connectionString = RepositoryContext.ConnectionString;
                string commandText;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    commandText = $"INSERT new_code_racc_storico_cartelle(code_racc) SELECT * FROM DA_STRINGA_A_TABELLA('" + data + "',','" + ")";
                    EseguiQuery(commandText, connection);
                }

                _logger.LogInformation("execute stored procedure: SP_new_dettaglio_elenco_racc_storico_cartelle");
                var spNewDettaglioElencoRaccStoricoCartelle = new DAL.StoredProcedure.SP_new_dettaglio_elenco_racc_storico_cartelle(RepositoryContext);
                result = spNewDettaglioElencoRaccStoricoCartelle.GetAll();
                filtroRicerca.Raccomandate = result.Result;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    _logger.LogInformation("Query: \"delete from new_code_racc_storico_cartelle\" execution");
                    commandText = $"delete from new_code_racc_storico_cartelle";
                    EseguiQuery(commandText, connection);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
            }

            return Ok(filtroRicerca);
        }

        [HttpGet("DettaglioRaccomandata/{codiceRaccomandata}")]
        public async Task<IActionResult> DettaglioRaccomandata(string codiceRaccomandata)
        {
            // GET /StoricoCartelle/DettaglioRaccomandata/649128546828

            try
            {
                if (codiceRaccomandata.Length != 12)
                {
                    return Content("Codice Raccomandata non corretto");
                }

                // N.B. questa stored va in errore perchè viene fatta una insert nella tabella "temp_storico_cartelle" nel campo "TOT_LETTERE_DISTPOSTEL" che non esiste
                // ed una update sul campo "DATA_OPERAZIONE_NEWESCORRET" che non esiste
                // i campi sono stati commentati per testare la action
                // DA CONTROLLARE PERCHè ALCUNE VOLTE FUNZIONA
                _logger.LogInformation("execute stored procedure: new_dettaglio_racc_storico_cartelle");
                var spReturnValue = new DAL.StoredProcedure.SP_new_dettaglio_racc_storico_cartelle(RepositoryContext);
                spReturnValue.Set(codiceRaccomandata);

                _logger.LogInformation("execute stored procedure: SP_temp_storico_cartelle");
                var sptempstoricocartelle = new DAL.StoredProcedure.SP_temp_storico_cartelle(RepositoryContext);
                var presente = sptempstoricocartelle.Get().Result;
                if (!presente.Any())
                {
                    return Ok(new DettaglioCodiceRaccViewModel()
                    {
                        raccomandata = codiceRaccomandata
                    });
                }
                var sptempstoricocartelleRow = presente.FirstOrDefault<NewTempStoricoCartelle>();

                _logger.LogInformation("execute stored procedure: SP_count_code_racc_from_new_immagini");
                var spCountCodeRaccFromNewImmagini = new DAL.StoredProcedure.SP_count_code_racc_from_new_immagini(RepositoryContext);

                var spCountCodeRaccFromNewImmaginiNumero = spCountCodeRaccFromNewImmagini.Get(codiceRaccomandata).Result
                    .FirstOrDefault<NewCountCodeRacc>().numero;

                _logger.LogInformation("execute stored procedure: SP_count_code_racc_from_new_immagini_pmr ");
                var spCountCodeRaccFromImmaginiPrm = new DAL.StoredProcedure.SP_count_code_racc_from_new_immagini_pmr(RepositoryContext);
                var spCountCodeRaccFromImmaginiPrmNumero = spCountCodeRaccFromImmaginiPrm.Get(codiceRaccomandata).Result
                    .FirstOrDefault<NewCountCodeRacc>().numero;

                // query presente nel progetto originale ma non utilizzata -------------------
                // logger.LogInformation("execute query on esa_racc");
                // using (var context = new RARContext())
                // {
                //    var esaRaccs = context.EsaRacc.FromSql("SELECT * FROM esa_racc WHERE code_racc = {0}", codiceRaccomandata).ToList();
                // }

                //return Content(JsonConvert.SerializeObject(new
                var dettaglioRaccomandata = new DettaglioRaccomandata()
                {
                    CodiceRaccomandata = sptempstoricocartelleRow.CodeRaccEsaracc,
                    NumeroRaccomandate = spCountCodeRaccFromNewImmaginiNumero,
                    NumeroRaccomandatePMR = spCountCodeRaccFromImmaginiPrmNumero,
                    Tempstoricocartelle = sptempstoricocartelleRow,
                    NumeroDistintaDistpostel = sptempstoricocartelleRow.NumeroDistintaDistpostel
                };

                var result = Traslate(dettaglioRaccomandata);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return Content(ex.Message);
            }
        }

        [HttpPost("DettaglioDistinta")]
        public async Task<IActionResult> DettaglioDistinta(NewStoricoCartelle filtroRicerca)
        {
            // GET /StoricoCartelle/DettaglioDistinta/DIP05420180726H00001
            Task<NewStoricoCartelle.Dettaglio_Distinta> result = null;
            try
            {
                _logger.LogInformation("execute stored procedure: new_dettaglio_distinte_storico_cartelle_3");
                var spReturnValue = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_cartelle_3(RepositoryContext);
                result = spReturnValue.Get(filtroRicerca.Distinta);
                filtroRicerca.dettaglioDistinta = result.Result;

                if (result is null)
                {
                    return Content("Distinta non presente");
                }

                return Ok(filtroRicerca);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return Content(ex.Message);
            }
        }

        [HttpGet("DettaglioRaccomandataStoredXLS/{codiceRaccomandata}")]
        public async Task<IActionResult> DettaglioRaccomandataStoredXLS(string codiceRaccomandata)
        {
            // GET /StoricoCartelle/DettaglioRaccomandataStoredXLS/649128546828

            try
            {
                _logger.LogInformation("Call GeneraXLS class");
                var dettaglioRaccomandataXls = new GeneraXls( _logger,  RepositoryContext);

              

                return await dettaglioRaccomandataXls.GeneraXlsDettaglioRaccomandataStored();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                //HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.BadRequest);
                //return result;
                return Content(ex.Message);
            }

        }

        //[HttpGet("RicercaPerDataPostalizzazioneRaccomadata/{dalGiorno}/{alGiorno}")]
        [HttpPost("RicercaPerDataPostalizzazioneRaccomadata")]
        public async Task<IActionResult> RicercaPerDataPostalizzazioneRaccomadata(NewStoricoCartelle filtroRicerca)
        {
            // GET /StoricoCartelle/RicercaPerDataPostalizzazioneRaccomadata/2019-05-01/2019-05-21
            Task<IEnumerable<NewStoricoCartelle.Elenco_Distinte>> result = null;
            try
            {
                _logger.LogInformation("Stored procedure execution: new_dettaglio_distinte_storico_cartelle");
                var nddscQuery = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_cartelle(RepositoryContext);

                result = nddscQuery.Get(Convert.ToDateTime(filtroRicerca.DalGiorno), Convert.ToDateTime(filtroRicerca.AlGiorno));
                filtroRicerca.ElencoDistinte = result.Result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                //return Content(ex.Message);
            }
            return Ok(filtroRicerca);
        }

        [HttpGet("RicercaPerDataPostalizzazioneRaccomadataXLS/{dalGiorno}/{alGiorno}")]
        public async Task<IActionResult> RicercaPerDataPostalizzazioneRaccomadataXLSAsync(DateTime dalGiorno, DateTime alGiorno)
        {
            // GET /StoricoCartelle/RicercaPerDataPostalizzazioneRaccomadataXLS/2019-02-01/2019-02-21

            try
            {
                _logger.LogInformation("Call GeneraXLS class: makes of XLSX files with the list of the \"distinte\" included in the selected date range");

                var RicercaPerDataPostalizzazioneRaccomandataXls = new GeneraXls( _logger,  RepositoryContext);

                //string fullNameExcel = DettaglioRaccomandataXLS.RicercaPerDataPostalizzazioneRaccomadata(dalGiorno, alGiorno);
                //var nomeFileXls = fullNameExcel.Split("\\");
                //HttpResponseMessage res = new HttpResponseMessage(HttpStatusCode.OK);
                //var stream = new FileStream(fullNameExcel, FileMode.Open, FileAccess.Read);
                //res.Content = new StreamContent(stream);
                //res.Content.Headers.ContentType =
                //    new MediaTypeHeaderValue("application/octet-stream");
                //return res;

                return await RicercaPerDataPostalizzazioneRaccomandataXls.GeneraXlsRicercaPerDataPostalizzazioneRaccomandata(dalGiorno, alGiorno);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return Content(ex.Message);
            }

        }

        [HttpPost("RaccomandateInDistinta")]
        public async Task<IActionResult> RaccomandateInDistinta(NewStoricoCartelle filtroRicerca)
        {
            // GET /StoricoCartelle/RaccomandateInDistinta/DIP05420180726H00001
            Task<IEnumerable<NewStoricoCartelle.Elenco_Raccomandate_In_Distinta>> result = null;
            try
            {
                _logger.LogInformation("Stored procedure execution: new_dettaglio_distinte_storico_cartelle_2");
                var nddsc2Query = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_cartelle2(RepositoryContext);
                result = nddsc2Query.Get(filtroRicerca.Distinta);
                filtroRicerca.RaccomandateInDistinta = result.Result;
                return Ok(filtroRicerca);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return Content(ex.Message);
            }
        }

        [HttpGet("RaccomandateInDistintaXLS/{codiceDistinta}")]
        public async Task<IActionResult> RaccomandateInDistintaXLS(string codiceDistinta)
        {
            // GET /StoricoCartelle/RaccomandateInDistintaXLS/DIP05420180726H00001

            try
            {
                _logger.LogInformation("Call GeneraXLS class");
                var RaccomandateInDistintaXLS = new GeneraXls( _logger,  RepositoryContext);

                return await RaccomandateInDistintaXLS.GeneraXlsRaccomandateInDistinta(codiceDistinta);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Content(ex.Message);
            }
        }

        [HttpGet("Immagini/{codiceRaccomandata}")]
        public async Task<IActionResult> Immagini(string codiceRaccomandata)
        {
            // GET /StoricoCartelle/Immagini/649128421166

            try
            {
                _logger.LogInformation("execute stored procedure: new_dettaglio_distinte_storico_dett_immagini_ar");
                var spNewDettaglioDistinteStoricoDettImmaginiAr = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_dett_immagini_ar(RepositoryContext);
                var spNewDettaglioDistinteStoricoDettImmaginiArRow = spNewDettaglioDistinteStoricoDettImmaginiAr.Get(codiceRaccomandata).Result.FirstOrDefault<NewDettaglioDistinteStoricoDettImmagini>();

                return Ok(spNewDettaglioDistinteStoricoDettImmaginiArRow);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Content(ex.Message);
            }
        }
        [HttpGet("ImmaginiPmr/{codiceRaccomandata}")]
        public async Task<IActionResult> ImmaginiPmr(string codiceRaccomandata)
        {
            // GET /StoricoCartelle/Immagini/649128421166

            try
            {
                _logger.LogInformation("execute stored procedure: new_dettaglio_distinte_storico_dett_immagini_pmr");
                var spNewDettaglioDistinteStoricoDettImmaginiPmr = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_dett_immagini_pmr(RepositoryContext);
                var spNewDettaglioDistinteStoricoDettImmaginiPmrRow = spNewDettaglioDistinteStoricoDettImmaginiPmr.Get(codiceRaccomandata).Result.FirstOrDefault<NewDettaglioDistinteStoricoDettImmagini>();
                return Ok(spNewDettaglioDistinteStoricoDettImmaginiPmrRow);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return Content(ex.Message);
            }
        }
        #region private method
        private DettaglioCodiceRaccViewModel Traslate(DettaglioRaccomandata dettaglioRaccomandata)
        {
            var result = new DettaglioCodiceRaccViewModel()
            {
                countRaccomandate = dettaglioRaccomandata.NumeroRaccomandate,
                countRaccomandatePmr = dettaglioRaccomandata.NumeroRaccomandatePMR,
                raccomandata = dettaglioRaccomandata.CodiceRaccomandata,
                numeroDistintaDistpostel = dettaglioRaccomandata.NumeroDistintaDistpostel,
                dettaglioPrimoEsitofonteEsaRacc = Traslate(dettaglioRaccomandata.Tempstoricocartelle)
            };

            return result;
        }

        private NewTempStoricoCartelleViewModel Traslate(NewTempStoricoCartelle tempstoricocartelle)
        {
            var result = new NewTempStoricoCartelleViewModel()
            {
                CanaleNewestt = tempstoricocartelle.CanaleNewestt,
                CodeCapDestEsaracc = tempstoricocartelle.CodeCapDestEsaracc,
                CodeOpeDeEsaracc = tempstoricocartelle.CodeOpeDeEsaracc,
                LocalitaEsaracc = tempstoricocartelle.LocalitaEsaracc,
                ViaDestEsaracc = tempstoricocartelle.ViaDestEsaracc,
                LocDestEsaracc = tempstoricocartelle.LocDestEsaracc,
                CodeOpeDeNewdisguidi = tempstoricocartelle.CodeOpeDeNewdisguidi,
                CodeOpeDeNewpozzoes = tempstoricocartelle.CodeOpeDeNewpozzoes,
                CodeRaccEsaracc = tempstoricocartelle.CodeRaccEsaracc,
                CodeRaccNlrendes = tempstoricocartelle.CodeRaccNlrendes,
                CodiceEsitoEsaracc = tempstoricocartelle.CodiceEsitoEsaracc,
                CodiceEsitoNewdisguidi = tempstoricocartelle.CodiceEsitoNewdisguidi,
                CodiceEsitoNewescorret = tempstoricocartelle.CodiceEsitoNewescorret,
                CodiceEsitoNewestt = tempstoricocartelle.CodiceEsitoNewestt,
                CodiceEsitoNewpozzoes = tempstoricocartelle.CodiceEsitoNewpozzoes,
                CodiceEsitoNlrendes = tempstoricocartelle.CodiceEsitoNlrendes,
                CodiceEsitoRendes = tempstoricocartelle.CodiceEsitoRendes,
                CodiceMotivoEsaracc = tempstoricocartelle.CodiceMotivoEsaracc,
                CodiceMotivoNewdisguidi = tempstoricocartelle.CodiceMotivoNewdisguidi,
                CodiceMotivoNewpozzoes = tempstoricocartelle.CodiceMotivoNewpozzoes,
                CodiceZetaDistpostel = tempstoricocartelle.CodiceZetaDistpostel,
                DataDisguidoNewdisguidi = tempstoricocartelle.DataDisguidoNewdisguidi,
                DataElabEsaracc = tempstoricocartelle.DataElabEsaracc,
                DataElabNewdisguidi = tempstoricocartelle.DataElabNewdisguidi,
                DataElabNewescorret = tempstoricocartelle.DataElabNewescorret,
                DataElabNewpozzoes = tempstoricocartelle.DataElabNewpozzoes,
                DataElabNlrendes = tempstoricocartelle.DataElabNlrendes,
                DataElaborazioneNewdisguidi = tempstoricocartelle.DataElaborazioneNewdisguidi,
                DataElabRendes = tempstoricocartelle.DataElabRendes,
                DataEstrazioneNlrendes = tempstoricocartelle.DataEstrazioneNlrendes,
                DataEstrazioneRendes = tempstoricocartelle.DataEstrazioneRendes,
                DataLoadDatiEsaracc = tempstoricocartelle.DataLoadDatiEsaracc,
                DataLoadDatiNewescorret = tempstoricocartelle.DataLoadDatiNewescorret,
                DataLoadDatiNewestt = tempstoricocartelle.DataLoadDatiNewestt,
                DataLoadDatiNewpozzoes = tempstoricocartelle.DataLoadDatiNewpozzoes,
                DataLoadDatiNlrendes = tempstoricocartelle.DataLoadDatiNlrendes,
                DataLoadDatiRendes = tempstoricocartelle.DataLoadDatiRendes,
                DataLoadDistPostelDistpostel = tempstoricocartelle.DataLoadDistPostelDistpostel,
                DataNotificaEsaracc = tempstoricocartelle.DataNotificaEsaracc,
                DataNotificaNewdisguidi = tempstoricocartelle.DataNotificaNewdisguidi,
                DataNotificaNewescorret = tempstoricocartelle.DataNotificaNewescorret,
                DataNotificaNewestt = tempstoricocartelle.DataNotificaNewestt,
                DataNotificaNewpozzoes = tempstoricocartelle.DataNotificaNewpozzoes,
                DataNotificaNlrendes = tempstoricocartelle.DataNotificaNlrendes,
                DataNotificaRendes = tempstoricocartelle.DataNotificaRendes,
                DataSpedizioneDistpostel = tempstoricocartelle.DataSpedizioneDistpostel,
                DataTracciaNewestt = tempstoricocartelle.DataTracciaNewestt,
                DestinatarioEsaracc = tempstoricocartelle.DestinatarioEsaracc,
                DispaccioOutNlrendes = tempstoricocartelle.DispaccioOutNlrendes,
                DispaccioOutRendes = tempstoricocartelle.DispaccioOutRendes,
                ElaboratoNewdisguidi = tempstoricocartelle.ElaboratoNewdisguidi,
                FileNameArEsaracc = tempstoricocartelle.FileNameArEsaracc,
                FileNameArNewestt = tempstoricocartelle.FileNameArNewestt,
                FileNameArNewpozzoes = tempstoricocartelle.FileNameArNewpozzoes,
                FileNameArNlrendes = tempstoricocartelle.FileNameArNlrendes,
                FileNameArRendes = tempstoricocartelle.FileNameArRendes,
                FileNameEstrattoNlrendes = tempstoricocartelle.FileNameEstrattoNlrendes,
                FileNameEstrattoRendes = tempstoricocartelle.FileNameEstrattoRendes,
                FlagFonteEsitoEsaracc = tempstoricocartelle.FlagFonteEsitoEsaracc,
                FlagFonteEsitoNewdisguidi = tempstoricocartelle.FlagFonteEsitoNewdisguidi,
                FlagFonteEsitoNewpozzoes = tempstoricocartelle.FlagFonteEsitoNewpozzoes,
                FlagFonteEsitoNlrendes = tempstoricocartelle.FlagFonteEsitoNlrendes,
                FlagFonteEsitoRendes = tempstoricocartelle.FlagFonteEsitoRendes,
                FlagTipoDocDistpostel = tempstoricocartelle.FlagTipoDocDistpostel,
                GrammaturaDistpostel = tempstoricocartelle.GrammaturaDistpostel,
                IdDispaccioOutEsaracc = tempstoricocartelle.IdDispaccioOutEsaracc,
                IdDispaccioOutNewdisguidi = tempstoricocartelle.IdDispaccioOutNewdisguidi,
                IdDispaccioOutNewescorret = tempstoricocartelle.IdDispaccioOutNewescorret,
                IdDispaccioOutNewpozzoes = tempstoricocartelle.IdDispaccioOutNewpozzoes,
                IdFileNameEsaracc = tempstoricocartelle.IdFileNameEsaracc,
                IdFileNameNewescorret = tempstoricocartelle.IdFileNameNewescorret,
                NumeroDistintaDistpostel = tempstoricocartelle.NumeroDistintaDistpostel,
                ProgressivoUtenteEsaracc = tempstoricocartelle.ProgressivoUtenteEsaracc,
                ProgressivoUtenteNewescorret = tempstoricocartelle.ProgressivoUtenteNewescorret,
                TotLettereDistpostel = tempstoricocartelle.TotLettereDistpostel
            };

            return result;
        }

        private static void EseguiQuery(string commandText, SqlConnection connection)
        {
            using (SqlCommand command = new SqlCommand(commandText, connection))
            {
                command.CommandType = CommandType.Text;
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }
        #endregion private method
    }
}