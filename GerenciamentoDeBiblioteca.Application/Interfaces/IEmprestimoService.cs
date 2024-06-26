﻿using GerenciamentoDeBiblioteca.Application.DTOs;
using GerenciamentoDeBiblioteca.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Application.Interfaces
{
    public interface IEmprestimoService
    {
        Task<EmprestimoDTO> Incluir(EmprestimoPostDTO emprestimoPostDTO);
        Task<EmprestimoDTO> Alterar(EmprestimoDTO emprestimoDTO);
        Task<EmprestimoDTO> Excluir(int id);
        Task<EmprestimoDTO> SelecionarAsync(int id);
        Task<PagedList<EmprestimoDTO>> SelecionarTodosAsync(int pageNumber, int pageSize);
        Task<bool> VerificaDisponibilidadeAsync(int idLivro);
        Task<bool> VerificaLivrosAsync(int idLivro);
       
    }
}
