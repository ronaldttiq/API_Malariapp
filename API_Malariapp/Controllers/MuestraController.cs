using Comun.Dto;
using Microsoft.AspNetCore.Mvc;
using Negocio.Contrato;

namespace API_Malariapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MuestraController : ControllerBase
    {
        private readonly IMuestra muestra;
        private readonly ILogger<MuestraController> logger;

        public MuestraController(
            IMuestra _muestra,
            ILogger<MuestraController> _logger)
        {
            muestra = _muestra ?? throw new ArgumentNullException(nameof(_muestra));
            logger = _logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] MuestraDto muestraDto)
        {
            return Ok(await muestra.GuardarAsync<MuestraDto, bool>(muestraDto));
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> Actualizar([FromBody] MuestraDto muestraDto)
        {
            return Ok(await muestra.ActualizarAsync<MuestraDto, bool>(muestraDto));
        }

        [HttpDelete]
        [Route("Eliminar")]
        public async Task<IActionResult> Eliminar([FromBody] MuestraDto muestraDto)
        {
            return Ok(await muestra.EliminarAsync<MuestraDto, bool>(muestraDto));
        }

        [HttpGet]
        [Route("ConsultarLista")]
        public async Task<IActionResult> ConsultarLista()
        {
            return Ok(await muestra.ConsultarListaAsync<List<MuestraDto>>());
        }

        [HttpGet]
        [Route("ConsultaListabyId/{id}")]
        public async Task<IActionResult> ConsultaListabyId(int id)
        {
            return Ok(await muestra.ConsultaListabyIdAsync<int, MuestraDto>(id));
        }
    }
}