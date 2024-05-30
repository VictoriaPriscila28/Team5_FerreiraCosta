using GerenciamentoDeBiblioteca.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    /// <summary>
    /// Controlador responsável por operações do sistema.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]

    public class SistemaController : Controller
    {

        private readonly IUsuarioService _usuarioService;
        private readonly ISistemaService _sistemaService;

        public SistemaController(IUsuarioService usuarioService, ISistemaService sistemaService)
        {
            _usuarioService = usuarioService;
            _sistemaService = sistemaService;
        }

        /// <summary>
        ///  Verifica se é o primeiro uso do sistema, ou seja, se já existe um usuário cadastrado.
        /// </summary>
        /// <returns>Um objeto indicando se é o primeiro uso do sistema.</returns>
        [HttpGet("VerificaPrimeiroUso")]
        public async Task<ActionResult> PrimeiroUso()
        {
            var existeUsuarioCadastrado = await _usuarioService.ExisteUsuarioCadastradoAsync();

            return Ok(new { primeiroUso = !existeUsuarioCadastrado });
        }

        /// <summary>
        /// Retorna dados para o dashboard, como quantidade de itens.
        /// </summary>
        /// <returns>Um objeto contendo a quantidade de itens no sistema.</returns>
        [HttpGet("Dashboard")]
        [Authorize]
        public async Task<ActionResult> Dashboard()
        {
            var quantidadeItensDTO = await _sistemaService.SelecionarQtdItens();
            return Ok(quantidadeItensDTO);
        }
    }
}
