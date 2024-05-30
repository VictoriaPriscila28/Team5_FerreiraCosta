using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    /// <summary>
    /// Controlador responsável por lidar com as solicitações relacionadas aos livros na API.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]


    public class LivroController : Controller
    {

        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

        /// <summary>
        /// Inclui um novo livro.
        /// </summary>
        /// <param name="livroDTO">Os dados do livro a serem incluídos.</param>
        /// <returns>Um ActionResult representando o resultado da inclusão.</returns>
        [HttpPost]
        public async Task<ActionResult> Incluir(LivroDTO livroDTO)
        {
            var livroDTOIncluido = await _livroService.Incluir(livroDTO);
            if (livroDTOIncluido == null)
            {
                return BadRequest("Ocorreu um erro ao incluir o livro.");
            }

            return Ok(new { message = "Livro incluído com sucesso!" });
        }

        /// <summary>
        /// Altera os dados de um livro existente.
        /// </summary>
        /// <param name="livroDTO">Os novos dados do livro.</param>
        /// <returns>Um ActionResult representando o resultado da alteração.</returns>
        [HttpPut]
        public async Task<ActionResult> Alterar(LivroDTO livroDTO)
        {
            var livroDTOAlterado = await _livroService.Alterar(livroDTO);
            if (livroDTOAlterado == null)
            {
                return BadRequest("Ocorreu um erro ao alterar o livro.");
            }

            return Ok(new { message = "Livro alterado com sucesso!" });
        }

        /// <summary>
        /// Exclui um livro existente com base no Id.
        /// </summary>
        /// <param name="id">O Id do livro a ser excluído.</param>
        /// <returns>Um ActionResult representando o resultado da exclusão.</returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            var livroDTOExcluido = await _livroService.Excluir(id);
            if (livroDTOExcluido == null)
            {
                return BadRequest("Ocorreu um erro ao excluir o livro.");
            }

            return Ok(new { message = "Livro excluído com sucesso!" });
        }

        /// <summary>
        /// Seleciona um livro com base no Id.
        /// </summary>
        /// <param name="id">O Id do livro a ser selecionado.</param>
        /// <returns>Um ActionResult representando o resultado da seleção.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult> Selecionar(int id)
        {
            var livroDTO = await _livroService.SelecionarAsync(id);
            if (livroDTO == null)
            {
                return NotFound("Livro não encontrado.");
            }

            return Ok(livroDTO);
        }

        /// <summary>
        /// Recupera todos os livros.
        /// </summary>
        /// <returns>Um ActionResult representando a lista de todos os livros.</returns>
        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var livrosDTO = await _livroService.SelecionarTodosAsync();
            return Ok(livrosDTO);
        }





    }
}
    
