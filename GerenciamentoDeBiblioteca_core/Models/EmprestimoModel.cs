
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Core.Models
{
    public class Emprestimos : EntidadeBaseModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public UsuarioModel Usuario { get; set; }
        public LivroModel Livro { get; set; }

    }
}

