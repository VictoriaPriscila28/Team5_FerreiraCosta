namespace GerenciamentoDeBiblioteca.Models
{
    public class LivroModel
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Autor { get; set;}
        public string? Categoria { get; set; }
        public int Status { get; set; }
    }
}
