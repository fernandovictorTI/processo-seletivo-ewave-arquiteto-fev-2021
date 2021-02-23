using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class PedidoRepository : Repository<Pedido, PedidoDto>, IPedidoRepository
    {
        public PedidoRepository(
            FavoDeMelContext context,
            IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
