using GerenciamentoDeBiblioteca.Enums;

namespace GerenciamentoDeBiblioteca.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set;}
        public string? Categoria { get; set; }
        public StatusLivro Status { get; set; }
        public int? UsuarioId { get; set; }
        public virtual UsuarioModel? Usuario { get; set; }
    }
}
