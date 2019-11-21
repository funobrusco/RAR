using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RAR.ViewModel;
using RAR.WEB.MVC.Utility;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RAR.WEB.MVC.Controllers
{
    public class DettaglioDistinteController : CommonController
    {
        public DettaglioDistinteController(IOptions<RARSettings> app, IConfiguration configuration, ILogger<DispaccioController> logger,
            IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
        }

        public async Task<ActionResult<IEnumerable<string>>> Index(string distinta)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/DettaglioDistinteStoricoCartelle/" + distinta);
                    if (result.StatusCode != HttpStatusCode.OK) return View("ErroreDettaglioDistinte");
                    var response =
                        JsonConvert.DeserializeObject<List<Detail>>(await result.Content.ReadAsStringAsync());

                    var vm = new DettaglioDistinteViewModel
                    {
                        Details = response,
                        Distinta = distinta
                    };

                    return View("DettaglioDistinte", vm);
                }
            }
        }

        // Search
        [HttpPost]
        public async Task<ActionResult> CercaRacc1(string codeRacc)
        {
            //RicercaPerCodiceRaccomandata
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    var codeRaccList = new[] { codeRacc };

                    HttpContent content = new StringContent(JsonConvert.SerializeObject(codeRaccList), Encoding.UTF8, "application/json");
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/DettaglioRaccomandata" + "/" + codeRacc);
                    if (result.StatusCode != HttpStatusCode.OK) return View("ErroreDettaglioDistinte");
                    var response =
                        JsonConvert.DeserializeObject<DettaglioCodiceRaccViewModel>(await result.Content.ReadAsStringAsync());
                    var vm = response;

                    return View("DettaglioCodiceRacc", vm);
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> CercaRacc(string codeRacc)
        {
            return await CercaRacc1(codeRacc);
        }
        // Export to excel file recall webapi

        public async Task<IActionResult> ExportToXls(string CodeRacc)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/DettaglioRaccomandataStoredXLS/" + CodeRacc);
                    if (result.StatusCode != HttpStatusCode.OK)
                        return BadRequest("Errore durante la generazione del file excel.");
                    return File(result.Content.ReadAsStreamAsync().Result, result.Content.Headers.ContentType.ToString());
                }
            }
        }

        public async Task<IActionResult> RetrieveImages(string codeRacc)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/Immagini/" + codeRacc);
                    if (result.StatusCode != HttpStatusCode.OK)
                        return BadRequest("Errore durante il recupero delle immagini o immagini non presenti per questo codice.");
                    var response =
                        JsonConvert.DeserializeObject<ImmaginiDbViewModel>(await result.Content.ReadAsStringAsync());
                    var vm = response;
                    return View("ImmaginiDB", response);
                }
            }
        }

        public async Task<IActionResult> RetrieveImagesPmr(string codeRacc)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/ImmaginiPmr/" + codeRacc);
                    if (result.StatusCode != HttpStatusCode.OK)
                        return BadRequest("Errore durante il recupero delle immagini o immagini non presenti per questo codice.");
                    var response =
                        JsonConvert.DeserializeObject<ImmaginiDbViewModel>(await result.Content.ReadAsStringAsync());
                    var vm = response;
                    return View("ImmaginiDBpmr", response);
                }
            }
        }

        public async Task<FileContentResult> RetrieveImgFront(string codeRacc)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/Immagini/" + codeRacc);
                    var response =
                        JsonConvert.DeserializeObject<ImmaginiDbViewModel>(await result.Content.ReadAsStringAsync());
                    var vm = response;
                    var returnFile = new FileContentResult(vm.ImgFront, "Image / tiff")
                    {
                        FileDownloadName = "FronteImg_" + codeRacc + "_" + DateTime.Now.ToString("yyyyMMddHHmmsss") + ".tif"
                    };
                    return returnFile;
                }
            }
        }

        public async Task<FileContentResult> RetrieveImgRear(string codeRacc)
        {
            using (var handler = new HttpClientHandler())
            {
                handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; };
                using (var client = new HttpClient(handler))
                {
                    client.BaseAddress = new Uri(ApplicationSettings.WebApiUrl);
                    var result = await client.GetAsync("StoricoCartelle/Immagini/" + codeRacc);
                    var response =
                        JsonConvert.DeserializeObject<ImmaginiDbViewModel>(await result.Content.ReadAsStringAsync());
                    var vm = response;
                    var returnFile = new FileContentResult(vm.ImgRetro, "Image / tiff")
                    {
                        FileDownloadName = "RetroImg_" + codeRacc + "_" + DateTime.Now.ToString("yyyyMMddHHmmsss") + ".tif"
                    };
                    return returnFile;
                }
            }
        }
    }
}