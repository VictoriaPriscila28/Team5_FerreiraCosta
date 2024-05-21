using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.DTOs
{
    public class LivroDto
    {
        public int Id { get; set; }
        public string TituloLivro { get; set; }
        public string EditoraLivro { get; set; }
        public string CategoriaLivro { get; set; }
    }
}

