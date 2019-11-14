using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RAR.DAL.Model.Tabella;
using RAR.WEB.MVC.Utility;

namespace RAR.WEB.MVC.Controllers
{
    public class CartolinaController : CommonController
    {

        public CartolinaController(IOptions<RARSettings> app, IConfiguration configuration, Microsoft.Extensions.Logging.ILogger<CartolinaController> logger, 
            IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
        }

        public async Task<IActionResult> Cancella(long? codeRacc, long? idDispaccio)
        {
            if (codeRacc == null || idDispaccio == null)
                return NotFound("Codice raccomandata o id dispaccio null");
            try
            {
                var result = await ApiClientFactory.Instance.CancellaCartolina(codeRacc.Value);
                if (result.Errore())
                    TempData["Errore"] = string.Format("Salvataggio cartolina non andata a buon fine: {0}", result.MessaggioErrore);
                else
                    TempData["Conferma"] = string.Format("Cancellazione cartolina con cod. raccomandata {0} eseguita correttamente", codeRacc.Value);

                return await RicaricaDettaglio(idDispaccio.Value);
            }
            catch (Exception e)
            {
                return Error(e.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuova([Bind("CodeRacc, DataNotifica, CodiceTipoConsegna, IdDispaccioIn")] NewCartolineDispaccioIn nuovaCartolina)
        {
            nuovaCartolina.UsrTracciatura = user;
            var result = await ApiClientFactory.Instance.NuovaCartolina(nuovaCartolina);

            if (result.Errore())
                TempData["Errore"] = string.Format("Salvataggio cartolina non andata a buon fine: {0}", result.MessaggioErrore);
            else
                TempData["Conferma"] = string.Format("Salvataggio cartolina {0} eseguita correttamente", result.Entita.Id);

            return await RicaricaDettaglio(nuovaCartolina.IdDispaccioIn);
        }


        //private async Task<IActionResult> RicaricaDettaglio(long idDispaccio)
        //{
        //    var dispaccioApertoViewModel = new DispaccioApertoViewModel();

        //    var dispaccio = await ApiClientFactory.Instance.Dettaglio(idDispaccio);

        //    dispaccioApertoViewModel.dispaccio = dispaccio;
        //    dispaccioApertoViewModel.cartolineDispaccio = await ApiClientFactory.Instance.GetCartoline(idDispaccio);
        //    dispaccioApertoViewModel.tipoConsegna = await ApiClientFactory.Instance.GetConfigTipoConsegna();

        //    ViewData["IdDispaccio"] = idDispaccio;

        //    return View("DettaglioAperto", dispaccioApertoViewModel);
        //}
    }
}
