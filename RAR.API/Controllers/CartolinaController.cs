using Microsoft.AspNetCore.Mvc;
using RAR.DAL.Model.Tabella;
using RAR.Service;
using System.Threading.Tasks;

namespace RAR.API.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CartolinaController : ControllerBase
    {
        private readonly ICartolinaService _cartolinaService;

        public CartolinaController(ICartolinaService cartolinaService)
        {
            _cartolinaService = cartolinaService;
        }

        [HttpGet("Cancella/{codeRracc}")]
        public async Task<IActionResult> Cancella(long? codeRracc)
        {
            if (codeRracc == null)
                return BadRequest("Codice raccomandata non valido");

            var result = await _cartolinaService.Cancella(codeRracc.Value);

            if (result == null)
                return NotFound(string.Format("Cartolina con code racc {0} non trovata", codeRracc.Value));

            return Ok(result);
        }

        [HttpPost("Nuova")]
        public async Task<IActionResult> Nuova(NewCartolineDispaccioIn nuovaCartolina)
        {
            if (nuovaCartolina == null)
                return BadRequest("Cartolina non valida");

            var result = await _cartolinaService.Nuova(nuovaCartolina);
            
            return Ok(result);
        }

        [HttpGet("Elenca")]
        public async Task<IActionResult> Elenca(long? idDispaccio)
        {
            if (idDispaccio == null)
                return NotFound("Id dispaccio non valido");

            var result = await _cartolinaService.Elenca(idDispaccio.Value);

            return Ok(result);
        }

        [HttpGet("GetCartoline/{id}")]
        public async Task<IActionResult> GetCartoline(long? id)
        {
            if (id == null)
                return NotFound("Id dispaccio non valido");

            var result = await _cartolinaService.Elenca(id.Value);

            if (result == null)
                return NotFound(string.Format("Non sono state trovate cartoline per il dispaccio {0}", id.Value));

            return Ok(result);
        }
    }
}