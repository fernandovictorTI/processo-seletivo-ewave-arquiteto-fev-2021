using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class PedidoMapping : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedido");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("IDPedido");

            builder
                .Property(c => c.IDGarcom)
                .IsRequired();

            builder
                .Property(c => c.IDComanda)
                .IsRequired();

            builder
                .Property(c => c.IDCliente)
                .IsRequired();

            builder
                .Property(c => c.DataPedido)
                .IsRequired();

            builder.Ignore(c => c.Notifications);

            builder
                .HasOne(c => c.Garcom)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(c => c.IDGarcom);

            builder
                .HasOne(c => c.Comanda)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(c => c.IDComanda);

            builder
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(c => c.IDCliente);
        }
    }
}
