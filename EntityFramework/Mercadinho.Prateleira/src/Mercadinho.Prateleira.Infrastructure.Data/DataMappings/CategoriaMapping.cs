using Mercadinho.Prateleira.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mercadinho.Prateleira.Infrastructure.Data.DataMappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .UseIdentityColumn();
            builder.Property(p => p.Descricao)
                .HasColumnName("DESCRICAO")
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
