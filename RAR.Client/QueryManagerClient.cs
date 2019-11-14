using RAR.DAL.Model.CustomModel;
using RAR.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RAR.Client
{
    public partial class ApiClient : IApiClient
    {
        private const string ControllerQueryManager = "QueryManager/";
        public async Task<IEnumerable<QueryViewModel>> GetQuery()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerQueryManager + "GetAsync/"));
            return await GetAsync<IEnumerable<QueryViewModel>>(requestUrl);
        }

        public async Task<NewDammiQuery> GetQuery(int idQuery)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerQueryManager + "DammiQuery/" + idQuery));
            return await GetAsync<NewDammiQuery>(requestUrl);
        }

        public async Task<ResultStoredViewModel<string[][]>> ExecuteQuery(QueryManagerViewModel qmvm)
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
               ControllerQueryManager + "ExecuteQuery"));
            return await PostAsync<string[][], QueryManagerViewModel>(requestUrl, qmvm);
        }
    }
}

