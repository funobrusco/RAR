using RAR.DAL.Model.Tabella;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Client
{
    public partial class ApiClient: IApiClient
    {
        private const string ControllerLookup = "Lookup/";

        public async Task<IEnumerable<ConfigTipoConsegna>> GetConfigTipoConsegna()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerLookup + "Elenca"));
            return await GetAsync<IEnumerable<ConfigTipoConsegna>>(requestUrl);
        }
    }
}

