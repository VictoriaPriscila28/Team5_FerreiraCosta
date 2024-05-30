using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Interfaces
{
    public interface ILivroService
    {
        Task<LivroDTO> Incluir(LivroDTO livroDTO);
        Task<LivroDTO> Alterar(LivroDTO livroDTO);
        Task<LivroDTO> Excluir(int id);
        Task<LivroDTO> SelecionarAsync(int id);
        Task<PagedList<LivroDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<PagedList<LivroDTO>> SelecionarByFiltroAsync(
        string nome, string autor, string editora,
        DateTime? anoPublicacao, string edicao, int pageNumber, int pageSize);
        Task<PagedList<LivroDTO>> SelecionarByFiltroAsync(string termo, int pageNumber, int pageSize);
    }
}
