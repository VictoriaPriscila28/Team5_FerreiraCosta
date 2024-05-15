using Microsoft.AspNetCore.Http;
using GerenciamentoDeBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using Microsoft.AspNetCore.Authorization;


namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaLivroController : ControllerBase
    {
        private readonly LivroRepositorio _livroRepositorio;

        public PesquisaLivroController(LivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        [HttpGet("{titulo}")]
        public async Task<ActionResult<List<LivroModel>>> BuscarPorTitulo(string titulo)
        {
            List<LivroModel> livro = await _livroRepositorio.BuscarPorTitulo(titulo);
            return Ok(livro);
        }

        [HttpGet("{autor}")]
        public async Task<ActionResult<List<LivroModel>>> BuscarPorAutor(string autor)
        {
            List<LivroModel> livro = await _livroRepositorio.BuscarPorAutor(autor);
            return Ok(livro);
        }

        [HttpGet("{genero}")]
        public async Task<ActionResult<List<LivroModel>>> BuscarPorGenero(string genero)
        {
            List<LivroModel> livro = await _livroRepositorio.BuscarPorGenero(genero);
            return Ok(livro);
        }
    }
}


//    É um teste que a gente fez no dia 15/05 || Ainda vamos alterar algumas coisas
