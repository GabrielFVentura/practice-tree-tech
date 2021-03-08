using System;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.Alarme;
using Domain.Filtros;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlarmeController : ControllerBase
    {
        private IAlarmeService _service;

        public AlarmeController(IAlarmeService service)
        {
            _service = service;
        }

        [HttpGet("BuscarTodos")]
        public async Task<ActionResult> BuscarTodos()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.BuscarTodos());
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        [Route("BuscarAlarmePorId/{id}", Name = "BuscarAlarmePorId")]
        public async Task<ActionResult> BuscarPorId(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return Ok(await _service.BuscarPorId(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPost("Cadastrar")]
        public async Task<ActionResult> Cadastrar([FromBody] AlarmeDTOCadastrar dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Cadastrar(dto);
                if (result != null)
                {
                    return Created(new Uri(Url.Link("BuscarAlarmePorId", new {id = result.Id})), result);
                }

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<ActionResult> Atualizar([FromBody] AlarmeDTOAtualizar dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            { 
                var result = await _service.Atualizar(dto);
                
                if (result == null)
                    return BadRequest();
                
                return Ok(result);
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpDelete]
        [Route("Deletar/{id}")]
        public async Task<ActionResult> Deletar(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.Deletar(id);
                return Ok(result);
            }
            
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }
        
        [HttpPost("AtivarOuDesativarAlarme")]
        public async Task<ActionResult> AtivarOuDesativarAlarme([FromBody] AlarmeDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _service.AtivarOuDesativarAlarme(dto);
                if (result)
                    return Ok(result);
                

                return BadRequest();
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }   
        
        [HttpPost("BuscarPorFiltroAlarme")]
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
    }
}

