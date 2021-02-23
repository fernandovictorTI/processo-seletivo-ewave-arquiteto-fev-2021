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
                new ProdutoDto()
                {
                    IDProduto = c.Id,
                    Nome = c.Nome.ToString(),
                    Valor = c.Valor
                });

            CreateMap<Cliente, ClienteDto>()
                .ConstructUsing(c =>
                new ClienteDto()
                {
                    IDCliente = c.Id,
                    Nome = c.Nome.ToString(),
                    DataCriacao = c.DataCriacao
                });

            CreateMap<Garcom, GarcomDto>()
                .ConstructUsing(c =>
                new GarcomDto()
                {
                    IDGarcom = c.Id,
                    Nome = c.Nome.ToString(),
                    Telefone = c.Telefone
                });

            CreateMap<Pedido, PedidoDto>()
                .ConstructUsing((c, rContext) =>
                new PedidoDto()
                {
                    IDPedido = c.Id,
                    IDGarcom = c.IDGarcom,
                    NomeGarcom = c.Garcom.Nome.Nome,
                    IDComanda = c.IDComanda,
                    NumeroComanda = c.Comanda.NumeroComanda.Numero,
                    DataPedido = c.DataPedido,
                    IDCliente = c.IDCliente,
                    NomeCliente = c.Cliente.Nome.Nome,
                    Produtos = rContext.Mapper.Map<List<ProdutoPedidoDto>>(c.Produtos)
                });

            CreateMap<Comanda, ComandaDto>()
                .ConstructUsing(c =>
                new ComandaDto()
                {
                    IDComanda = c.Id,
                    Numero = c.NumeroComanda.Numero
                });

            CreateMap<ProdutoPedido, ProdutoPedidoDto>()
                .ConstructUsing(c =>
                new ProdutoPedidoDto()
                {
                    IDProdutoPedido = c.Id,
                    IDProduto = c.IDProduto,
                    Quantidade = c.Quantidade,
                    Nome = c.Produto.Nome.Nome,
                    Valor = c.Produto.Valor
                });

            CreateMap<HistoricoPedido, HistoricoPedidoDto>()
                .ConstructUsing(c =>
                new HistoricoPedidoDto()
                {
                    IDHistoricoPedido = c.Id,
                    Data = c.Data,
                    Situacao = c.Situacao
                });
        }
    }
}
