using GerenciamentoDeBiblioteca.API.Models;
using GerenciamentoDeBiblioteca.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        [HttpPost("register")]
        public async Task<ActionResult<UserToken>>Incluir(UsuarioDTO usuarioDTO)
        {
            return View();
        }

    }
}
