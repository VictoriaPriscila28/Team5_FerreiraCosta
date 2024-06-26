﻿using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Domain.Pagination;
using GerenciamentoDeBiblioteca.Infra.Data.Context;
using GerenciamentoDeBiblioteca.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Infra.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Usuario> Alterar(Usuario usuario)
        {
            if (usuario.PasswordSalt == null || usuario.PasswordHash == null)
            {
                var passwordCripgrafado = await _context.Usuario.Where(x => x.Id == usuario.Id).Select(x => new { x.PasswordHash, x.PasswordSalt }).FirstOrDefaultAsync();
                usuario.AlterarSenha(passwordCripgrafado.PasswordHash, passwordCripgrafado.PasswordSalt);
            }

            _context.Usuario.Update(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Excluir(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                await _context.SaveChangesAsync();
                return usuario;
            }

            return null;
        }

        public async Task<bool> ExisteUsuarioCadastradoAsync()
        {
            return await _context.Usuario.AnyAsync();
        }

        public async Task<Usuario> Incluir(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> SelecionarAsync(int id)
        {
            return await _context.Usuario.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Usuario> SelecionarByCPFAsync(int id)
        {
            throw new NotImplementedException();
        }

        public  async Task<PagedList<Usuario>> SelecionarByFiltroAsync(string nome, string email, bool? isAdmin, bool? isNotAdmin, bool? ativo, bool? inativo, int pageNumber, int pageSize)
        {
            var query = _context.Usuario.OrderByDescending(x => x.Id).AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.Nome.ToLower().Equals(nome.ToLower())
                                     || x.Nome.ToLower().Contains(nome.ToLower()));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToLower().Equals(email.ToLower())
                                     || x.Email.ToLower().Contains(email.ToLower()));
            }

            if (isAdmin.HasValue && isAdmin == true)
            {
                query = query.Where(x => x.IsAdmin == true);
            }
            if (isNotAdmin.HasValue && isNotAdmin == true)
            {
                query = query.Where(x => x.IsAdmin == false);
            }
            if (ativo.HasValue && ativo == true)
            {
                query = query.Where(x => x.Ativo == true);
            }
            if (inativo.HasValue && inativo == true)
            {
                query = query.Where(x => x.Ativo == false);
            }

            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<PagedList<Usuario>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Usuario.OrderByDescending(x => x.Id).AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

       
    }
}
