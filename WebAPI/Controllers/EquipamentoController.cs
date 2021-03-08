using System;
using System.Net;
using System.Threading.Tasks;
using Domain.DTOs.Equipamento;
using Domain.Filtros;
using Domain.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : Controller
    {
        private IEquipamentoService _service;

        public EquipamentoController(IEquipamentoService service)
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
        [Route("BuscarEquipamentoPorId/{id}", Name = "BuscarEquipamentoPorId")]
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
        public async Task<ActionResult> Cadastrar([FromBody] EquipamentoDTOCadastrar dto)
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
                    return Created(new Uri(Url.Link("BuscarEquipamentoPorId", new {id = result.Id})), result);
                }

                return BadRequest("Número de série já cadastrado");
            }
            catch (ArgumentException e)
            {
                return StatusCode((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("Atualizar/{id}")]
        public async Task<ActionResult> Atualizar([FromBody] EquipamentoDTOAtualizar dto)
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
        
        [HttpPost("BuscarPorFiltroEquipamento")]
        public async Task<ActionResult> BuscarPorFiltroEquipamento([FromBody] FiltroEquipamento filtro)
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