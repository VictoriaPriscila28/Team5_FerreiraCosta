using GerenciamentoDeBiblioteca.Data;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca.Repositorios.Interface;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Repositorios
{
    public class LivroRepositorio : ILivroRepositorio
    {
        private readonly SistemaGerenciamentoDBContext _dbContext;
        public LivroRepositorio(SistemaGerenciamentoDBContext sistemaGerenciamentoDBContext)
        {
            _dbContext = sistemaGerenciamentoDBContext;
;        }
        public async Task<LivroModel> BuscarPorId(int id)
        {
            return await _dbContext.Livros.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LivroModel>> BuscarTodosLivros()
        {
            return await _dbContext.Livros.ToListAsync();
        }
        public async Task<LivroModel> Adicionar(LivroModel livro)
        {
             await _dbContext.Livros.AddAsync(livro);
            await _dbContext.SaveChangesAsync();
            return livro;
        }

        public async Task<LivroModel> Atualizar(LivroModel livro, int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);

            if(livroPorId == null)
            {
                throw new Exception($"Usuario para o ID:{id} não foi encontrado no banco de dados.");
            }

            livroPorId.Titulo = livro.Titulo;
            livroPorId.Status = livro.Status;
            livroPorId.Autor = livro.Autor;
            livroPorId.Categoria = livro.Categoria;
            livroPorId. UsuarioId = livro.UsuarioId;

            _dbContext.Livros.Update(livroPorId);
            await _dbContext.SaveChangesAsync();
            return livroPorId;

        }


        public async Task<bool> Apagar(int id)
        {
            LivroModel livroPorId = await BuscarPorId(id);
            if(livroPorId == null)
            { throw new Exception($"O livro para o ID: {id} não foi encontrado no banco de dados. ");
            }

            _dbContext.Livros.Remove(livroPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

      
    }
}
