using GerenciamentoDeBiblioteca.Core.Models;
using GerenciamentoDeBiblioteca.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GerenciamentoDeBiblioteca.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set; }
        public string? Categoria { get; set; }
        public StatusLivro Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }

        // Adicionar a propriedade de navegação para Emprestimos
        public ICollection<Emprestimos> Emprestimos { get; set; }
    }
}
