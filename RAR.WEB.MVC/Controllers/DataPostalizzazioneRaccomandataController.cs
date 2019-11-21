using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RAR.WEB.MVC.Utility;

namespace RAR.WEB.MVC.Controllers
{
    public class DataPostalizzazioneRaccomandataController : CommonController
    {
        public DataPostalizzazioneRaccomandataController(IOptions<RARSettings> app, IConfiguration configuration,
            ILogger<CommonController> logger, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor) :
            base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
        }

        //public async Task<IActionResult> Index()
        //{
        //    var dp = new DataPostalizzazioneRaccs
        //    {
        //        SearchDate = new SearchInterval(),
        //        DataPostalizzazioneRacc = new List<ListPostalizzazione>()
        //    };
        //    var item = new ListPostalizzazione
        //    {
        //        Distinta = "DIP05420180726H00001",
        //        DataPostalizzazione = new DateTime(2015, 6, 1),
        //        FileRrdp30No = "FileRrdp30No",
        //        Totale = 24
        //    };
        //    dp.DataPostalizzazioneRacc.Add(item);
        //    dp.SearchDate.From = new DateTime(2015, 6, 1);
        //    dp.SearchDate.To = new DateTime(2019, 6, 1);

        //    return View("DataPostalizzazioneRaccomandata", dp);
        //}

        [HttpPost]
        // Export to excel file recall webapi
        public async Task<IActionResult> ExportToXls(DateTime dalGiorno, DateTime alGiorno)
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                    using (var client = new HttpClient(handler))
                    {
                        client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                        //var result = await client.GetAsync("StoricoCartelle/RicercaPerDataPostalizzazioneRaccomadataXLS/" + dalGiorno + "&"+ alGiorno);
                        //string.format("api/products/id={0}&type={1}", param.Id.Value, param.Id.Type)
                        //var requestUri = new Uri();

                        var url = "StoricoCartelle/RicercaPerDataPostalizzazioneRaccomadataXLS/" + dalGiorno.ToString("yyyy-MM-dd") + "/" + alGiorno.ToString("yyyy-MM-dd");
                        var result = await client.GetAsync(String.Format("StoricoCartelle/RicercaPerDataPostalizzazioneRaccomadataXLS/" + dalGiorno.ToString("yyyy-MM-dd") + "/" + alGiorno.ToString("yyyy-MM-dd")));

                        if (result.StatusCode != HttpStatusCode.OK)
                            return BadRequest("Errore durante la generazione del file excel.");

                        return File(result.Content.ReadAsStreamAsync().Result, result.Content.Headers.ContentType.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return Error(ex.ToString());
            }
        }

        [HttpPost]
        public IActionResult Search(string distinta)
        {
            return (RedirectToAction("Index", "DettaglioDistinte", new { distinta }));
        }
    }
}