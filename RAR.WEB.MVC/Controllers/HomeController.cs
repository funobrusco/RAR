using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace RAR.WEB.MVC.Controllers
{
    public class HomeController : CommonController
    {
        public HomeController(IOptions<RARSettings> app, IConfiguration configuration, ILogger<HomeController> logger, 
            IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        { }

        public IActionResult Index()
        {
            //var data = ApiClientFactory.Instance.Login(user);
            _logger.LogInformation("HomeController Index() started!");
            return View();
        }
    }
}
