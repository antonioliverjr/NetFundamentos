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
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.ToTable("ESTOQUE")
                .OwnsOne(n => n.InfoCompra)
                .Property(p => p.PrecoUnidade)
                .HasColumnName("PRECO_UNITARIO")
                .HasPrecision(16, 4);
            builder.OwnsOne(n => n.InfoCompra)
                .Property(p => p.Quantidade)
                .HasColumnName("QUANTIDADE");
            builder.OwnsOne(n => n.InfoCompra)
                .Property(p => p.UnidadeMedida)
                .HasColumnName("UNIDADE_MEDIDA");
            builder.HasOne(n => n.Produto)
                .WithOne(n => n.Estoque)
                .HasForeignKey<Estoque>(k => k.ProdutoId);
        }
    }
}
