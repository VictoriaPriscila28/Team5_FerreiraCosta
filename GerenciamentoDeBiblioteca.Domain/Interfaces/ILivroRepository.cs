﻿using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Domain.Interfaces
{
    public interface ILivroRepository
    {
        Task<Livro> Incluir(Livro livro);
        Task<Livro> Alterar(Livro livro);
        Task<Livro> Excluir(int id);
        Task<Livro> SelecionarAsync(int id);
        Task<PagedList<Livro>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<PagedList<Livro>> SelecionarByFiltroAsync(
        string nome, string autor, string editora,
        DateTime? anoPublicacao, string edicao, int pageNumber, int pageSize);
        Task<PagedList<Livro>> SelecionarByFiltroAsync(string termo, int pageNumber, int pageSize);
    }
}
