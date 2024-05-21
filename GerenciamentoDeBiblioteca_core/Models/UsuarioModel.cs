using GerenciamentoDeBiblioteca.Core.Models;

namespace GerenciamentoDeBiblioteca.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }

        // Adicionar a propriedade de navegação para Emprestimos
        public ICollection<Emprestimos> Emprestimos { get; set; }
    }
}
