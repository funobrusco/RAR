using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RAR.DAL.Model.Tabella;
using RAR.Service;

namespace RAR.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LookupController : RARController
    {
        private readonly ILookupService _lookupService;

        public LookupController(ILookupService lookupService, RARContext repositoryContext, IConfiguration configuration, ILogger<LookupController> logger, IHostingEnvironment hostingEnvironment)
          : base(repositoryContext, configuration, logger, hostingEnvironment)
        {
            _lookupService = lookupService;
        }

        [HttpGet("Elenca")]
        public async Task<IActionResult> Elenca()
        {
            var result = await _lookupService.Elenca();

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
