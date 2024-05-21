using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.DTOs
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Cpf { get; set; }
        public string NomeUsuario { get; set; }
        public int? IdadeUsuario { get; set; }
        
    }
}
