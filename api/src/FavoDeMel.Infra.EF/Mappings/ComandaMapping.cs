using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class ComandaMapping : IEntityTypeConfiguration<Comanda>
    {
        public void Configure(EntityTypeBuilder<Comanda> builder)
        {
            builder.ToTable("Comanda");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                .IsRequired()
                .HasColumnName("IDComanda");

            builder.Ignore(c => c.Notifications);

            builder.OwnsOne(m => m.NumeroComanda, a =>
            {
                a.Property(p => p.Numero)
                    .IsRequired()
                    .HasColumnName("Numero"); ;

                a.Ignore(p => p.Notifications);
            });
        }
    }
}
