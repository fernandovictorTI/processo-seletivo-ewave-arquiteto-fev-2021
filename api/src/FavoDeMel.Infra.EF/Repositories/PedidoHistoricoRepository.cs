using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;
using System.Linq;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class PedidoHistoricoRepository : Repository<HistoricoPedido, HistoricoPedidoDto>, IHistoricoPedidoRepository
    {
        public PedidoHistoricoRepository(FavoDeMelContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
