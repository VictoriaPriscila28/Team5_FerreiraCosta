using GerenciamentoDeBiblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data
{
    public class SistemaGerenciamentoDBContext : DbContext
    {
        public SistemaGerenciamentoDBContext(DbContextOptions<SistemaGerenciamentoDBContext> options)
            : base(options)
        {  
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LivroModel> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
