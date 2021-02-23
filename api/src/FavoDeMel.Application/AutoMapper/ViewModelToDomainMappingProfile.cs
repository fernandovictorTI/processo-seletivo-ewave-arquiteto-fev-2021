using AutoMapper;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Command.Cliente;
using FavoDeMel.Domain.Command.Comanda;
using FavoDeMel.Domain.Command.Garcom;
using FavoDeMel.Domain.Command.Pedido;
using FavoDeMel.Domain.Command.Produto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.ValueObjects;
using System.Collections.Generic;

namespace FavoDeMel.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<string, NomeVo>()
                .ConstructUsing(c => new NomeVo(c));

            CreateMap<NomeVo, string>()
                .ConstructUsing(c => c.Nome);

            CreateMap<int, ComandaVo>()
                .ConstructUsing(c => new ComandaVo(c));

            CreateMap<ComandaVo, int>()
                .ConstructUsing(c => c.Numero);

            CreateMap<ClienteViewModel, CriarClienteCommand>()
                .ConstructUsing(c => new CriarClienteCommand() { Nome = new NomeVo(c.Nome) });

            CreateMap<ProdutoViewModel, CriarProdutoCommand>()
                .ConstructUsing(c => new CriarProdutoCommand(c.Nome, c.Valor));

            CreateMap<GarcomViewModel, CriarGarcomCommand>()
                .ConstructUsing(c => new CriarGarcomCommand(c.Nome, c.Telefone));

            CreateMap<ProdutoPedidoViewModel, ProdutoPedido>()
                .ConstructUsing(c => new ProdutoPedido(c.IDProduto, c.Quantidade));

            CreateMap<PedidoViewModel, CriarPedidoCommand>()
                .ConstructUsing((c, rContext) =>
                {
                    return new CriarPedidoCommand(
                        c.IDGarcom,
                        c.IDComanda,
                        c.IDCliente,
                        rContext.Mapper.Map<List<ProdutoPedido>>(c.Produtos)
                        );
                }
                );

            CreateMap<ComandaViewModel, CriarComandaCommand>()
                .ConstructUsing(c => new CriarComandaCommand(c.Numero));
        }
    }
}
