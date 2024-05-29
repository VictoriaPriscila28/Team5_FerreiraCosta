using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO);
        Task<UsuarioPutDTO> Alterar(UsuarioPutDTO usuarioPutDTO);
        Task<UsuarioDTO> Excluir(int id);
        Task<UsuarioDTO> SelecionarAsync(int id);
        Task<PagedList<UsuarioDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool>ExisteUsuarioCadastradoAsync();
        Task<PagedList<UsuarioDTO>> SelecionarByFiltroAsync(string nome, string email, bool? isAdmin, bool? isNotAdmin, bool? ativo, bool? inativo, int pageNumber, int pageSize);
    }
}
