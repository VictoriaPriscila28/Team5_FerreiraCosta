using GerenciamentoDeBiblioteca_core.ConsultaFiltro;
using GerenciamentoDeBiblioteca_core.ModificarEntidades;
using GerenciamentoDeBiblioteca_core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Models;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface IServicoLivro
    {
        ListaPaginada<LivroModel> GetLivros(LivroConsultaFiltro filtro);

        Task<LivroModel> GetLivro(int id);

        Task InserirLivro(LivroModel livro);

        Task<bool> AtualizarLivro(LivroModel livro);

        Task<bool> ApagarLivro(int id);
    }
}
