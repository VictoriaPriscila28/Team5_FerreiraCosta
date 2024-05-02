using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca.Repositorios.Interface
{
    public interface ILivroRepositorio
    {
        Task<List<LivroModel>> BuscarTodosLivros();
        Task<LivroModel>BuscarPorId(int id);
        Task<LivroModel> Adicionar(LivroModel livro);
        Task<LivroModel> Atualizar(LivroModel livro, int id);
        Task<bool>Apagar(int id);


    }
}
