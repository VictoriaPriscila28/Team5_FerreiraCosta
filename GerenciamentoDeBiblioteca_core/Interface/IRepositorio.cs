using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca_core.Models;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface IRepositorio<T> where T : EntidadeBaseModel
    {
        IEnumerable<T> GetTodos();
        Task<T> GetById(int id);
        Task Inserir(T entity);
        void Atualizar(T entity);
        Task Apagar(int id);
    }
}
