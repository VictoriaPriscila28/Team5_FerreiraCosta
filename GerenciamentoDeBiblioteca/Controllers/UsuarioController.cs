using Microsoft.AspNetCore.Http;
using GerenciamentoDeBiblioteca.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciamentoDeBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return Ok();
        }
    }
        
        

          
    
}
    

