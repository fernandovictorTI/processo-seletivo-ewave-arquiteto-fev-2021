using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.Services;
using FavoDeMel.Domain.Command.Cliente;
using FavoDeMel.Domain.Command.Comanda;
using FavoDeMel.Domain.Command.Garcom;
using FavoDeMel.Domain.Command.Pedido;
using FavoDeMel.Domain.Command.Produto;
using FavoDeMel.Domain.CommandHandlers;
using FavoDeMel.Domain.Core.Messaging;
using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.EventeHandler;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Cliente;
using FavoDeMel.Domain.Querys.Cliente.Consultas;
using FavoDeMel.Domain.Querys.Comanda;
using FavoDeMel.Domain.Querys.Comanda.Consultas;
using FavoDeMel.Domain.Querys.Garcom;
using FavoDeMel.Domain.Querys.Garcom.Consultas;
using FavoDeMel.Domain.Querys.Pedido;
using FavoDeMel.Domain.Querys.Pedido.Consultas;
using FavoDeMel.Domain.Querys.Produto;
using FavoDeMel.Domain.Querys.Produto.Consultas;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Domain.UoW;
using FavoDeMel.Infra.Dapper;
using FavoDeMel.Infra.Ef.UoW;
using FavoDeMel.Infra.EF.Repositories;
using FavoDeMel.Infra.RabbitMQ;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PacoEvento.Infra.Data.Context;
using System;
using System.Collections.Generic;

namespace FavoDeMel.Infra.CrossCutting.IOC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IGarcomService, GarcomService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IComandaService, ComandaService>();

            // Repositorys
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IGarcomRepository, GarcomRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IComandaRepository, ComandaRepository>();
            services.AddScoped<IHistoricoPedidoRepository, HistoricoPedidoRepository>();
            services.AddScoped<IProdutoPedidoRepository, ProdutoPedidoRepository>();

            // Dappers            
            services.AddScoped<IClienteDapper, ClienteDapper>();
            services.AddScoped<IProdutoDapper, ProdutoDapper>();
            services.AddScoped<IGarcomDapper, GarcomDapper>();
            services.AddScoped<IPedidoDapper, PedidoDapper>();
            services.AddScoped<IComandaDapper, ComandaDapper>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<CriarClienteCommand, Guid>, ClienteCommandHandler>();
            services.AddScoped<IRequestHandler<CriarProdutoCommand, Guid>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<CriarGarcomCommand, Guid>, GarcomCommandHandler>();
            services.AddScoped<IRequestHandler<CriarComandaCommand, Guid>, ComandaCommandHandler>();
            services.AddScoped<IRequestHandler<CriarPedidoCommand, Guid>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AlterarSituacaoPedidoCommand, Guid>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverProdutoPedidoCommand, bool>, PedidoCommandHandler>();
            services.AddScoped<IRequestHandler<AdicionarProdutoPedidoCommand, Guid>, PedidoCommandHandler>();
            
            // Domain - Events
            services.AddScoped<IRequestHandler<NovoPedidoEvent, bool>, PedidoEventHandler>();
            services.AddScoped<IRequestHandler<SituacaoPedidoAlteradaEvent, bool>, PedidoEventHandler>();
            services.AddScoped<IRequestHandler<AdicionadoProdutoPedidoEvent, bool>, PedidoEventHandler>();
            services.AddScoped<IRequestHandler<RemovidoProdutoPedidoEvent, bool>, PedidoEventHandler>();

            // Query - Commands
            services.AddScoped<IRequestHandler<ObterClientesQuery, IEnumerable<ClienteDto>>, ClienteQueryHandler>();
            services.AddScoped<IRequestHandler<ObterClienteQuery, ClienteDto>, ClienteQueryHandler>();
            services.AddScoped<IRequestHandler<ObterProdutosQuery, IEnumerable<ProdutoDto>>, ProdutoQueryHandler>();
            services.AddScoped<IRequestHandler<ObterProdutoQuery, ProdutoDto>, ProdutoQueryHandler>();
            services.AddScoped<IRequestHandler<ObterGarconsQuery, IEnumerable<GarcomDto>>, GarcomQueryHandler>();
            services.AddScoped<IRequestHandler<ObterGarcomQuery, GarcomDto>, GarcomQueryHandler>();
            services.AddScoped<IRequestHandler<ObterComandasQuery, IEnumerable<ComandaDto>>, ComandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterComandaQuery, ComandaDto>, ComandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterUltimoHistoricoPedidoComandaQuery, HistoricoPedidoDto>, ComandaQueryHandler>();
            services.AddScoped<IRequestHandler<ObterPedidosQuery, IEnumerable<PedidoDto>>, PedidoQueryHandler>();
            services.AddScoped<IRequestHandler<ObterPedidoQuery, PedidoDto>, PedidoQueryHandler>();
            services.AddScoped<IRequestHandler<ObterPedidosComandasAbertasQuery, IEnumerable<PedidosComandaDto>>, ComandaQueryHandler>();            

            // Infra - RabbitMQ
            services.AddScoped<IPublisherMessagin, Publisher>();

            // Infra - Data
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<FavoDeMelContext>();
        }
    }
}
