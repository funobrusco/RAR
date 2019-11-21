using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RAR.WEB.MVC.Utility;
using RAR.ViewModel;
using System.Collections.Generic;
using System;

namespace RAR.WEB.MVC.Controllers
{
    public class QueryManagerController : CommonController
    {
        public QueryManagerController(IOptions<RARSettings> app, IConfiguration configuration, ILogger<DispaccioController> logger,
            IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor)
            : base(app, configuration, logger, hostingEnvironment, httpContextAccessor)
        {
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                await LoadQuerys();

                var result = new QueryManagerViewModel()
                {
                    Querys = TempData.Get<IEnumerable<QueryViewModel>>("Querys")
                };

                return View("Index", result);
            }
            catch (Exception e)
            {
                return Error(e.ToString());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IFormCollection form, string idQuery)
        {
            try
            {
                await LoadQuerys();

                var queryParameter = form.Keys.ToDictionary(k => k, v => form[v].FirstOrDefault());

                queryParameter.Remove("__RequestVerificationToken");
                queryParameter.Remove("idQuery");

                var qmvm = new QueryManagerViewModel()
                {
                    Querys = TempData.Get<IEnumerable<QueryViewModel>>("Querys"),
                    QueryParameters = queryParameter,
                    SelectedQuery = TempData.Get<IEnumerable<QueryViewModel>>("Querys").ToList()
                        .Find(z => z.IdQuery == idQuery)
                };

                var result = await ApiClientFactory.Instance.ExecuteQuery(qmvm);

                if (result.Errore())
                    TempData.Add("errore", result.MessaggioErrore);
                else
                    qmvm.Resultset = result.Entita;

                TempData.Keep("Querys");

                return View("Index", qmvm);
            }
            catch (Exception e)
            {
                return Error(e.ToString());
            }
        }

        public async Task<IActionResult> GetQuery(int ID_QUERY)
        {
            try
            {
                var data = await ApiClientFactory.Instance.GetQuery(ID_QUERY);

                if ((data == null) || (string.IsNullOrEmpty(data.Testo)))
                    return NotFound();

                return Ok(data.Testo);
            }
            catch (Exception e)
            {
                return Error(e.ToString());
            }
        }

        #region Utility method
        private async Task LoadQuerys()
        {
            try
            {
                if (TempData.Get<IEnumerable<QueryViewModel>>("Querys") == null)
                {
                    var data = await ApiClientFactory.Instance.GetQuery();
                    TempData.Put("Querys", data);
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
    //else
    //    TempData.Keep("Querys");
}
#endregion
