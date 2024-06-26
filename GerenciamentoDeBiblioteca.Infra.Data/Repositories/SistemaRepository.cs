﻿using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.SystemModels;
using GerenciamentoDeBiblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Infra.Data.Repositories
{
    public class SistemaRepository : ISistemaRepository
    {
        private readonly ApplicationDbContext _context;

        public SistemaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<QuantidadeItens> SelecionarQtdItens()
        {
            QuantidadeItens quantidadeItens = new QuantidadeItens();
            quantidadeItens.QtdLivro = await _context.Livro.CountAsync();
            quantidadeItens.QtdCliente = await _context.Cliente.CountAsync();
            quantidadeItens.QtdEmprestimo = await _context.Emprestimo.CountAsync();
            return quantidadeItens;
        }

        
    }
}
