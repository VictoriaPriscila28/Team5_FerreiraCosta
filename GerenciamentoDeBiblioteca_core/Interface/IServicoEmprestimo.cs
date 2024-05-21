using GerenciamentoDeBiblioteca.Core.Models;
using GerenciamentoDeBiblioteca_core.ConsultaFiltro;
using GerenciamentoDeBiblioteca_core.ModificarEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface IServicoEmprestimo
    {
        ListaPaginada<Emprestimos> GetEmprestimos(EmprestimoConsultaFiltro filtro);

        Task<Emprestimos> GetEmprestimo(int id);

        Task InserirEmprestimo(Emprestimos emprestimo);

        Task<bool> AtualizarEmprestimo(Emprestimos emprestimo);

        Task<bool> ApagarEmprestimo(int id);
    }
}
