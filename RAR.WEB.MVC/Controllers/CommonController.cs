using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RAR.ViewModel;
using RAR.WEB.MVC.Models;
using RAR.WEB.MVC.Utility;

namespace RAR.WEB.MVC.Controllers
{
    public class CommonController : Controller
    {
        protected readonly IOptions<RARSettings> appSettings;
        protected string user;

        public readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly ILogger _logger;
        public readonly IHostingEnvironment _hostingEnvironment;

        public CommonController(IOptions<RARSettings> app, IConfiguration configuration, ILogger<CommonController> logger, 
            IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
        {
            logger.LogInformation("Controller CommonController started!");

            _httpContextAccessor = httpContextAccessor;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
            _logger = logger;

            appSettings = app;
            ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            ApplicationSettings.Username = _httpContextAccessor.HttpContext.User.Identity.Name;
            user = _httpContextAccessor.HttpContext.User.Identity.Name;

            ConfigureLog4Net();
        }

        private void ConfigureLog4Net()
        {
            var executingAssembly = Assembly.GetExecutingAssembly();
            log4net.Repository.ILoggerRepository rootRepository = log4net.LogManager.GetRepository(executingAssembly);
            foreach (var appender in rootRepository.GetAppenders())
            {
                if (appender.Name.Equals("RollingFile") && appender is log4net.Appender.FileAppender)
                {
                    var fileAppender = appender as log4net.Appender.FileAppender;
                    fileAppender.File = "Log\\rar_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                    fileAppender.ActivateOptions();
                }
            }
        }

        public IActionResult Error(string message)
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = message });
        }

        internal async Task<IActionResult> RicaricaDettaglio(long idDispaccio)
        {
            var dispaccioApertoViewModel = new DispaccioApertoViewModel();

            var dispaccio = await ApiClientFactory.Instance.Dettaglio(idDispaccio);

            dispaccioApertoViewModel.dispaccio = dispaccio;
            dispaccioApertoViewModel.cartolineDispaccio = await ApiClientFactory.Instance.GetCartoline(idDispaccio);
            dispaccioApertoViewModel.tipoConsegna = await ApiClientFactory.Instance.GetConfigTipoConsegna();

            ViewData["IdDispaccio"] = idDispaccio;

            if (!string.IsNullOrEmpty(dispaccio.DataChiusura))
                return View("DettaglioChiuso", dispaccioApertoViewModel);
            else
                return View("~/Views/Dispaccio/DettaglioAperto.cshtml", dispaccioApertoViewModel);
        }
    }
}
