using RAR.ViewModel;
using System.Threading.Tasks;

namespace RAR.Client
{
    public partial class ApiClient : IApiClient
    {
        private const string ControllerStoricoCartelle = "StoricoCartelle/";

        public async Task<StoricoCartelleViewModel> RicercaPerDataPostalizzazioneRaccomadata(StoricoCartelleViewModel filtriRicerca)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerStoricoCartelle + "RicercaPerDataPostalizzazioneRaccomadata"));
            return await PostAsyncSimple<StoricoCartelleViewModel>(requestUrl, filtriRicerca);
        }

        public async Task<StoricoCartelleViewModel> RicercaPerCodiceRaccomandata(StoricoCartelleViewModel filtriRicerca)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerStoricoCartelle + "RicercaPerCodiceRaccomandata"));
            return await PostAsyncSimple<StoricoCartelleViewModel>(requestUrl, filtriRicerca);
        }

        //public async Task<StoricoCartelleViewModel> DettaglioRaccomandata(string codiceRaccomandata)
        //{
        //    var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
        //        ControllerStoricoCartelle + "DettaglioRaccomandata"));
        //    return await PostAsyncSimple<StoricoCartelleViewModel>(requestUrl, codiceRaccomandata);
        //}

        public async Task<StoricoCartelleViewModel> RaccomandateInDistinta(StoricoCartelleViewModel filtriRicerca)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerStoricoCartelle + "RaccomandateInDistinta"));
            return await PostAsyncSimple<StoricoCartelleViewModel>(requestUrl, filtriRicerca);
        }

        public async Task<StoricoCartelleViewModel> DettaglioDistinta(StoricoCartelleViewModel filtriRicerca)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerStoricoCartelle + "DettaglioDistinta"));
            return await PostAsyncSimple<StoricoCartelleViewModel>(requestUrl, filtriRicerca);
        }
    }
}
