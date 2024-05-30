using GerenciamentoDeBiblioteca.API.Extensions;
using GerenciamentoDeBiblioteca.API.Models;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Application.Services;
using GerenciamentoDeBiblioteca.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    /// <summary>
    /// Controlador responsável por lidar com as solicitações relacionadas aos clientes na API.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]

    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        private readonly IUsuarioService _usuarioService;

        public ClienteController(IClienteService clienteService, IUsuarioService usuarioService)
        {
            _clienteService = clienteService;
            _usuarioService = usuarioService;
        }

        /// <summary>
        /// Endpoint para inclusão de um novo cliente.
        /// </summary>
        /// <param name="clienteDTO">Os dados do cliente a serem incluídos.</param>
        /// <returns>Um ActionResult representando o resultado da inclusão.</returns>
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

        /// <summary>
        /// Endpoint para alterar os dados de um cliente existente.
        /// </summary>
        /// <param name="clienteDTO">Os novos dados do cliente.</param>
        /// <returns>Um ActionResult representando o resultado da alteração.</returns>
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

        /// <summary>
        /// Endpoint para excluir um cliente existente.
        /// </summary>
        /// <param name="id">O Id do cliente a ser excluído.</param>
        /// <returns>Um ActionResult representando o resultado da exclusão.</returns>
        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var userId = User.GetId();
            var usuario = await _usuarioService.SelecionarAsync(userId);

            if (!usuario.IsAdmin)
            {
                return Unauthorized("Você não tem permissão para excluir clientes.");
            }

            var clienteDTOExcluido = await _clienteService.Excluir(id);
            if (clienteDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o cliente.");
            }
            return Ok("Cliente excluído com sucesso!");
        }

        /// <summary>
        /// Endpoint para selecionar um cliente com base no ID.
        /// </summary>
        /// <param name="id">O ID do cliente a ser selecionado.</param>
        /// <returns>Um ActionResult representando o resultado da seleção.</returns>

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

        /// <summary>
        /// Endpoint para recuperar todos os clientes com suporte à paginação.
        /// </summary>
        /// <param name="paginationParams">Parâmetros de paginação para a solicitação.</param>
        /// <returns>Um ActionResult representando a lista paginada de clientes.</returns>
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParams)
        {
            var clientesDTO = await _clienteService.SelecionarTodosAsync
                (paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(clientesDTO.CurrentPage,
                clientesDTO.PageSize, clientesDTO.TotalCount, clientesDTO.TotalPages));
            
            return Ok(clientesDTO);
        }
    }
}
