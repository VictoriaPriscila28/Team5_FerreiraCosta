using GerenciamentoDeBiblioteca.Models;
using GerenciamentoDeBiblioteca_infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoDeBiblioteca_infra.Data.Map
{
    public class LivroMap : IEntityTypeConfiguration<LivroModel>
    {
        public void Configure(EntityTypeBuilder<LivroModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Autor).IsRequired().HasMaxLength(155);
            builder.Property(x => x.Categoria).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Status);
            builder.Property(x => x.UsuarioId);

            builder.HasOne(x => x.Usuario);
        }
    }
}