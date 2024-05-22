using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using GerenciamentoDeBiblioteca_core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Servicos
{
    public class LivroServico : ILivroServico
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio)
        {
            _livroRepositorio = livroRepositorio;
        }

        public async Task<IEnumerable<LivroModel>> PesquisarPorTitulo(string titulo)
        {
            return await _livroRepositorio.PesquisarPorTitulo(titulo);
        }

        public async Task<IEnumerable<LivroModel>> PesquisarPorAutor(string autor)
        {
            return await _livroRepositorio.PesquisarPorAutor(autor);
        }

        public async Task<IEnumerable<LivroModel>> PesquisarPorCategoria(string categoria)
        {
            return await _livroRepositorio.PesquisarPorCategoria(categoria);
        }

       
    }
}
