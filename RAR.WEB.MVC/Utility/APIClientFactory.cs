using RAR.Client;
using System;
using System.Threading;

namespace RAR.WEB.MVC.Utility
{
    internal static class ApiClientFactory
    {
        private static Uri apiUri;
        private static string username;

        private static Lazy<ApiClient> restClient = new Lazy<ApiClient>(
          () => new ApiClient(apiUri, username),
          LazyThreadSafetyMode.ExecutionAndPublication);

        static ApiClientFactory()
        {
            apiUri = new Uri(ApplicationSettings.WebApiUrl);
            username = ApplicationSettings.Username;
        }

        public static ApiClient Instance
        {
            get
            {
                return restClient.Value;
            }
        }
    }
}
