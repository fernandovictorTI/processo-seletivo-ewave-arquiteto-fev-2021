using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)                
                .IsRequired()
                .HasColumnName("IDCliente");

            builder
                .Property(c => c.DataCriacao)
                .IsRequired();

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
