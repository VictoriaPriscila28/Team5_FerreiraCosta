using GerenciamentoDeBiblioteca.Domain.Entities;
using GerenciamentoDeBiblioteca.Domain.Interfaces;
using GerenciamentoDeBiblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca.Infra.Data.Repositories
{
    public class MultaRepository : IMultaRepository
    {
        private readonly ApplicationDbContext _context;

        public MultaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Multa> Incluir(Multa multa)
        {
            await _context.Multas.AddAsync(multa);
            await _context.SaveChangesAsync();
            return multa;
        }

        public async Task<Multa> Alterar(Multa multa)
        {
            _context.Multas.Update(multa);
            await _context.SaveChangesAsync();
            return multa;
        }

        public async Task<Multa> Excluir(int id)
        {
            var multa = await _context.Multas.FindAsync(id);
            if (multa == null)
            {
                return null;
            }

            _context.Multas.Remove(multa);
            await _context.SaveChangesAsync();
            return multa;
        }

        public async Task<Multa> SelecionarAsync(int id)
        {
            return await _context.Multas.FindAsync(id);
        }

        public async Task<IEnumerable<Multa>> ListarAsync()
        {
            return await _context.Multas.ToListAsync();
        }
    }
}
//teste