using FavoDeMel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace PacoEvento.Infra.Data.Context
{
    public class FavoDeMelContext : DbContext
    {
        public virtual DbSet<Garcom> Cliente { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<ProdutoPedido> ProdutoPedido { get; set; }
        public virtual DbSet<Garcom> Garcom { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<HistoricoPedido> HistoricoPedido { get; set; }

        public FavoDeMelContext(DbContextOptions<FavoDeMelContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var currentAssembly = typeof(FavoDeMelContext).Assembly;
            var efMappingTypes = currentAssembly.GetTypes().Where(t =>
                t.FullName.StartsWith("FavoDeMel.Infra.EF.Mapping") &&
                t.FullName.EndsWith("Mapping"));

            foreach (var map in efMappingTypes.Select(Activator.CreateInstance))
            {
                modelBuilder.ApplyConfiguration((dynamic)map);
            }
        }
    }
}
