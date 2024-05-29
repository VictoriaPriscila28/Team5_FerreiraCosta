using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MultaController : ControllerBase
    {
        private readonly IMultaService _multaService;

        public MultaController(IMultaService multaService)
        {
            _multaService = multaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultaDTO>>> Get()
        {
            var multas = await _multaService.ListarAsync();
            return Ok(multas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MultaDTO>> Get(int id)
        {
            var multa = await _multaService.SelecionarAsync(id);
            if (multa == null)
            {
                return NotFound();
            }
            return Ok(multa);
        }

        [HttpPost]
        public async Task<ActionResult<MultaDTO>> Post([FromBody] MultaDTO multaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _multaService.IncluirAsync(multaDto);
            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<MultaDTO>> Put(int id, [FromBody] MultaDTO multaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != multaDto.Id)
            {
                return BadRequest();
            }

            var result = await _multaService.AlterarAsync(multaDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _multaService.ExcluirAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
