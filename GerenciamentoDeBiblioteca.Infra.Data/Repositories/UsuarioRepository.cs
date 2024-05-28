using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Infra.Data.Context;
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

        public async Task<IEnumerable<Usuario>> SelecionarTodosAsync()
        {
            return await _context.Usuario.ToListAsync();
        }
    }
}
