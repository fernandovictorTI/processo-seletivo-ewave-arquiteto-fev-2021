using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FavoDeMel.Infra.EF.Mappings
{
    public class GarcomMapping : IEntityTypeConfiguration<Garcom>
    {
        public void Configure(EntityTypeBuilder<Garcom> builder)
        {
            builder.ToTable("Garcom");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)                
                .IsRequired()
                .HasColumnName("IDGarcom");

            builder
                .Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

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
