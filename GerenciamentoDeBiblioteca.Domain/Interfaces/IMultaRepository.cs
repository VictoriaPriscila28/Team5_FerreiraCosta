using GerenciamentoDeBiblioteca.Domain.Entities;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public interface IMultaRepository
    {
        Task<Multa> Incluir(Multa multa);
        Task<Multa> Alterar(Multa multa);
        Task<Multa> Excluir(int id);
        Task<Multa> SelecionarAsync(int id);
        Task<IEnumerable<Multa>> ListarAsync();
    }
}
