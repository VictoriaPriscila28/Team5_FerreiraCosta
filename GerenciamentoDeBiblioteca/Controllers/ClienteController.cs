using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public async Task<ActionResult>Incluir(ClienteDTO clienteDTO)
        {
            var clienteDTOIncluido = await _clienteService.Incluir(clienteDTO);
            if (clienteDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o cliente.");
            }
            return Ok("Cliente incluído com sucesso!");
        }


        [HttpPut]
        public async Task<ActionResult> Alterar(ClienteDTO clienteDTO)
        {
            var clienteDTOAlterado = await _clienteService.Alterar(clienteDTO);
            if (clienteDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o cliente.");
            }
            return Ok("Cliente alterado com sucesso!");
        }

        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var clienteDTOExcluido = await _clienteService.Excluir(id);
            if (clienteDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente.");
            }
            return Ok("Cliente excluído com sucesso!");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id )
        {
            var clienteDTO = await _clienteService.SelecionarAsync(id);
            if (clienteDTO == null)
            {
                return NotFound("Cliente não encontrado");
            }
            return Ok(clienteDTO);
        }

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos(int id)
        {
            var clientesDTO = await _clienteService.SelecionarTodosAsync();
            
            return Ok(clientesDTO);
        }
    }
}
