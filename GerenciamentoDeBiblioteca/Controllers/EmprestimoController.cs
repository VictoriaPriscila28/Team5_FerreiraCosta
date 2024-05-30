using GerenciamentoDeBiblioteca.API.Extensions;
using GerenciamentoDeBiblioteca.API.Models;
using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    /// <summary>
    /// Controlador responsável por lidar com as solicitações relacionadas aos empréstimos na API.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoService _emprestimoService;

        public EmprestimoController(IEmprestimoService emprestimoService)
        {
            _emprestimoService = emprestimoService;
        }

        /// <summary>
        /// Realiza a inclusão de um novo empréstimo.
        /// </summary>
        /// <param name="emprestimoPostDTO">Os dados do empréstimo a serem incluídos.</param>
        /// <returns>Um ActionResult representando o resultado da inclusão.</returns>
        [HttpPost]
        public async Task<ActionResult> Incluir(EmprestimoPostDTO emprestimoPostDTO)
        {
            var disponivel = await _emprestimoService.VerificaDisponibilidadeAsync(emprestimoPostDTO.IdLivro);
            if (!disponivel)
            {
                return BadRequest("O livro não está disponível para empréstimo");
            }

            emprestimoPostDTO.DataEmprestimo = DateTime.Now;
            emprestimoPostDTO.Entregue = false;
            var emprestimoDTOIncluido = await _emprestimoService.Incluir(emprestimoPostDTO);
            if (emprestimoDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir  o empréstimo.");
            }

            return Ok("Empréstimo incluído com sucesso.");
        }

        /// <summary>
        /// Altera os dados de um empréstimo existente.
        /// </summary>
        /// <param name="emprestimoPutDTO">Os novos dados do empréstimo.</param>
        /// <returns>Um ActionResult representando o resultado da alteração.</returns>
        [HttpPut]
        public async Task<ActionResult> Alterar(EmprestimoPutDTO emprestimoPutDTO)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(emprestimoPutDTO.Id);

            if (emprestimoDTO == null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            emprestimoDTO.DataEntrega = emprestimoPutDTO.DataEntrega;
            emprestimoDTO.Entregue = emprestimoPutDTO.Entregue;

            var emprestimoDTOAlterado = await _emprestimoService.Alterar(emprestimoDTO);
            if (emprestimoDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o empréstimo.");
            }

            return Ok("Empréstimo alterado com sucesso.");
        }

        /// <summary>
        /// Exclui um empréstimo existente com base no Id.
        /// </summary>
        /// <param name="id">O Id do empréstimo a ser excluído.</param>
        /// <returns>Um ActionResult representando o resultado da exclusão.</returns>
        [HttpDelete]
        public async Task<ActionResult> Excluir(int id)
        {
            var emprestimoDTOExcluido = await _emprestimoService.Excluir(id);
            if (emprestimoDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o empréstimo.");
            }

            return Ok("Empréstimo excluído com sucesso.");
        }

        /// <summary>
        /// Seleciona um empréstimo com base no Id.
        /// </summary>
        /// <param name="id">O Id do empréstimo a ser selecionado.</param>
        /// <returns>Um ActionResult representando o empréstimo selecionado.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(id);
            if (emprestimoDTO == null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            return Ok(emprestimoDTO);
        }

        /// <summary>
        /// Recupera todos os empréstimos com suporte à paginação.
        /// </summary>
        /// <param name="paginationParams">Os parâmetros de paginação.</param>
        /// <returns>Um ActionResult representando os empréstimos recuperados.</returns>
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos([FromQuery] PaginationParams paginationParams)
        {
            var emprestimosDTO = await _emprestimoService.SelecionarTodosAsync(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber,
                paginationParams.PageSize, emprestimosDTO.TotalCount, emprestimosDTO.TotalPages));

            return Ok(emprestimosDTO);
        }

        /// <summary>
        /// Devolve um empréstimo existente com base no Id.
        /// </summary>
        /// <param name="id">O Id do empréstimo a ser devolvido.</param>
        /// <returns>Um ActionResult representando o resultado da devolução.</returns>
        [HttpPost("devolver/{id}")]
        public async Task<ActionResult> DevolverEmprestimo(int id)
        {
            var emprestimoDTO = await _emprestimoService.SelecionarAsync(id);

            if (emprestimoDTO == null)
            {
                return NotFound("Empréstimo não encontrado.");
            }

            // Adicione sua lógica de devolução aqui
            emprestimoDTO.DataDevolucao = DateTime.Now;

            var emprestimoDTOAlterado = await _emprestimoService.Alterar(emprestimoDTO);
            if (emprestimoDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao devolver o empréstimo.");
            }

            return Ok("Empréstimo devolvido com sucesso.");
        }
    }
}
