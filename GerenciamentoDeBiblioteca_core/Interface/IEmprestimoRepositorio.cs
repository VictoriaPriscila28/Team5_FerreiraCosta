using GerenciamentoDeBiblioteca.Core.Models;
using GerenciamentoDeBiblioteca_core.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface IEmprestimoRepositorio : IRepositorio<Emprestimos>
    {
        Task<IEnumerable<Emprestimos>> GetEmprestimoByUsuario(int idUsuario);

        Task<IEnumerable<Emprestimos>> GetEmprestimoByLivro(int idLivro);

    }
}
