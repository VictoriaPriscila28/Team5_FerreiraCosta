using GerenciamentoDeBiblioteca.Domain.Entities;
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
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> Alterar(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Excluir(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                cliente.Excluir();
                _context.Cliente.Update(cliente);
                await _context.SaveChangesAsync();
                return cliente;
            }

            return null;
        }

        public async Task<Cliente> Incluir(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> SelecionarAsync(int id)
        {
            return await _context.Cliente.Where(x => !x.Excluido).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cliente> SelecionarByCPFAsync(string cpf)
        {
            return await _context.Cliente.Where(x => x.CliCPF.Equals(cpf) && !x.Excluido).FirstOrDefaultAsync();
        }

        public async Task<PagedList<Cliente>> SelecionarTodosAsync(int pageNumber, int pageSize)
        {
            var query = _context.Cliente.Where(x => !x.Excluido).OrderByDescending(x => x.Id).AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }
    }

}
