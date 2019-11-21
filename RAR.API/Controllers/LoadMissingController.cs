using ExcelDataReader;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RAR.API.Utility;
using RAR.DAL.Model.Tabella;
using RAR.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace RAR.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoadMissingController : RARController
    {
        private readonly List<string> _outputNames;
        private readonly string _outputFolder;
        private readonly string _uploadFolder;
        private readonly string _fileExtensionAllowedToUpload;
        private readonly string _lostFolder;
        private readonly string _sharedOutputFolder;
        private readonly string _hostPath;
        private readonly int _timeout;
        LoadReport _dictFile;
        // Inject dependencies in controller
        public LoadMissingController(RARContext repositoryContext, IConfiguration configuration, ILogger<LoadMissingController> logger, IHostingEnvironment hostingEnvironment)
          : base(repositoryContext, configuration, logger, hostingEnvironment)
        {

            _outputNames = new List<string>();
            _outputFolder = _configuration["OutputFolder"];
            _uploadFolder = _configuration["UploadFolder"];
            _lostFolder = _configuration["Lost"];
            //_baseAddress = ApplicationSettings.WebApiUrl;
            _fileExtensionAllowedToUpload = _configuration["FileExtensionAllowedToUpload"].ToLower();
            _sharedOutputFolder = _configuration["SharedOutputFolder"];
            _hostPath = (_sharedOutputFolder.Split("\\"))[0];
            // try to retrive timeout for appsettings
            bool conversion = Int32.TryParse(_configuration["Timeout"], out _timeout);
            // if dont find any timeout definied set it to 15 seconds
            if (!conversion) _timeout = 15000;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Index()
        {
            return new[] { "In execution..." };
        }

        [HttpGet("AggiornaRacc")]
        public IActionResult AggiornaRacc()
        {
            var isError = false;
            var nomefileErr = String.Empty;
            try
            {
                _logger.LogInformation("Controller update data started!");
                long cons = 0;
                var today = DateTime.Now.ToString("yyyy-MM-dd");

                if (!Directory.Exists(_outputFolder))
                {
                    _logger.LogInformation("create directory " + _outputFolder);
                    Directory.CreateDirectory(_outputFolder);
                }

                var outputFileName = DateTime.Now.ToString("yyyy-MM-dd") + "-SCARTI_UPDATE_" + DateTime.Now.ToString("hh.mm.ss") + ".txt";
                var outcomesFilename = Path.Combine(_outputFolder, _lostFolder) + @"\" + outputFileName;

                //esegue stored prodecedure
                _logger.LogInformation("execute stored procedure: SP_aggiorna_esa_racc");
                var updatedRecords = new DAL.StoredProcedure.SP_aggiorna_esa_racc(RepositoryContext);
                long itemsUpdated = updatedRecords.Set(today);

                cons += itemsUpdated;

                //controlla se esistono esiti scartati per data non corretta
                _logger.LogInformation("execute stored procedure: SP_controlla_esiti_scartati");

                var esitiScartati = new RAR.DAL.StoredProcedure.SP_controlla_esiti_scartati(RepositoryContext);
                long scarti = esitiScartati.Get(today).Result.Count();
                ReportFile.InitFile(outcomesFilename);
                _logger.LogInformation("create end write file: " + outcomesFilename);
                if (scarti != 0)
                {
                    foreach (var rowScartati in esitiScartati.Get(today).Result)
                    {
                        ReportFile.WriteLine(rowScartati.CodiceInvio + " - " +
                                                    $"{rowScartati.DataDenuncia:yyyy-MM-dd}" + "  -  NOTIFICA ERRATA");
                    }
                }
                //scrive il riepilogo
                ReportFile.WriteLine("");
                ReportFile.WriteLine("");
                ReportFile.WriteLine(cons + " esiti aggiornati");
                ReportFile.WriteLine(scarti + " scartati");
                ReportFile.CloseFile();
                _logger.LogInformation("Esiti recuperati correttamente");
                //return Content(JsonConvert.SerializeObject(new { messaggio = "Esiti recuperati correttamente", avviso = "Creati files di riepilogo in " + _outputFolder }));

                CopyOutcomesFile2SharedFolder(outcomesFilename, outputFileName);
                if (Directory.Exists(@"\\" + _sharedOutputFolder))
                {
                    return Content(new String("Esiti recuperati correttamente.\n Creati files di riepilogo in : " + _sharedOutputFolder));
                }
                else return Content(new String("Esiti recuperati correttamente.\n Creati files di riepilogo."));

            }
            catch (Exception ex)
            {
                _logger.LogError("Problemi durante l'aggiornamento degli esiti");
                _logger.LogError(ex.Message);
                isError = true;
                nomefileErr = "log_error_" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("hh.mm.ss") + ".txt";
                ReportFile.InitFile(nomefileErr);
                ReportFile.WriteLine("Problemi durante l'aggiornamento degli esiti");
                ReportFile.WriteLine(ex.Message);
                ReportFile.WriteLine(ex.Source);
                ReportFile.CloseFile();

                return BadRequest("Problemi durante l'aggiornamento degli esiti. Impossibile proseguire.");
            }
            finally
            {
                if (isError)
                {
                    CopyLogErrorFile2SharedFolder(nomefileErr);
                }
            }
        }

        private void CopyOutcomesFile2SharedFolder(string outcomesFilename, string outputFileName)
        {
            //copy scarti_update file into _sharedOutputFolder

            var machinePingable = PingTest.PingHost(_hostPath, _logger, _timeout);
            if (machinePingable)
            {
                if (Directory.Exists(@"\\" + _sharedOutputFolder))
                {
                    if (Directory.Exists(Path.Combine(@"\\" + _sharedOutputFolder, _lostFolder)))
                    {
                        _logger.LogInformation($"copy {outputFileName} file into {_sharedOutputFolder}");
                        System.IO.File.Copy(outcomesFilename,
                            Path.Combine(@"\\" + _sharedOutputFolder, _lostFolder) + @"\" + outputFileName);
                    }
                }
                else
                {
                    _logger.LogError("Remote folder: " + @"\\" + _sharedOutputFolder + " not found");
                }
            }
            else
            {
                _logger.LogError($"copy {outputFileName} file into {_sharedOutputFolder} failed! Remote computer: {_hostPath} not found");
            }
        }

        private void CopyLogErrorFile2SharedFolder(string nomefileErr)
        {
            //copy log_error file into _sharedOutputFolder
            if (String.IsNullOrEmpty(nomefileErr)) return;
            //var machinePingable = PingTest.PingHost(_hostPath, _logger,_timeout);
            //if (machinePingable)
            //{
            if (Directory.Exists(@"\\" + _sharedOutputFolder))
            {
                if (Directory.Exists(Path.Combine(@"\\" + _sharedOutputFolder, _lostFolder)))
                {
                    _logger.LogInformation($"copy {nomefileErr} file into {_sharedOutputFolder}");
                    System.IO.File.Copy(nomefileErr, @"\\" + _sharedOutputFolder + @"\" + nomefileErr);
                }
            }
            else
            {
                _logger.LogError("Remote folder: " + @"\\" + _sharedOutputFolder + " not found");
            }
            //}
            //else
            //{
            //    _logger.LogError($"copy {nomefileErr} file into {_sharedOutputFolder} failed! Remote computer: {_hostPath} not found");
            //}
        }

        [HttpPost("UploadFiles")]
        public async Task<ActionResult<LoadReport>> UploadFilesAsync()
        {
            // hardcoded max lenght for file and path in windows because not easy to retrieve this limit from .net
            //const int maxPathLenght = 255;
            const int maxFileNameLenght = 45;
            _dictFile = new LoadReport();
            try
            {
                // Create upload folder if not there is
                var result = Directory.CreateDirectory(_uploadFolder);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception trying to create upload folder: " + ex.Message);
            }
            if (Request.HasFormContentType)
            {
                var form = Request.Form;
                if (form.Files != null && form.Files.Count > 0)
                {
                    foreach (var formFile in form.Files)
                    {
                        // Filter for extension
                        // upload only extension allowed
                        if (Path.GetExtension(formFile.FileName).ToLower() == _fileExtensionAllowedToUpload)
                        {
                            var uniquefilename = UniqueFilename.GenerateUniqueFilename(formFile);
                            //var savePath = _uploadFolder + "\\" + uniquefilename;
                            var currentPathLenght = _uploadFolder.Length + uniquefilename.Length;
                            // check if savepath have lenght greater than max allowed
                            if (currentPathLenght > maxFileNameLenght) // truncate exceeding part of path + filename to stay into maxFileNameLenght limit
                                uniquefilename = TruncateFilename.Truncate(uniquefilename, Math.Abs(maxFileNameLenght));
                            var savePath = _uploadFolder + "\\" + uniquefilename;
                            _dictFile.DictionaryOfFiles.Add(formFile.FileName, uniquefilename);


                            using (var fileStream = new FileStream(savePath, FileMode.Create))
                            {
                                formFile.CopyTo(fileStream);
                            }
                        }
                        else
                        {
                            _logger.LogInformation("Uploading for files with extension dont allowed, is skipped!");
                            //return BadRequest("Il file non è un file di Esxcel valido ! ");
                        }
                    }
                }
            }
            await CaricaSmarriti();
            return Ok(_dictFile);
        }

        public async Task<ActionResult<HttpResponseMessage>> CaricaSmarriti()
        {
            var connectionString = RepositoryContext.ConnectionString;
            var isError = false;
            var exMessage = String.Empty;


            var isXlsFiles = IsDocumentUploaded(_uploadFolder, out string[] xlsFiles);
            _logger.LogInformation("Controller started!");
            if (!isXlsFiles)
            {
                return BadRequest("Nessun file excel caricato!");
            }
            try
            {
                foreach (var excelfile in _dictFile.DictionaryOfFiles.Values)
                {
                    var filenamepath = _uploadFolder + @"\" + excelfile; // add upload folder to path of filename
                    await Task.Run(() => _outputNames.Add(OpenDocument(filenamepath, connectionString)));
                    _logger.LogInformation("open excel document");
                }

                _logger.LogInformation("Reading ended.");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception : " + ex.Message);
                isError = true;
                exMessage = ex.Message;
            }
            finally
            {
                if (isError)
                {
                    // build filename append guid to end of filename to have unique name
                    var fileName = "log_error_" + DateTime.Now.ToString("yyyy-MM-dd") + "_" + DateTime.Now.ToString("HH.mm.ss_") + Guid.NewGuid() + ".txt";
                    _outputNames.Add(fileName);
                    ReportFile.InitFile(fileName);
                    ReportFile.WriteLine("Problemi durante il caricamento dei codici");
                    ReportFile.WriteLine(exMessage);
                    ReportFile.CloseFile();

                    CopyLogErrorFile2SharedFolder(fileName);

                }
            }
            // return all filename generated included file of errors
            if (isError)
            {
                isError = false;
                return BadRequest("Problema durante la lettura del/i file di codici!");
            }
            // Serialize text file to json
            var result = ConvertToFileContentResult(_outputNames);
            return (result);
        }
        // Return all text log to file of text
        private HttpResponseMessage ConvertToFileContentResult(IEnumerable<string> outputFiles) //FileContentResult
        {
            //try
            //{
            var strResponse = new StringBuilder();
            strResponse.Append("\n");
            foreach (var outputFile in (outputFiles))
            {
                //Put name of the file at the start of the data
                strResponse.Append(outputFile);
                strResponse.Append("\n");
                strResponse.Append("\n");
                //strResponse.Append(Environment.NewLine);
                // put all text in the response
                var filetxt = System.IO.File.ReadAllText(Path.Combine(_outputFolder, _lostFolder) + @"\" + outputFile);
                strResponse.Append(filetxt);
                strResponse.Append("\n");
            }
            // save temp file for retrieve report
            var tmpFilename = "RisultatoCaricamentoSmarriti_" + Guid.NewGuid() + ".txt";
            string pathFile = SaveTempReport(strResponse, tmpFilename);
            // add baseurl of webapi to pathfile in dictionary to allow user to download file

            _dictFile.DictionaryOfFiles.Add("ReportFileLoadingGenerated", "LoadMissing/" + pathFile);
            _dictFile.LoadReportText = strResponse.ToString();
            var strResult = strResponse.ToString();
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(strResult), Encoding.UTF8, "text/html")
            };
        }
        private string SaveTempReport(StringBuilder strResponse, string tmpFilename)
        {
            var pathFile = String.Empty;
            try
            {
                // save temp file for retrieve report
                pathFile = _outputFolder + @"\" + tmpFilename;
                System.IO.File.WriteAllText(pathFile, strResponse.ToString());
                CopyInSharedFolder(pathFile, tmpFilename);
            }
            catch (Exception ex)
            {
                _logger.LogError("Problemi durante scrittura file temporaneo di report.");
                _logger.LogError(ex.Message);
            }
            return pathFile;
        }
        // Check if there is any documents loaded
        private static bool IsDocumentUploaded(string uploadFolder, out string[] xlsFiles)
        {
            xlsFiles = Directory.GetFiles(@uploadFolder, "*.*", SearchOption.TopDirectoryOnly).Where(s => s.EndsWith(".xls") || s.EndsWith(".xlsx")).ToArray();
            return xlsFiles.Length != 0;
        }

        // Read xls file
        private string OpenDocument(string fileName, string connectionString)
        {
            // hardcoded max lenght for file and path in windows because not easy to retrieve this limit from .net
            const int maxPathLenght = 255;
            // source filename
            // Open a document based on a filepath in read only mode
            var extension = Path.GetExtension(fileName).ToLower();

            var pathReportFile = new StringBuilder(_configuration["PathReportFile"]).Append(@"\").Append(_lostFolder).Append(@"\"); //.Append(Path.GetFileName(fileName)).Append("-SCARTI_LOAD.TXT");
            // Create folder 'smarriti' if not exist
            Directory.CreateDirectory(pathReportFile.ToString());
            // Append final 
            //var filenameWithOutcomesLoad= Path.GetFileName(fileName)).Append("-SCARTI_LOAD_").Append( Guid.NewGuid().ToString("N");

            pathReportFile.Append(Path.GetFileName(fileName)).Append("-SCARTI_LOAD_").Append((Guid.NewGuid().ToString("N"))).Append(".TXT");
            if (pathReportFile.Length > maxPathLenght) // truncate filename if own lenght is over the max path lenght of OS
                pathReportFile = new StringBuilder(pathReportFile.ToString().Substring(0, maxPathLenght)).Append(".txt");
            // Open for write file esitati
            ReportFile.InitFile(pathReportFile.ToString());  // fileEsistati =Helper.WriteReportFile(pathReportFile);
            string reportFileName = Path.GetFileName(pathReportFile.ToString());

            using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
            {

                IExcelDataReader reader = null;
                switch (extension) // *** optional manage more extension than xls
                {
                    case ".xls":
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                        break;
                    //case ".xlsx":
                    //    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    //    break;
                    //case ".csv":
                    //    reader = ExcelReaderFactory.CreateCsvReader(stream);
                    //    break;
                    default:
                        break;
                }

                if (reader == null) return (reportFileName);
                _logger.LogInformation("Try to parse document");
                ParseDocument(connectionString, reader, fileName, _logger);
                _logger.LogInformation("Copy document in sharedFolder");

            } // end using
            return (reportFileName);
        }

        //copy scarti_load file into _sharedOutputFolder
        private void CopyInSharedFolder(string pathFileName, string fileName)
        {
            //check if the machine contains the shared folder is reachable
            //var hostPath = _sharedOutputFolder.Split("\\");
            var machinePingable = PingTest.PingHost(_hostPath, _logger, _timeout);

            var pathReportFile = new StringBuilder(_configuration["PathReportFile"]).Append(@"\").Append(@"\");
            pathReportFile.Append(Path.GetFileName(fileName)).Append("-SCARTI_LOAD_").Append(Guid.NewGuid()).Append(".TXT");

            if (machinePingable)
            {
                if (Directory.Exists(@"\\" + _sharedOutputFolder))
                {
                    _logger.LogInformation("copy " + fileName + $" file into {_sharedOutputFolder}");
                    System.IO.File.Copy(pathFileName, Path.Combine(@"\\" + _sharedOutputFolder, _lostFolder) + @"\\" + fileName);
                }
                else
                {
                    _logger.LogError("Remote folder: " + @"\\" + _sharedOutputFolder + " not found");
                }
            }
            else
            {
                _logger.LogError("copy " + fileName + $" file into {_sharedOutputFolder} failed! Remote computer: " + _hostPath + " not found");
            }
        }

        private static void ParseDocument(string connectionString, IExcelDataReader reader, string filename, ILogger logger)
        {
            long outcomes = 0;
            long wasteOutcomeDate = 0;     //scartidataesito;
            long wasted = 0;              // scarti
            string outcomeDate = String.Empty;
            string outcome = String.Empty;
            long newCodeNotInLostCodes = 0;
            long outcomeNewClaimDate = 0; //esiti caricati con nuova data denuncia
            bool flag = false;
            long notInDb = 0;             // codice invio non presente in esa racc nome variabile : noDb

            // Extract source file name only without path
            filename = Path.GetFileName(filename);
            try
            {
                using (reader)
                {
                    // assign excel sheet to dataset
                    DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        UseColumnDataType = false,
                        ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = false
                        }
                    });

                    // parsing rows, getting first table for default
                    foreach (DataRow r in ds.Tables[0].Rows)
                    {
                        // Validate data , first column we search is defined in app settings
                        string sendCode = r.ItemArray[0].ToString().ToUpper();
                        if (!flag && sendCode != "CODICE INVIO")
                        {
                            //rowLine++;
                            continue;
                        }

                        if (sendCode == "CODICE INVIO")
                        {
                            // the next rows contains send code
                            flag = true;
                            continue;
                        }

                        if ((sendCode != String.Empty) && (sendCode.Length == 12) && sendCode.All(char.IsDigit)) // try to validate sendcode 
                        {

                            // if send code is not present in esa racc
                            if (IsSendCodeInEsaRacc(connectionString, sendCode, logger) == 0)    //if (selectSendCode.Count == 0)
                            {

                                notInDb++;
                                ReportFile.WriteLine(sendCode + " - NON PRESENTE A DB (in esa_racc)");

                                continue;
                            }
                            // controllo se esistono esiti scartati con un'esito in esa_racc
                            using (var connection = new SqlConnection(connectionString))
                            {
                                SqlCommand cmd = new SqlCommand("SP_LoadSmarriti_SeEsitiScartatiConEsitoInEsaRacc", connection);
                                cmd.Parameters.Add("@sendCode", SqlDbType.VarChar).Value = sendCode;
                                cmd.CommandType = CommandType.StoredProcedure;
                                connection.Open();

                                var dataReader = cmd.ExecuteReader();
                                var dtEsaRacc = new DataTable();
                                dtEsaRacc.Load(dataReader);
                                // if there is records
                                if (dtEsaRacc.Rows.Count > 0)
                                {
                                    // get first row
                                    var rowDtEsaRacc = dtEsaRacc.Rows[0];

                                    //var discarderdOutcomes = db.EsaRaccs.FromSql(sqlQuery).ToList();
                                    // add counter for outcomes or 'esitati'
                                    outcomes++;
                                    ReportFile.WriteLine(rowDtEsaRacc["code_racc"] + " - " + String.Format(rowDtEsaRacc["data_elab"].ToString(), "yyyy-MM-dd") +
                                        "  -  PRESENTE GIA IN ESA_RACC CON ESITO " + rowDtEsaRacc["codice_esito"] + " E FONTE " + rowDtEsaRacc["flag_fonte_esito"]);
                                    // goto cliente errato
                                    continue;
                                }
                                cmd.Dispose();
                            }
                            // Check outcome date 'data esito'
                            outcomeDate = r.ItemArray[1].ToString();                             // data esito
                            outcome = (r.ItemArray[2].ToString()).Replace("'", "''");            // esito
                            DateTime dtOutComeDate; // convert in datetime type outcomeDate string
                            if (String.IsNullOrEmpty(outcomeDate))
                            {
                                wasteOutcomeDate++;
                                ReportFile.WriteLine(sendCode + " - DATA ESITO NON VALIDA ");
                                continue;
                            }

                            var provider = new CultureInfo("it-IT");
                            dtOutComeDate = DateTime.Parse(outcomeDate, provider, DateTimeStyles.NoCurrentDateDefault);
                            outcomeDate = outcomeDate.Replace("/", "-");

                            var dtCodiciSmarriti = SeCodiceInvioInCodiciSmarriti(connectionString, sendCode, logger);
                            DataRow rowDtCodiciSmarriti = null;
                            if (dtCodiciSmarriti.Rows.Count > 0)
                            {
                                rowDtCodiciSmarriti = dtCodiciSmarriti.Rows[0];
                            }
                            if (dtCodiciSmarriti.Rows.Count == 0)
                            {
                                // new code not present in lost codes - nuovo codice non presente in codici_smarriti
                                newCodeNotInLostCodes++;
                                // Convert outcomeDate to datetime
                                CodiceInvioNonInCodiciSmarriti(connectionString, sendCode, dtOutComeDate, outcome, filename, logger);

                            }
                            else if (rowDtCodiciSmarriti != null && dtOutComeDate != DateTime.Parse(rowDtCodiciSmarriti["data_denuncia"].ToString()))
                            {
                                // codice già esistente ma con data denuncia da aggiornare viene inserito per mantenere i dati iniziali
                                outcomeNewClaimDate++;
                                CodiceInvioEsistAggiornaDataDenuncia(connectionString, sendCode, dtOutComeDate, outcome, filename, logger);
                            }
                            else
                            {
                                wasted++;
                                ReportFile.WriteLine(sendCode + " scartato perchè già presente in CODICI_SMARRITI con data denuncia uguale");
                            }
                        }
                        else
                        {
                            wasted++;
                            ReportFile.WriteLine(sendCode + " non conforme");
                        }
                    }
                    // Write summary - 'scrivo il riepilogo
                    WriteSummary(outcomes, wasteOutcomeDate, wasted, newCodeNotInLostCodes, outcomeNewClaimDate, notInDb);
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error parsing document: " + ex.Message);
            }
        }

        // Check if send code is present in table
        private static DataTable SeCodiceInvioInCodiciSmarriti(string connectionString, string sendCode, ILogger logger)
        {
            DataTable dtCodiciSmarriti;
            dtCodiciSmarriti = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //Popola codici_smarriti in corso..."
                    //var sqlSelect = "select codice_invio,data_denuncia,esito from codici_smarriti with(nolock) where codice_invio='" + sendCode + "'";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "SP_LoadSmarriti_SeCodiceInvioInCodiciSmarriti";
                    cmd.Parameters.Add("@sendCode", SqlDbType.VarChar).Value = sendCode;
                    conn.Open();
                    var dataReader = cmd.ExecuteReader();

                    dtCodiciSmarriti.Load(dataReader);

                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error checking if send code exist in lost codes : " + ex.Message);
            }
            return dtCodiciSmarriti;
        }
        // Check if send code is present in table
        private static void CodiceInvioNonInCodiciSmarriti(string connectionString, string sendCode, DateTime outcomeDate, string outcome, string filename, ILogger _logger)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {
                    //var sqlInsertQuery = " insert codici_smarriti (codice_invio,data_denuncia,data_load_dati,esito,filename) values("
                    //                       + "'" + sendCode + "'," + "'" + outcomeDate + "'," + " GETDATE() ,"
                    //                       + "'" + outcome + "','" + filename.Replace("'", "''") + "')";

                    command.CommandText = "SP_LoadSmarriti_CodiceInvioNonInCodiciSmarriti";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@sendCode", SqlDbType.VarChar).Value = sendCode;
                    command.Parameters.Add("@outcomeDate", SqlDbType.SmallDateTime).Value = outcomeDate;
                    command.Parameters.Add("@outcome", SqlDbType.VarChar).Value = outcome;
                    command.Parameters.Add("@filename", SqlDbType.VarChar).Value = filename;

                    connection.Open();
                    command.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Error checking if send code not exist in lost codes : " + ex.Message);
            }
        }
        // Check if send code is present in table
        private static void CodiceInvioEsistAggiornaDataDenuncia(string connectionString, string sendCode, DateTime outcomeDate, string outcome, string filename, ILogger logger)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = connection.CreateCommand())
                {

                    command.CommandText = "SP_LoadSmarriti_CodiceInvioEsistAggiornaDataDenuncia";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@sendCode", SqlDbType.VarChar).Value = sendCode;
                    command.Parameters.Add("@outcomeDate", SqlDbType.SmallDateTime).Value = outcomeDate;
                    command.Parameters.Add("@outcome", SqlDbType.VarChar).Value = outcome;
                    command.Parameters.Add("@filename", SqlDbType.VarChar).Value = filename;
                    connection.Open();
                    command.ExecuteNonQuery();
                    //ts.WriteLine str_code &"  inserito nuovamente perchè già presente in CODICI_SMARRITI con data denuncia diversa"
                    ReportFile.WriteLine(sendCode + "  inserito nuovamente perchè già presente in CODICI_SMARRITI con data denuncia diversa");
                }
            }
            catch (Exception ex)
            {
                logger.LogError("Error checking if send code exist then update outcome date : " + ex.Message);
            }
        }
        // Write summary at the end in the report file
        private static void WriteSummary(long outcomes, long wasteOutcomeDate, long wasted, long newCodeNotInLostCodes, long outcomeNewClaimDate, long notInDb)
        {
            ReportFile.WriteLine("");
            ReportFile.WriteLine("");
            ReportFile.WriteLine(notInDb + " esiti non presenti in esa_racc");
            ReportFile.WriteLine(outcomes + " esiti presenti in esa_racc");
            ReportFile.WriteLine(newCodeNotInLostCodes + " esiti caricati (primo inserimento)");
            ReportFile.WriteLine(outcomeNewClaimDate + " esiti caricati con nuova data denuncia");
            ReportFile.WriteLine(wasted + " scartati");
            ReportFile.WriteLine(wasteOutcomeDate + " scartati per data esito non valida");
            ReportFile.CloseFile();
        }
        // Check if send code is present in table
        private static int IsSendCodeInEsaRacc(string connectionString, string sendCode, ILogger logger)
        {
            DataTable dt = new DataTable();
            int retValue = 0;
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {
                    var cmd = new SqlCommand("SP_LoadSmarriti_SeCodiceInvioInEsaRacc", connection);
                    cmd.Parameters.Add("@sendCode", SqlDbType.VarChar).Value = sendCode;
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();

                    var dataReader = cmd.ExecuteReader();

                    dt.Load(dataReader);
                    // if there is records
                    cmd.Dispose();
                    retValue = dt.Rows.Count;
                }
            }
            catch (Exception ex)
            {

                logger.LogError("Error checking if send code in esaracc : " + ex.Message);
            }

            return retValue;
        }

    }

}


