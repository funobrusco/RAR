using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RAR.DAL.Model.Tabella;
using RAR.ViewModel;
using RAR.WEB.MVC.Utility;

namespace RAR.WEB.MVC.Controllers
{
    public class DispaccioController : CommonController
    {
        public DispaccioController(IOptions<RARSettings> app, IConfiguration configuration, 
            ILogger<DispaccioController> logger, IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
            //user = "rete.testposte\\deang241";
        }

        public async Task<IActionResult> Index()
        {
            var data = await ApiClientFactory.Instance.GetDispacciByUsrArrivo(user);

            return View("Index", data);
        }

        public async Task<IActionResult> GetDettaglio(long? idDispaccio)
        {
            var result = new DispaccioApertoViewModel();

            if (idDispaccio == null)
                return NotFound();

            var dispaccio = await ApiClientFactory.Instance.Dettaglio(idDispaccio.Value);

            if (dispaccio == null)
                return NotFound();

            result.dispaccio = dispaccio;
            result.cartolineDispaccio = await ApiClientFactory.Instance.GetCartoline(idDispaccio.Value);
            result.tipoConsegna = await ApiClientFactory.Instance.GetConfigTipoConsegna();

            ViewData["IdDispaccio"] = idDispaccio.Value;
            ViewData["CodDispaccio"] = dispaccio.CodDispaccio;

            if (!string.IsNullOrEmpty(dispaccio.DataChiusura))
                return View("DettaglioChiuso", result);
            else
                return View("DettaglioAperto", result);
        }

        public async Task<IActionResult> ApriDispaccio(long? idDispaccio)
        {
            if (idDispaccio == null)
                return NotFound();

            var result = await ApiClientFactory.Instance.ApriDispaccio(user, idDispaccio.Value);

            if (result.Errore())
                TempData["Errore"] = string.Format("Apertura dispaccio {0} non andato a buon fine: {1}", idDispaccio.Value, result.MessaggioErrore);
            else
                TempData["Conferma"] = string.Format("Apertura dispaccio {0} andata a buon fine", idDispaccio.Value);

            return await Index();
        }

        public async Task<IActionResult> ChiudiDispaccio(long? idDispaccio)
        {
            if (idDispaccio == null)
                return NotFound();

            var result = await ApiClientFactory.Instance.ChiudiDispaccio(user, idDispaccio.Value);

            if (result.Errore())
                TempData["Errore"] = string.Format("Chiusura dispaccio {0} non andato a buon fine: {1}", idDispaccio.Value, result.MessaggioErrore);
            else
                TempData["Conferma"] = string.Format("Chiusura dispaccio {0} andata a buon fine", idDispaccio.Value);

            return await Index();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Nuovo([Bind("CodeRacc,Mittente,DataArrivo")] NewDispaccioIn nuovoDispaccio)
        {
            nuovoDispaccio.UsrArrivo = user;

            var result = await ApiClientFactory.Instance.NuovoDispaccio(nuovoDispaccio);

            if (result.Errore())
                TempData["Errore"] = string.Format("Salvataggio dispaccio non andato a buon fine: {0}", result.MessaggioErrore);
            else
                TempData["Conferma"] = string.Format("Dispaccio con id {0}, cod. {1}, inserito con successo", result.Entita.Id, result.Entita.CodDispaccio);

            return await Index();
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
                TempData["Conferma"] = string.Format("Salvataggio cartolina {0}, con cod. raccomandata {1} eseguita correttamente", result.Entita.Id, result.Entita.CodeRacc);

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
