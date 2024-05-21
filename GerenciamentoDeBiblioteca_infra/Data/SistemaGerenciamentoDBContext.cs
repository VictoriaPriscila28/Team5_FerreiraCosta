
using GerenciamentoDeBiblioteca.Core.Models;
using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca_infra.Data.Map;
using Microsoft.EntityFrameworkCore;
using static GerenciamentoDeBiblioteca_core.Models.AtividadeModel;

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
        public DbSet<Emprestimos> Emprestimos { get; set; }
        public DbSet<Atividade> Atividades { get; set; } // Adicione esta linha
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new EmprestimoMap()); // Adicione esta linha
            modelBuilder.ApplyConfiguration(new AtividadeMap()); // Adicione esta linha

            base.OnModelCreating(modelBuilder);
        }
    }
}
