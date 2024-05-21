using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.DTOs
{
    public class EmprestimoDto
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdLivro { get; set; }
        public DateTime? DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }
        public string Devolucao { get; set; }
    }
}
