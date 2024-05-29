using GerenciamentoDeBiblioteca.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Interfaces
{
    public interface IMultaService
    {
        Task<MultaDTO> IncluirAsync(MultaDTO multaDto);
        Task<MultaDTO> AlterarAsync(MultaDTO multaDto);
        Task<bool> ExcluirAsync(int id);
        Task<MultaDTO> SelecionarAsync(int id);
        Task<IEnumerable<MultaDTO>> ListarAsync();
    }
}
