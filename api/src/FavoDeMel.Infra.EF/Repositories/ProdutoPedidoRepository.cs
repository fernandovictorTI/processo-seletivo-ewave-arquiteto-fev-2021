using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Data.Repositories.Base;
using PacoEvento.Infra.Data.Context;

namespace FavoDeMel.Infra.EF.Repositories
{
    public class ProdutoPedidoRepository : Repository<ProdutoPedido, ProdutoPedidoDto>, IProdutoPedidoRepository
    {
        public ProdutoPedidoRepository(FavoDeMelContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
