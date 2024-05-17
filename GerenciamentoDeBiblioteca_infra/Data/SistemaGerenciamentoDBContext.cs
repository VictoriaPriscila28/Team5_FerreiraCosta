
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca_infra.Data.Map;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoDeBiblioteca.Data
{
    public class SistemaGerenciamentoDBContext : DbContext
    {
        public SistemaGerenciamentoDBContext(DbContextOptions<SistemaGerenciamentoDBContext> options)
            : base(options)
        {
            Usuarios = Set<UsuarioModel>();
            Livros = Set<LivroModel>();

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<LivroModel> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
