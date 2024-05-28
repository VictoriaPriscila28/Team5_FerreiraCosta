using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Application.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class LivroController : Controller
    {

        private readonly ILivroService _livroService;

        public LivroController(ILivroService livroService)
        {
            _livroService = livroService;
        }

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

        [HttpGet]
        public async Task<ActionResult> SelecionarTodos()
        {
            var livrosDTO = await _livroService.SelecionarTodosAsync();
            return Ok(livrosDTO);
        }





    }
}
    
