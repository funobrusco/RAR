using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RAR.DAL.Model.Tabella;
using RAR.DAL.StoredProcedure;
using RAR.Service;
using RAR.ViewModel;

namespace RAR.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QueryManagerController : RARController
    {
        private readonly IQueryManagerService queryManagerService;

        public QueryManagerController(IQueryManagerService queryManagerService, RARContext repositoryContext, IConfiguration configuration, ILogger<QueryManagerController> logger, IHostingEnvironment hostingEnvironment)
          : base(repositoryContext, configuration, logger, hostingEnvironment)
        {
            this.queryManagerService = queryManagerService;
        }

        [HttpGet("GetAsync")]
        public async Task<IActionResult> GetAsync()
        {
            var result = await queryManagerService.Elenca();
            if (result == null)
                return NotFound();

            return Ok(result);
        }


        [HttpGet("dammiQuery/{ID_QUERY}")]
        public async Task<IActionResult> DammiQuery(int ID_QUERY)
        {
            try
            {
                _logger.LogInformation("Stored procedure execution: DammiQuery");

                var result = await new DammiQuery(RepositoryContext).Get(ID_QUERY);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return Content(ex.Message);
            }
        }

        [HttpPost("ExecuteQuery")]
        public async Task<IActionResult> ExecuteQuery(QueryManagerViewModel queryManagerViewModel)
        {
            var result = new ResultStoredViewModel<string[][]>();
            //var pattern = @"\$\#([a-zA-Z0-9_()/',=\s\.]+)\#\$"; [17/06 Non funzionante (FD)]
            var pattern = @"\$#(.+?)\#\$";
            _logger.LogInformation("Stored procedure execution: DammiQuery");

            try
            {
                var querySQL = new DammiQuery(RepositoryContext);
                queryManagerViewModel.SelectedQuery.SQL =
                    querySQL.Get(Convert.ToInt32(queryManagerViewModel.SelectedQuery.IdQuery)).Result.Testo;

                //ricerca dei parametri compresi tra $# e #$ nell'SQL
                string[] queryParameters = Regex.Matches(queryManagerViewModel.SelectedQuery.SQL, pattern)
                            .Cast<Match>()
                            .Select(s => s.Groups[0].Value)
                            .Distinct()
                            .ToArray();

                // crea un dictionary che utilizza come chiave ciascuna parte della query compresa tra $# e #$ e come valore il parametro passato da 
                //URL la cui chiave è contenuta nel testo della parte della query compresa tra $# e #$
                var parametersValue = new Dictionary<string, string>();

                foreach (var item in queryParameters)
                    foreach (var par in queryManagerViewModel.QueryParameters)
                        if (item.Contains(par.Key))
                            parametersValue.Add(item, par.Value);

                var queryToExecute = Regex.Replace(queryManagerViewModel.SelectedQuery.SQL, pattern,
                    m => parametersValue.ContainsKey(m.Value) ?
                    string.Format("'{0}'", parametersValue[m.Value]) : m.Value);

                // esegue la query con i parametri passati da URL
                _logger.LogInformation("Query execution");

                await EseguiQuery(queryManagerViewModel, result, queryToExecute);

                FormatStringAsDate(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                return Content(ex.Message);
            }
        }

        private void FormatStringAsDate(ResultStoredViewModel<string[][]> result)
        {
            if (result.Entita != null)
                for (int k = 0; k < result.Entita.GetLength(0); k++)
                    for (int l = 0; l < result.Entita[k].GetLength(0); l++)
                    {
                        DateTime dateFormatted;
                        if (DateTime.TryParse(result.Entita[k][l], out dateFormatted))
                        {
                            result.Entita[k][l] = dateFormatted.ToShortDateString();
                        }
                    }
        }

        private async Task EseguiQuery(QueryManagerViewModel queryManagerViewModel, ResultStoredViewModel<string[][]> result, string queryToExecute)
        {
            var connectionString = RepositoryContext.ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            using (var cmd = new SqlCommand(queryToExecute, connection))
            {
                connection.Open();
                try
                {
                    result.Entita = await ExecuteQuery(cmd);
                }
                catch (Exception queryException)
                {
                    result.ImpostaErrore(queryException.HResult,
                        string.Format("{0} - {1}", queryManagerViewModel.SelectedQuery.Descrizione,
                        queryException.Message));
                }
            }
        }

        private string ConvertObjectToString(object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }
        private async Task<string[][]> ExecuteQuery(SqlCommand cmd)
        {
            string[][] result;
            using (var dataReader = await cmd.ExecuteReaderAsync())
            {
                var dataTable = new DataTable();
                dataTable.Load(dataReader);

                var temp = dataTable.AsEnumerable().Select(row =>
                    Array.ConvertAll(row.ItemArray, ConvertObjectToString)).ToList();

                var columnNames = (from dc in dataTable.Columns.Cast<DataColumn>()
                                   select dc.ColumnName).ToArray();

                temp.Insert(0, columnNames);
                result = temp.ToArray();
            }

            return result;
        }
    }
}