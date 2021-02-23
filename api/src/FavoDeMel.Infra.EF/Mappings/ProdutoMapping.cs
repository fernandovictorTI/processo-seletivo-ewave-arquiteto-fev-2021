using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)                
                .IsRequired()
                .HasColumnName("IDProduto");

            builder
                .Property(c => c.Valor)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            builder.Ignore(c => c.Notifications);

            builder.OwnsOne(m => m.Nome, a =>
            {
                a.Property(p => p.Nome)
                    .HasMaxLength(255)
                    .HasColumnName("Nome");

                a.Ignore(p => p.Notifications);
            });
        }
    }
}
