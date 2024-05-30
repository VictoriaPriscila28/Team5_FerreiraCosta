using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    /// <summary>
    /// Controlador responsável por lidar com as solicitações relacionadas às multas na API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class MultaController : ControllerBase
    {
        private readonly IMultaService _multaService;

        public MultaController(IMultaService multaService)
        {
            _multaService = multaService;
        }

        /// <summary>
        /// Recuperar todas as multas.
        /// </summary>
        /// <returns>ActionResult</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MultaDTO>>> Get()
        {
            var multas = await _multaService.ListarAsync();
            return Ok(multas);
        }

        /// <summary>
        /// Recuperar uma multa com base no Id.
        /// </summary>
        /// <param name="id">O identificador único da multa a ser recuperada.</param>
        /// <returns>ActionResult</returns>
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

        /// <summary>
        /// Incluir uma nova multa.
        /// </summary>
        /// <param name="multaDto">Os dados da multa a serem incluídos.</param>
        /// <returns>ActionResult</returns>
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

        /// <summary>
        /// Atualizar uma multa existente com base no Id.
        /// </summary>
        /// <param name="id">O identificador único da multa a ser atualizada.</param>
        /// <param name="multaDto">Os dados da multa a serem atualizados.</param>
        /// <returns>ActionResult</returns>
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

        /// <summary>
        /// Excluir uma multa existente com base no Id.
        /// </summary>
        /// <param name="id">O Id da multa a ser excluída.</param>
        /// <returns>ActionResult</returns>
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
