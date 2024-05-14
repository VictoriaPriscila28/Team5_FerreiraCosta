using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class DevolucaoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
