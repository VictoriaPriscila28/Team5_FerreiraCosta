using GerenciamentoDeBiblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoDeBiblioteca.Infra.Data.EntitiesConfiguration
{
    public class MultaConfiguration : IEntityTypeConfiguration<Multa>
    {
        public void Configure(EntityTypeBuilder<Multa> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.DiasAtraso).IsRequired();
            builder.Property(x => x.EmprestimoId).IsRequired();
            builder.Property(x => x.ValorMulta).IsRequired();

            builder.HasOne(x => x.Emprestimo)
                   .WithMany(x => x.Multas)
                   .HasForeignKey(x => x.EmprestimoId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
