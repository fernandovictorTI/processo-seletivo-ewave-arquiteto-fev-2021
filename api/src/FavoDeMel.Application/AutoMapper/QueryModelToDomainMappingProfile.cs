using AutoMapper;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Domain.Querys.Cliente.Consultas;
using FavoDeMel.Domain.Querys.Comanda.Consultas;
using FavoDeMel.Domain.Querys.Garcom.Consultas;
using FavoDeMel.Domain.Querys.Pedido.Consultas;
using FavoDeMel.Domain.Querys.Produto.Consultas;

namespace FavoDeMel.Application.AutoMapper
{
    public class QueryModelToDomainMappingProfile : Profile
    {
        public QueryModelToDomainMappingProfile()
        {
            CreateMap<ClienteQueryModel, ObterClientesQuery>()
                .ConstructUsing(c => new ObterClientesQuery(c.Pagina, c.Quantidade));

            CreateMap<ProdutoQueryModel, ObterProdutosQuery>()
                .ConstructUsing(c => new ObterProdutosQuery(c.Pagina, c.Quantidade));

            CreateMap<GarcomQueryModel, ObterGarconsQuery>()
                .ConstructUsing(c => new ObterGarconsQuery(c.Pagina, c.Quantidade));

            CreateMap<PedidoQueryModel, ObterPedidosQuery>()
                .ConstructUsing(c => new ObterPedidosQuery(c.Pagina, c.Quantidade));

            CreateMap<ComandaQueryModel, ObterComandasQuery>()
               .ConstructUsing(c => new ObterComandasQuery(c.Pagina, c.Quantidade));
        }
    }
}
