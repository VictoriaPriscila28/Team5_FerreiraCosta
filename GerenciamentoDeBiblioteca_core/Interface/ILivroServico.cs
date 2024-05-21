using GerenciamentoDeBiblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface ILivroServico
    {
        Task<IEnumerable<LivroModel>> PesquisarPorTitulo(string titulo);
        Task<IEnumerable<LivroModel>> PesquisarPorAutor(string autor);
        Task<IEnumerable<LivroModel>> PesquisarPorCategoria(string categoria);
        // Outros métodos do serviço...
    }
}
