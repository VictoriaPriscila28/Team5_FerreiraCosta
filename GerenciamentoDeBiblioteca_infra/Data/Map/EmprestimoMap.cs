using GerenciamentoDeBiblioteca.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciamentoDeBiblioteca_infra.Data.Map
{
    public class EmprestimoMap : IEntityTypeConfiguration<Emprestimos>
    {
        public void Configure(EntityTypeBuilder<Emprestimos> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.Usuario)
                   .WithMany(u => u.Emprestimos)
                   .HasForeignKey(e => e.UsuarioId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Livro)
                   .WithMany(l => l.Emprestimos)
                   .HasForeignKey(e => e.LivroId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(e => e.DataEmprestimo)
                   .IsRequired();

            builder.Property(e => e.DataDevolucao)
                   .IsRequired(false);
        }
    }
}
