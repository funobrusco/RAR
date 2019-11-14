using RAR.DAL.Model.Tabella;
using RAR.ViewModel;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace RAR.Client
{
    public partial class ApiClient : IApiClient
    {
        private const string ControllerDispacci = "dispaccio/";
        public async Task<IEnumerable<DispaccioViewModel>> GetDispacciByUsrArrivo(string userArrivo)
        {
            userArrivo = WebUtility.UrlEncode(userArrivo);
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerDispacci + "GetByUsrArrivo/" + userArrivo));
            return await GetAsync<IEnumerable<DispaccioViewModel>>(requestUrl);
        }

        public async Task<ResultStoredViewModel<DateTime>> ApriDispaccio(string usrApertura, long idDispaccio)
        {
            usrApertura = WebUtility.UrlEncode(usrApertura);
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                string.Format(ControllerDispacci + "Apri/{0}/{1}", idDispaccio, usrApertura)));
            return await GetAsync< ResultStoredViewModel<DateTime>>(requestUrl);
        }

        public async Task<ResultStoredViewModel<DispaccioViewModel>> ChiudiDispaccio(string usrChiusura, long idDispaccio)
        {
            usrChiusura = WebUtility.UrlEncode(usrChiusura);
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                string.Format(ControllerDispacci + "Chiudi/{0}/{1}", idDispaccio, usrChiusura)));
            return await GetAsync<ResultStoredViewModel<DispaccioViewModel>>(requestUrl);
        }

        public async Task<DispaccioViewModel> Dettaglio(long idDispaccio)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerDispacci + "GetDettaglio/" + idDispaccio));
            return await GetAsync<DispaccioViewModel>(requestUrl);
        }

        public async Task<ResultStoredViewModel<DispaccioViewModel>> NuovoDispaccio(NewDispaccioIn nuovoDispaccio)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerDispacci + "Nuovo"));
            return await PostAsync<DispaccioViewModel, NewDispaccioIn>(requestUrl, nuovoDispaccio);
        }
    }
}

