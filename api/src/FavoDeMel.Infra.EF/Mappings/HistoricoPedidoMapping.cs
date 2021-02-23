using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class HistoricoPedidoMapping : IEntityTypeConfiguration<HistoricoPedido>
    {
        public void Configure(EntityTypeBuilder<HistoricoPedido> builder)
        {
            builder.ToTable("HistoricoPedido");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("IDHistoricoPedido");

            builder
                .Property(c => c.Data)
                .IsRequired();

            builder
                .Property(c => c.Situacao)
                .IsRequired();

            builder
                .Property(c => c.IDPedido)
                .IsRequired();

            builder
                .HasOne(c => c.Pedido)
                .WithMany(c => c.HistoricoPedido)
                .HasForeignKey(c => c.IDPedido);

            builder.Ignore(c => c.Notifications);
        }
    }
}
