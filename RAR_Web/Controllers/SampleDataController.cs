using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RAR_Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static string[] SummariesNew = new[]
        {
            "Pippo", "Pluto", "Topolino", "Geppetto", "Pinocchio", "Falegname", "Duck", "Quack", "Tack", "Pack"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecastsNew()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = SummariesNew[rng.Next(Summaries.Length)]
            });
        }

        public object GetSession(string sessionName)
        {
            HttpContext httpContext = HttpContext;
            return httpContext.Session.GetString(sessionName);
        }

        //[HttpGet("[action]")]
        //public IEnumerable<NewDispaccioIn> GetDispacci()
        //{
        //    ApiClient.
        //}

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }

        public class Dispaccio
        {
            public string Id { get; set; }
            public string CodDispaccio { get; set; }
            public string Mittente { get; set; }
            public string DataArrivo { get; set; }
            public string DataApertura { get; set; }
            public string DataChiusura { get; set; }
        }
    }
}
