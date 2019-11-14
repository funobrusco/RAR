using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using RAR.DAL.Model.Tabella;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RAR.API.Utility
{
    internal enum XlsTypes
    {
        DataPostalizzazioneRaccomandata,
        RaccomandateInDistinta,
        DettaglioRaccomandata
    }

    public class GeneraXls : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly RARContext _context;

        // Inject dependencies in controller
        public GeneraXls(ILogger logger, RARContext context)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> GeneraXlsDettaglioRaccomandataStored()
        {
            try
            {
                var sptempstoricocartelle = new DAL.StoredProcedure.SP_temp_storico_cartelle(_context);
                var sptempstoricocartelleRow = sptempstoricocartelle.Get().Result.FirstOrDefault();

                // crea file EXCEL

                if (sptempstoricocartelleRow != null)
                {
                    var stream = new MemoryStream();
                    var sFileName = @"DettaglioRaccomadata_" + sptempstoricocartelleRow.CodeRaccEsaracc + ".xlsx";
                    await Task.Run(() => { 
                    _logger.LogInformation("Create XLSX file: " + sFileName);
                    
                        using (var package = new ExcelPackage(stream))
                        using (var worksheet = package.Workbook.Worksheets.Add(sptempstoricocartelleRow.CodeRaccEsaracc))
                        {

                            // Call to set  column width to display data so that is read fine
                            SetColumnWidth(worksheet, XlsTypes.DettaglioRaccomandata);

                            // add the headers
                            worksheet.Cells[1, 1].Value = "Dettaglio Raccomandata:";
                            worksheet.Cells[1, 2].Value = sptempstoricocartelleRow.CodeRaccEsaracc;
                            worksheet.Cells[3, 1].Value = "Dettaglio primo esito (fonte Esa_Racc)";

                            worksheet.Cells[4, 1].Value = "Id distinta";
                            worksheet.Cells[4, 2].Value = "ID dispaccio plichi al cliente";
                            worksheet.Cells[4, 3].Value = "Numero Cartellazione";
                            worksheet.Cells[4, 4].Value = "Data acquisizione esito";
                            worksheet.Cells[4, 5].Value = "Data acquisizione distinta";
                            worksheet.Cells[4, 6].Value = "Provincia";
                            worksheet.Cells[4, 7].Value = "Data Notifica";
                            worksheet.Cells[4, 8].Value = "Destinatario";

                            using (var cells = worksheet.Cells[4, 1, 4, 8])
                                MarcaIntestazione(cells);

                            //Add values
                            int numRigaCella = 5;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.IdFileNameEsaracc;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.IdDispaccioOutEsaracc;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.ProgressivoUtenteEsaracc;
                            worksheet.Cells[numRigaCella, 4].Value =
                                $"{sptempstoricocartelleRow.DataElabEsaracc:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 5].Value =
                                $"{sptempstoricocartelleRow.DataLoadDatiEsaracc:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 6].Value = sptempstoricocartelleRow.LocalitaEsaracc;
                            worksheet.Cells[numRigaCella, 7].Value =
                                $"{sptempstoricocartelleRow.DataNotificaEsaracc:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 8].Value = sptempstoricocartelleRow.DestinatarioEsaracc;

                            // add the headers
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Codice Cap Destinatario";
                            worksheet.Cells[numRigaCella, 2].Value = "Localita' Destinatario";
                            worksheet.Cells[numRigaCella, 3].Value = "Via Destinatario";
                            worksheet.Cells[numRigaCella, 4].Value = "Codice Esito";
                            worksheet.Cells[numRigaCella, 5].Value = "Flag Fonte Esito";
                            worksheet.Cells[numRigaCella, 6].Value = "Motivo di Restituzione";
                            worksheet.Cells[numRigaCella, 7].Value = "File acquisizione Esito";
                            worksheet.Cells[numRigaCella, 8].Value = "Codice Operatore";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 8])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.CodeCapDestEsaracc;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.LocDestEsaracc;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.ViaDestEsaracc;
                            worksheet.Cells[numRigaCella, 4].Value = sptempstoricocartelleRow.CodiceEsitoEsaracc;
                            worksheet.Cells[numRigaCella, 5].Value = sptempstoricocartelleRow.FlagFonteEsitoEsaracc;
                            worksheet.Cells[numRigaCella, 6].Value = sptempstoricocartelleRow.CodiceMotivoEsaracc;
                            worksheet.Cells[numRigaCella, 7].Value = sptempstoricocartelleRow.FileNameArEsaracc;
                            worksheet.Cells[numRigaCella, 8].Value = sptempstoricocartelleRow.CodeOpeDeEsaracc;


                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Distinta POSTEL :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Codice Cliente";
                            worksheet.Cells[numRigaCella, 2].Value = "Numero pezzi in Distinta";
                            worksheet.Cells[numRigaCella, 3].Value = "Data Caricamento Distinta";
                            worksheet.Cells[numRigaCella, 4].Value = "Nome Distinta";
                            worksheet.Cells[numRigaCella, 5].Value = "Data Spedizione";
                            worksheet.Cells[numRigaCella, 6].Value = "Tipo di prodotto";
                            worksheet.Cells[numRigaCella, 7].Value = "Grammatura";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 7])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.CodiceZetaDistpostel;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.TotLettereDistpostel;
                            worksheet.Cells[numRigaCella, 3].Value = $"{sptempstoricocartelleRow.DataLoadDistPostelDistpostel:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 4].Value = sptempstoricocartelleRow.NumeroDistintaDistpostel;
                            worksheet.Cells[numRigaCella, 5].Value = $"{sptempstoricocartelleRow.DataSpedizioneDistpostel:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 6].Value = sptempstoricocartelleRow.FlagTipoDocDistpostel;
                            worksheet.Cells[numRigaCella, 7].Value = sptempstoricocartelleRow.GrammaturaDistpostel;

                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Esiti Successivi o non Corretti :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "ID dispaccio plichi al cliente";
                            worksheet.Cells[numRigaCella, 2].Value = "Codice Esito";
                            worksheet.Cells[numRigaCella, 3].Value = "Flag Fonte Esito";
                            worksheet.Cells[numRigaCella, 4].Value = "File acquisizione esito";
                            worksheet.Cells[numRigaCella, 5].Value = "Data acquisizione distinta";
                            worksheet.Cells[numRigaCella, 6].Value = "Data acquisizione esito";
                            worksheet.Cells[numRigaCella, 7].Value = "Data Notifica";
                            worksheet.Cells[numRigaCella, 8].Value = "Motivo di Restituzione";
                            worksheet.Cells[numRigaCella, 9].Value = "Codice Operatore";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 9])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.IdDispaccioOutNewpozzoes;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.CodiceEsitoNewpozzoes;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FlagFonteEsitoNewpozzoes;
                            worksheet.Cells[numRigaCella, 4].Value = sptempstoricocartelleRow.FileNameArNewpozzoes;
                            worksheet.Cells[numRigaCella, 5].Value = sptempstoricocartelleRow.DataLoadDatiNewpozzoes;
                            worksheet.Cells[numRigaCella, 6].Value = $"{sptempstoricocartelleRow.DataElabNewpozzoes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 7].Value = $"{sptempstoricocartelleRow.DataNotificaNewpozzoes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 8].Value = sptempstoricocartelleRow.CodiceMotivoNewpozzoes;
                            worksheet.Cells[numRigaCella, 9].Value = sptempstoricocartelleRow.CodeOpeDeNewpozzoes;

                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Esito da T&T :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Codice Esito";
                            worksheet.Cells[numRigaCella, 2].Value = "Canale";
                            worksheet.Cells[numRigaCella, 3].Value = "File acquisizione esito T&T";
                            worksheet.Cells[numRigaCella, 4].Value = "Data acquisizione esito da T&T";
                            worksheet.Cells[numRigaCella, 5].Value = "Data Traccia";
                            worksheet.Cells[numRigaCella, 6].Value = "Data Notifica";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 6])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.CodiceEsitoNewestt;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.CanaleNewestt;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameArNewestt;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataLoadDatiNewestt:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 5].Value = $"{sptempstoricocartelleRow.DataTracciaNewestt:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 6].Value = $"{sptempstoricocartelleRow.DataNotificaNewestt:dd/MM/yyyy}";

                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Esito corretto e non rendicontato al Cliente :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Id File Name";
                            worksheet.Cells[numRigaCella, 2].Value = "Id Dispaccio Out";
                            worksheet.Cells[numRigaCella, 3].Value = "Progressivo Utente";
                            worksheet.Cells[numRigaCella, 4].Value = "Data Elab";
                            worksheet.Cells[numRigaCella, 5].Value = "Data Load Dati";
                            worksheet.Cells[numRigaCella, 6].Value = "Data Notifica";
                            worksheet.Cells[numRigaCella, 7].Value = "Codice Esito";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 7])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.IdFileNameNewescorret;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.IdDispaccioOutNewescorret;
                            worksheet.Cells[numRigaCella, 3].Value =
                                sptempstoricocartelleRow.ProgressivoUtenteNewescorret;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataElabNewescorret:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 5].Value = $"{sptempstoricocartelleRow.DataLoadDatiNewescorret:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 6].Value = $"{sptempstoricocartelleRow.DataNotificaNewescorret:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 7].Value = sptempstoricocartelleRow.CodiceEsitoNewescorret;

                            // add the headers
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Flag Fonte Esito";
                            worksheet.Cells[numRigaCella, 2].Value = "Codice Motivo";
                            worksheet.Cells[numRigaCella, 3].Value = "Nome File AR";
                            worksheet.Cells[numRigaCella, 4].Value = "Codice Operatore";
                            worksheet.Cells[numRigaCella, 5].Value = "Rendicontato";
                            worksheet.Cells[numRigaCella, 6].Value = "";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 6])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.FlagFonteEsitoNewescorret;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.CodiceMotivoNewescorret;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameArNewescorret;
                            worksheet.Cells[numRigaCella, 4].Value = sptempstoricocartelleRow.CodeOpeDeNewescorret;
                            worksheet.Cells[numRigaCella, 5].Value = sptempstoricocartelleRow.TsNewescorret;
                            worksheet.Cells[numRigaCella, 6].Value = sptempstoricocartelleRow.CodiceAnomaliaNewescorret;

                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Disguidi da lavorazione CFSM :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Data acquisizione esito";
                            worksheet.Cells[numRigaCella, 2].Value = "Codice Esito";
                            worksheet.Cells[numRigaCella, 3].Value = "Flag Fonte Esito";
                            worksheet.Cells[numRigaCella, 4].Value = "Motivo di Restituzione";
                            worksheet.Cells[numRigaCella, 5].Value = "Codice Operatore";
                            worksheet.Cells[numRigaCella, 6].Value = "Data Notifica";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 6])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = $"{sptempstoricocartelleRow.DataElabNewdisguidi:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.CodiceEsitoNewdisguidi;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FlagFonteEsitoNewdisguidi;
                            worksheet.Cells[numRigaCella, 4].Value = sptempstoricocartelleRow.CodiceMotivoNewdisguidi;
                            worksheet.Cells[numRigaCella, 5].Value = sptempstoricocartelleRow.CodeOpeDeNewdisguidi;
                            worksheet.Cells[numRigaCella, 6].Value = $"{sptempstoricocartelleRow.DataNotificaNewdisguidi:dd/MM/yyyy}";

                            // add the headers
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Data Disguido";
                            worksheet.Cells[numRigaCella, 2].Value = "Data Elaborazione";
                            worksheet.Cells[numRigaCella, 3].Value = "Elaborato";
                            worksheet.Cells[numRigaCella, 4].Value = "ID dispaccio plichi al cliente";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 4])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = $"{sptempstoricocartelleRow.DataDisguidoNewdisguidi:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 2].Value = $"{sptempstoricocartelleRow.DataElabNewdisguidi:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.ElaboratoNewdisguidi;
                            worksheet.Cells[numRigaCella, 4].Value = sptempstoricocartelleRow.IdDispaccioOutNewdisguidi;

                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Esiti rendicontati al Cliente :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Codice Esito";
                            worksheet.Cells[numRigaCella, 2].Value = "Flag Fonte Esito";
                            worksheet.Cells[numRigaCella, 3].Value = "File acquisizione esito";
                            worksheet.Cells[numRigaCella, 4].Value = "Data Load Dati";
                            worksheet.Cells[numRigaCella, 5].Value = "Data rendicontazione finale";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 5])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.CodiceEsitoRendes;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.FlagFonteEsitoRendes;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameArRendes;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataLoadDatiRendes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 5].Value = $"{sptempstoricocartelleRow.DataElabRendes:dd/MM/yyyy}";

                            // add the headers
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Data Notifica";
                            worksheet.Cells[numRigaCella, 2].Value = "ID dispaccio plichi al cliente";
                            worksheet.Cells[numRigaCella, 3].Value = "File  inviato da Postel ad Eqs";
                            worksheet.Cells[numRigaCella, 4].Value = "Data Estrazione";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 4])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = $"{sptempstoricocartelleRow.DataNotificaRendes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.DispaccioOutRendes;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameEstrattoRendes;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataEstrazioneRendes:dd/MM/yyyy}";

                            // add the headers
                            numRigaCella += 2;
                            worksheet.Cells[numRigaCella, 1].Value = "Esiti da rendicontare al Cliente :";

                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Codice Esito";
                            worksheet.Cells[numRigaCella, 2].Value = "Flag Fonte Esito";
                            worksheet.Cells[numRigaCella, 3].Value = "Nome File AR";
                            worksheet.Cells[numRigaCella, 4].Value = "Data Load Dati";
                            worksheet.Cells[numRigaCella, 5].Value = "Data elaborazione";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 5])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = sptempstoricocartelleRow.CodiceEsitoNlrendes;
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.FlagFonteEsitoNlrendes;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameArNlrendes;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataLoadDatiNlrendes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 5].Value = $"{sptempstoricocartelleRow.DataElabNlrendes:dd/MM/yyyy}";

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = $"{sptempstoricocartelleRow.DataNotificaRendes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.DispaccioOutRendes;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameEstrattoRendes;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataEstrazioneRendes:dd/MM/yyyy}";

                            // add the headers
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = "Data Notifica";
                            worksheet.Cells[numRigaCella, 2].Value = "Id Dispaccio out";
                            worksheet.Cells[numRigaCella, 3].Value = "File  inviato da Postel ad Eqs";
                            worksheet.Cells[numRigaCella, 4].Value = "Data Estrazione";

                            using (var cells = worksheet.Cells[numRigaCella, 1, numRigaCella, 4])
                                MarcaIntestazione(cells);

                            //Add values
                            numRigaCella++;
                            worksheet.Cells[numRigaCella, 1].Value = $"{sptempstoricocartelleRow.DataNotificaNlrendes:dd/MM/yyyy}";
                            worksheet.Cells[numRigaCella, 2].Value = sptempstoricocartelleRow.DispaccioOutNlrendes;
                            worksheet.Cells[numRigaCella, 3].Value = sptempstoricocartelleRow.FileNameEstrattoNlrendes;
                            worksheet.Cells[numRigaCella, 4].Value = $"{sptempstoricocartelleRow.DataEstrazioneNlrendes:dd/MM/yyyy}";

                            package.Save(); //Save the workbook.
                        }
                    });
                    var fileName = AppendInfoToFile(sFileName, stream, out var fileType);
                    return File(stream, fileType, fileName);
                }

            }

            catch (Exception ex)
            {
                _logger.LogError("Error generating xls: "+ex.Message);
                return BadRequest(ex.Message);
            }
            return BadRequest("Errore durante la generazione del file excel");
        }

        private static void MarcaIntestazione(ExcelRange cells)
        {
            cells.Style.Font.Bold = true;
            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
        }

        public async Task<IActionResult> GeneraXlsRicercaPerDataPostalizzazioneRaccomandata(DateTime dalGiorno, DateTime alGiorno)
        {
            try
            {
                _logger.LogInformation("Stored procedure execution: new_dettaglio_distinte_storico_cartelle");
                var nddscQuery = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_cartelle(_context);
                var sFileName = @"PostalizzazioneRaccomadata_" + $"{dalGiorno:yyyyMMdd}" + "-" + $"{alGiorno:yyyyMMdd}" + ".xlsx";
                _logger.LogInformation("Create XLSX file: " + sFileName);

                var stream = new MemoryStream();

                await Task.Run(() =>
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        using (var worksheet = package.Workbook.Worksheets.Add(
                            $"{dalGiorno:yyyyMMdd}" + " - " +
                            $"{alGiorno:yyyyMMdd}"))
                        {

                            SetColumnWidth(worksheet, XlsTypes.DataPostalizzazioneRaccomandata);
                            //First add the headers
                            worksheet.Cells[1, 1].Value = "DISTINTA";
                            worksheet.Cells[1, 2].Value = "TOTALE LETTERE";
                            worksheet.Cells[1, 3].Value = "FILE RRDP30NO";
                            worksheet.Cells[1, 4].Value = "DATA POSTALIZZAZIONE";

                            using (var cells = worksheet.Cells[1, 1, 1, 4])
                            {
                                cells.Style.Font.Bold = true;
                                cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);

                            }

                            //Add values
                            int numRigaCella = 2;

                            foreach (var item in nddscQuery.Get(dalGiorno, alGiorno).Result)
                            {
                                worksheet.Cells[numRigaCella, 1].Value = item.NumeroDistinta;
                                worksheet.Cells[numRigaCella, 2].Value = item.TotLettere;
                                worksheet.Cells[numRigaCella, 3].Value = item.FileName;
                                worksheet.Cells[numRigaCella, 4].Value = $"{item.DataSpedizione:dd/MM/yyyy}"; 
                                numRigaCella++;
                            }

                            package.Save(); //Save the workbook.
                        }
                    }
                });
                var fileName = AppendInfoToFile(sFileName, stream, out var fileType);
                return File(stream, fileType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error generating xls: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }
        // Call to set column width to display data so that is read fine
        private static void SetColumnWidth(ExcelWorksheet worksheet, XlsTypes xlsType)
        {
            switch (xlsType)
            {
                case XlsTypes.DataPostalizzazioneRaccomandata:
                    worksheet.Column(1).Width = 24;
                    worksheet.Column(2).Width = 18;
                    worksheet.Column(3).Width = 42;
                    worksheet.Column(4).Width = 22;
                    break;
                case XlsTypes.RaccomandateInDistinta:
                    worksheet.Column(1).Width = 24;
                    worksheet.Column(2).Width = 42;
                    worksheet.Column(3).Width = 22;
                    break;
                case XlsTypes.DettaglioRaccomandata:
                    worksheet.Column(1).Width = 32;
                    worksheet.Column(2).Width = 32;
                    worksheet.Column(3).Width = 32;
                    worksheet.Column(4).Width = 32;
                    worksheet.Column(5).Width = 32;
                    worksheet.Column(6).Width = 32;
                    worksheet.Column(7).Width = 32;
                    worksheet.Column(8).Width = 32;
                    worksheet.Column(9).Width = 32;
                    break;
            }
        }

        public async Task<IActionResult> GeneraXlsRaccomandateInDistinta(string distinta)
        {
            try
            {
                _logger.LogInformation("Stored procedure execution: new_dettaglio_distinte_storico_cartelle_2");
                var nddsc2Query = new DAL.StoredProcedure.SP_new_dettaglio_distinte_storico_cartelle2(_context);
                // crea file EXCEL
                string sFileName = @"DettaglioDistinteStoricoCartelle_" + distinta + ".xlsx";
                //string URL = string.Format("{0}://{1}/{2}/{3}/{4}", Request.Scheme, Request.Host, ControllerContext.ActionDescriptor.ControllerName, ControllerContext.ActionDescriptor.ActionName, sFileName);

                _logger.LogInformation("Create XLSX file: " + sFileName);

                var stream = new MemoryStream();
                await Task.Run(() =>
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        // add a new worksheet to the empty workbook
                        var worksheet = package.Workbook.Worksheets.Add(distinta);

                        // Call to set column width to display data so that is read fine
                        SetColumnWidth(worksheet, XlsTypes.RaccomandateInDistinta);
                        //First add the headers
                        worksheet.Cells[1, 1].Value = "CODICE RACCOMANDATA";
                        worksheet.Cells[1, 2].Value = "FILE RRDP30NO";
                        worksheet.Cells[1, 3].Value = "DATA POSTALIZZAZIONE";

                        using (var cells = worksheet.Cells[1, 1, 1, 3])
                        {
                            cells.Style.Font.Bold = true;
                            cells.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cells.Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                        }
                        //Add values
                        var numRigaCella = 2;
                        foreach (var item in nddsc2Query.Get(distinta).Result)
                        {
                            worksheet.Cells[numRigaCella, 1].Value = item.CodeRacc;
                            worksheet.Cells[numRigaCella, 2].Value = item.FileName;
                            worksheet.Cells[numRigaCella, 3].Value = $"{item.DataSpedizione:dd/MM/yyyy}"; //DateTime.FromOADate(item.DataSpedizione);
                            numRigaCella++;
                        }
                        package.Save(); //Save the workbook.
                    }
                });
                var fileName = AppendInfoToFile(sFileName, stream, out var fileType);
                return File(stream, fileType, fileName);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error generating xls: " + ex.Message);
                return BadRequest(ex.Message);
            }
        }

        private static string AppendInfoToFile(string sFileName, MemoryStream stream, out string fileType)
        {
            var fileName = sFileName;
            fileType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            stream.Position = 0;
            return fileName;
        }
    }
}