using System;
using System.Net;
using System.Threading.Tasks;
using Domain.Filtros;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmeAtuadoController : ControllerBase
    {
        private IAlarmeAtuadoService _service;

        public AlarmeAtuadoController(IAlarmeAtuadoService service)
        {
            _service = service;
        }

        [HttpPost("BuscarPorFiltroAlarmeAtuado")]
        public async Task<ActionResult> BuscarPorFiltroAlarme([FromBody] FiltroAlarme filtro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.BuscarPorFiltro(filtro));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpGet("BuscarAlarmesMaisAtuados/{numeroOcorrencias}")]
        public async Task<ActionResult> BuscarAlarmesMaisAtuados(int numeroOcorrencias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.BuscarAlarmesMaisAtuados(numeroOcorrencias));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}