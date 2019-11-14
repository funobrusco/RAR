using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RAR.ViewModel;
using RAR.WEB.MVC.Utility;

namespace RAR.WEB.MVC.Controllers
{
    public class StoricoCartelleController : CommonController
    {
        public StoricoCartelleController(IOptions<RARSettings> app, IConfiguration configuration, 
            ILogger<StoricoCartelleController> logger, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RicercaRaccomandate(StoricoCartelleViewModel filtroRicerca)
        {
            if (filtroRicerca == null || !ModelState.IsValid)
            {
                ViewBag.errore = "Errore durante la ricerca raccomandate: filtro ricerca non avvalorato correttamente";
                return View("Index", filtroRicerca);
            }

            //verifica quale tipo di ricerca è richiesta
            if (filtroRicerca.dalGiorno == null && filtroRicerca.alGiorno != null)
            {
                ViewBag.errore = "la data dalGiorno non è valorizzata";
                _logger.LogError("la data dalGiorno non è valorizzata");
                return View("Index", filtroRicerca);
            }
            else if(filtroRicerca.dalGiorno != null && filtroRicerca.alGiorno == null)
            {
                ViewBag.errore = "la data alGiorno non è valorizzata";
                _logger.LogError("la data alGiorno non è valorizzata");
                return View("Index", filtroRicerca);
            }
            else if (filtroRicerca.dalGiorno != null && filtroRicerca.alGiorno != null)
            {
                //ricerca per data postalizzazione
                var dataDal = Convert.ToDateTime(filtroRicerca.dalGiorno);
                var dataAl = Convert.ToDateTime(filtroRicerca.alGiorno);

                // controlla che la dalGiorno sia inferiore o al limite uguale ad alGiorno
                if (VerificaCoerenzaIntervallo(dataDal, dataAl))
                {
                    _logger.LogError("la data: dalGiorno è maggiore della data: alGiorno");
                    ViewBag.errore = "la data: dalGiorno è maggiore della data: alGiorno";
                    return View("Index", filtroRicerca);
                }

                StoricoCartelleViewModel result = await ApiClientFactory.Instance.RicercaPerDataPostalizzazioneRaccomadata(filtroRicerca);

                ViewBag.UrlXlsx = appSettings.Value.WebApiBaseUrl + "StoricoCartelle/RicercaPerDataPostalizzazioneRaccomadataXLS/" + dataDal.ToString("yyyy-MM-dd") + "/" + dataAl.ToString("yyyy-MM-dd");

                return View("RicercaPerDataPostalizzazioneRaccomandata", result);

            }else if (filtroRicerca.codiciRaccomandata != null && filtroRicerca.codiciRaccomandata.Any())
            {
                // dal frontend i codici raccomandata arrivano come stringa separati da "\r\n"
                List<string> codiciRaccomandata = filtroRicerca.codiciRaccomandata.Split("\r\n").ToList();

                if (codiciRaccomandata.Count > 1)
                {
                    StoricoCartelleViewModel result = await ApiClientFactory.Instance.RicercaPerCodiceRaccomandata(filtroRicerca);
                    return View("ElencoCodiciRaccomandata", result);

                }
                else
                {
                    return RedirectToAction("CercaRacc", "DettaglioDistinte", new { codeRacc = codiciRaccomandata.ToArray() });
                    //return View("~/Views/StoricoCartelle/DettaglioDistinte/DettaglioCodiceRacc.cshtml", result);
                    // al momento escluso dal progetto
                }
            }
            return await Index();
        }

        public async Task<IActionResult> RaccomandateInDistinta(StoricoCartelleViewModel filtroRicerca)
        {
            ViewBag.UrlXlsx = appSettings.Value.WebApiBaseUrl + "StoricoCartelle/RaccomandateInDistintaXLS/" + filtroRicerca.Distinta;

            StoricoCartelleViewModel result = await ApiClientFactory.Instance.RaccomandateInDistinta(filtroRicerca);
            return View("RaccomandateInDistinta", result);
        }

        public async Task<IActionResult> DettaglioDistinta(StoricoCartelleViewModel filtroRicerca)
        {
            if (filtroRicerca.Distinta.Length != 20)
            {
                ViewBag.errore = "Codice Distinta non corretto";
                return View("DettaglioDistinta", filtroRicerca);
            }
            StoricoCartelleViewModel result = await ApiClientFactory.Instance.DettaglioDistinta(filtroRicerca);
            return View("DettaglioDistinta", result);
        }

        //public async Task<IActionResult> DettaglioRaccomandata(string codiceRaccomandata)
        //{
        //    if (string.IsNullOrEmpty(codiceRaccomandata))
        //    {
        //        ViewBag.errore = "Errore durante la ricerca raccomandate: codice raccomandata non avvalorato correttamente";
        //        return View("DettaglioDistinte", codiceRaccomandata);
        //    }
        //    CercaRacc
        //    return View("DettaglioDistinte");
        //}

        #region utility methods
        public bool VerificaCoerenzaIntervallo(DateTime dataDal, DateTime dataAl)
        {
            int result = DateTime.Compare(dataDal, dataAl);
            // controlla che la dalGiorno sia inferiore o al limite uguale ad alGiorno
            if (result > 0)
            {
                _logger.LogError("la data: dalGiorno è maggiore della data: alGiorno");
                // return Content("Errore: la data: dalGiorno è maggiore della data: alGiorno");
            }

            return (result > 0);
        }
        #endregion
    }
}