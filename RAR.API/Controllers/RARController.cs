using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RAR.DAL.Model.Tabella;
using System;
using System.Reflection;

namespace RAR.API.Controllers
{
    public class RARController: ControllerBase
    {
        public IHttpContextAccessor _httpContextAccessor;
        public readonly IConfiguration _configuration;
        public readonly ILogger _logger;
        public readonly IHostingEnvironment _hostingEnvironment;
        public RARContext RepositoryContext { get; set; }

        public RARController(/*IHttpContextAccessor httpContextAccessor, */RARContext repositoryContext, IConfiguration configuration, ILogger<RARController> logger, IHostingEnvironment hostingEnvironment)
        {
            /*_httpContextAccessor = httpContextAccessor;*/

            RepositoryContext = repositoryContext;
            logger.LogInformation("Controller StoricoCartelleController started!");

            _hostingEnvironment = hostingEnvironment;

            _configuration = configuration;
            _logger = logger;

            var executingAssembly = Assembly.GetExecutingAssembly();
            log4net.Repository.ILoggerRepository rootRepository = log4net.LogManager.GetRepository(executingAssembly);
            foreach (var appender in rootRepository.GetAppenders())
            {
                if (appender.Name.Equals("RollingFile") && appender is log4net.Appender.FileAppender)
                {
                    var fileAppender = appender as log4net.Appender.FileAppender;
                    fileAppender.File = "Log" +
                        "\\rarapi_" + DateTime.Now.ToString("yyyyMMdd") + ".log";
                    fileAppender.ActivateOptions();
                }
            }
        }

        public RARController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>  
        /// Get the cookie  
        /// </summary>  
        /// <param name="key">Key </param>  
        /// <returns>string value</returns>  
        public string Get(string key)
        {
            return Request.Cookies[key];
        }
        /// <summary>  
        /// set the cookie  
        /// </summary>  
        /// <param name="key">key (unique indentifier)</param>  
        /// <param name="value">value to store in cookie object</param>  
        /// <param name="expireTime">expiration time</param>  
        public void Set(string key, string value, int? expireTime)
        {
            CookieOptions option = new CookieOptions();
            if (expireTime.HasValue)
                option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
            else
                option.Expires = DateTime.Now.AddMilliseconds(10);
            Response.Cookies.Append(key, value, option);
        }
        /// <summary>  
        /// Delete the key  
        /// </summary>  
        /// <param name="key">Key</param>  
        public void Remove(string key)
        {
            Response.Cookies.Delete(key);
        }

        //public IActionResult Index()
        //{
        //    //read cookie from IHttpContextAccessor  
        //    string cookieValueFromContext = string.Empty;
        //    if (_httpContextAccessor.HttpContext.Request.Cookies.ContainsKey("key"))
        //        cookieValueFromContext=_httpContextAccessor.HttpContext.Request.Cookies["key"];
        //    //read cookie from Request object  
        //    string cookieValueFromReq = string.Empty;
        //    if (Request.Cookies.ContainsKey("key"))
        //        cookieValueFromReq = Request.Cookies["key"];

        //    //set the key value in Cookie  
        //    Set("key", "Hello from cookie", 10);
        //    //Delete the cookie object  
        //    Remove("key");
        //    return 
        //    //return View();
        //}
    }
}
