using GerenciamentoDeBiblioteca_core.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_core.Interface
{
    public interface IAtividadeRepositorio
    {
        Task AdicionarAtividade(AtividadeModel.Atividade atividade);
        Task<IEnumerable<AtividadeModel.Atividade>> ObterAtividades();
        Task<IEnumerable<AtividadeModel.Atividade>> ObterAtividadesPorUsuario(int usuarioId);
    }

    public class AtividadeRepositorio : IAtividadeRepositorio
    {
        private readonly SistemaGerenciamentoDBContext _context;

        public AtividadeRepositorio(SistemaGerenciamentoDBContext context)
        {
            _context = context;
        }

        public async Task AdicionarAtividade(AtividadeModel.Atividade atividade)
        {
            _context.Atividades.Add(atividade);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AtividadeModel.Atividade>> ObterAtividades()
        {
            return await _context.Atividades.ToListAsync();
        }

        public async Task<IEnumerable<AtividadeModel.Atividade>> ObterAtividadesPorUsuario(int usuarioId)
        {
            return await _context.Atividades.Where(a => a.UsuarioId == usuarioId).ToListAsync();
        }
    }
}


