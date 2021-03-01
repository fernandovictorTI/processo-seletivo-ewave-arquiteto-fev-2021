using AutoMapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using System.Collections.Generic;

namespace FavoDeMel.Application.AutoMapper
{
    public class EntityToDtoMappingProfile : Profile
    {
        public EntityToDtoMappingProfile()
        {
            CreateMap<Produto, ProdutoDto>()
                .ConstructUsing(c =>
                new ProdutoDto(c.Id, c.Nome.ToString(), c.Valor));

            CreateMap<Cliente, ClienteDto>()
                .ConstructUsing(c =>
                new ClienteDto(c.Id, c.Nome.ToString(), c.DataCriacao));

            CreateMap<Garcom, GarcomDto>()
                .ConstructUsing(c =>
                new GarcomDto(c.Id, c.Nome.ToString(), c.Telefone));

            CreateMap<Pedido, PedidoDto>()
                .ConstructUsing((c, rContext) =>
                new PedidoDto(
                        c.Id,
                        c.IDGarcom,
                        c.Garcom.Nome.Nome,
                        c.IDCliente,
                        c.Cliente.Nome.Nome,
                        c.IDComanda,
                        c.DataPedido,
                        c.Comanda.NumeroComanda.Numero,
                        rContext.Mapper.Map<List<ProdutoPedidoDto>>(c.Produtos))
                );

            CreateMap<Comanda, ComandaDto>()
                .ConstructUsing(c =>
                new ComandaDto(c.Id, c.NumeroComanda.Numero));

            CreateMap<ProdutoPedido, ProdutoPedidoDto>()
                .ConstructUsing(c =>
                new ProdutoPedidoDto(c.Id, c.IDProduto, c.Quantidade, c.Produto.Nome.Nome, c.Produto.Valor));

            CreateMap<HistoricoPedido, HistoricoPedidoDto>()
                .ConstructUsing(c =>
                new HistoricoPedidoDto(c.Id, c.Situacao, c.Data));
        }
    }
}
