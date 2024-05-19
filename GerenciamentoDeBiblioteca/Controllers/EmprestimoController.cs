using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoDeBiblioteca.Controllers
{
    public class EmprestimoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
