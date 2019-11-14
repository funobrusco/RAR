using RAR.DAL.Model.Tabella;
using RAR.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Client
{
    public partial class ApiClient //: IApiClient
    {
        private const string ControllerCartolina = "Cartolina/";
        public async Task<ResultStoredViewModel<CartolinaViewModel>> CancellaCartolina(long codeRacc)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                string.Format(ControllerCartolina + "Cancella/{0}", codeRacc)));
            return await GetAsync<ResultStoredViewModel<CartolinaViewModel>>(requestUrl);
        }

        public async Task<IEnumerable<CartolinaViewModel>> GetCartoline(long idDispaccio)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerCartolina + "GetCartoline/" + idDispaccio));
            return await GetAsync<IEnumerable<CartolinaViewModel>>(requestUrl);
        }

        public async Task<ResultStoredViewModel<CartolinaViewModel>> NuovaCartolina(NewCartolineDispaccioIn nuovaCartolina)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerCartolina + "Nuova"));
            return await PostAsync<CartolinaViewModel, NewCartolineDispaccioIn>(requestUrl, nuovaCartolina);
        }
    }
}

