using Microsoft.AspNetCore.Mvc;
using RAR.ViewModel;
using System.Threading.Tasks;

namespace RAR.WEB.MVC.Utility
{
    public class ControllerUtility: Controller
    {
        private async Task<IActionResult> RicaricaDettaglio(long idDispaccio)
        {
            var dispaccioApertoViewModel = new DispaccioApertoViewModel();

            var dispaccio = await ApiClientFactory.Instance.Dettaglio(idDispaccio);

            dispaccioApertoViewModel.dispaccio = dispaccio;
            dispaccioApertoViewModel.cartolineDispaccio = await ApiClientFactory.Instance.GetCartoline(idDispaccio);
            dispaccioApertoViewModel.tipoConsegna = await ApiClientFactory.Instance.GetConfigTipoConsegna();

            ViewData["IdDispaccio"] = idDispaccio;

            return View("DettaglioAperto", dispaccioApertoViewModel);
        }
    }
}
