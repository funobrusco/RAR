using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RAR.DAL.Model.Tabella;
using RAR.Service;
using RAR.ViewModel;

namespace RAR.API.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class DispaccioController : ControllerBase
    {
        private readonly IDispaccioService _dispaccioService;

        public DispaccioController(IDispaccioService dispaccioService)
        {
            _dispaccioService = dispaccioService;
        }

        // GET api/dispacci/userArrivo
        //[Authorize]
        [HttpGet("GetByUsrArrivo/{userArrivo}")]
        public async Task<ActionResult<IEnumerable<DispaccioViewModel>>> GetByUsrArrivo(string userArrivo)
        {
            if (string.IsNullOrEmpty(userArrivo))
                return NotFound();

            userArrivo = WebUtility.UrlDecode(userArrivo);
            var result = await _dispaccioService.Elenca(userArrivo);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("GetDettaglio/{id}")]
        public async Task<IActionResult> GetDettaglio(long? id)
        {
            if (id == null)
                return NotFound();

            var result = await _dispaccioService.Dettaglio(id.Value);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Apri/{id}/{userApertura}")]
        public async Task<IActionResult> Apri(string userApertura, long? id)
        {
            if (id == null || string.IsNullOrEmpty(userApertura))
                return NotFound();

            var result = await _dispaccioService.Apri(userApertura, id.Value);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("Chiudi/{id}/{userChiusura}")]
        public async Task<IActionResult> Chiudi(string userChiusura, long? id)
        {
            if (id == null || string.IsNullOrEmpty(userChiusura))
                return NotFound();

            var result = await _dispaccioService.Chiudi(userChiusura, id.Value);

            if (result == null)
                return NotFound("Si è verificato un errore durante la chisura del dispaccio");
            //else if (result.Errore())
            //    return NotFound(result.MessaggioErrore);

            return Ok(result);
        }

        [HttpPost("Nuovo")]
        public async Task<IActionResult> Nuovo(NewDispaccioIn nuovoDispaccio)
        {
            if (nuovoDispaccio == null)
                return NotFound("Errore durante il salvataggio: dispaccio non avvalorato correttamente");

            var result = await _dispaccioService.Nuovo(nuovoDispaccio);

            if (result == null)
                return NotFound("Si è verificato un errore durante il salvataggio");
            //else if (result.Errore())
            //    return NotFound(result.MessaggioErrore);

            return Ok(result);
        }

        // GET api/dispacci
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}