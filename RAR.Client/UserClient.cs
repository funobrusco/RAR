using RAR.DAL.Model;
using RAR.ViewModel;
using System.Net;
using System.Threading.Tasks;

namespace RAR.Client
{
    public partial class ApiClient : IApiClient
    {
        private const string ControllerUser = "Token/";
        public async Task<ResultStoredViewModel<User>> Login(string username)
        {
            username = WebUtility.UrlEncode(username);
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture,
                ControllerUser + "Authenticate"));
            return await PostAsync<User>(requestUrl, new User(username));
        }
    }
}

