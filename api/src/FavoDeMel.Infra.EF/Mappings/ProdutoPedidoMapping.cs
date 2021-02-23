using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class ProdutoPedidoMapping : IEntityTypeConfiguration<ProdutoPedido>
    {
        public void Configure(EntityTypeBuilder<ProdutoPedido> builder)
        {
            builder.ToTable("ProdutoPedido");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)                
                .IsRequired()
                .HasColumnName("IDProdutoPedido");

            builder
                .Property(c => c.Quantidade)
                .IsRequired();

            builder
                .Property(c => c.IDProduto)
                .IsRequired();

            builder
                .Property(c => c.IDPedido)
                .IsRequired();

            builder
                .HasOne(c => c.Pedido)
                .WithMany(c => c.Produtos)
                .HasForeignKey(c => c.IDPedido);

            builder.Ignore(c => c.Notifications);

            builder
               .HasOne(c => c.Produto)
               .WithMany(c => c.ProdutosPedido)
               .HasForeignKey(c => c.IDProduto);
        }
    }
}
