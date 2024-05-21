using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GerenciamentoDeBiblioteca_core.Models.AtividadeModel;

namespace GerenciamentoDeBiblioteca_infra.Data.Map
{
    public class AtividadeMap : IEntityTypeConfiguration<Atividade>
    {
        public void Configure(EntityTypeBuilder<Atividade> builder)
        {
            builder.HasKey(a => a.Id);
            // Outras configurações de mapeamento
        }
    }
}
