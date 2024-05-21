using GerenciamentoDeBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Models
{
    public partial class LivroAutorModel
    {
        public int IdAutor { get; set; }
        public int IdLivro { get; set; }

        public virtual AutorModel IdAutorNavegacao { get; set; }
        public virtual LivroModel IdLivroNavegacao { get; set; }
    }
}
