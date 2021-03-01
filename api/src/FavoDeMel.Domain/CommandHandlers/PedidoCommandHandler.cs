using FavoDeMel.Domain.Command.Pedido;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Comanda.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.CommandHandlers
{
    public class PedidoCommandHandler :
        IRequestHandler<CriarPedidoCommand, Guid>,
        IRequestHandler<AlterarSituacaoPedidoCommand, Guid>,
        IRequestHandler<RemoverProdutoPedidoCommand, bool>,
        IRequestHandler<AdicionarProdutoPedidoCommand, Guid>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IGarcomRepository _garcomRepository;
        private readonly IComandaRepository _comandaRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IHistoricoPedidoRepository _historicoPedidoRepository;
        private readonly IProdutoPedidoRepository _produtoPedidoRepository;
        private readonly IMediator _mediator;

        public PedidoCommandHandler(
            IPedidoRepository pedidoRepository,
            IGarcomRepository garcomRepository,
            IComandaRepository comandaRepository,
            IHistoricoPedidoRepository historicoPedidoRepository,
            IProdutoPedidoRepository produtoPedidoRepository,
            IClienteRepository clienteRepository,
            IMediator mediator)
        {
            _pedidoRepository = pedidoRepository;
            _garcomRepository = garcomRepository;
            _comandaRepository = comandaRepository;
            _historicoPedidoRepository = historicoPedidoRepository;
            _produtoPedidoRepository = produtoPedidoRepository;
            _clienteRepository = clienteRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido();

            var garcom = _garcomRepository.GetEntityById(request.IDGarcom);

            if (garcom is null)
                request.AddNotification("Garcom", "Garcom não encontrado no banco de dados.");

            var cliente = _clienteRepository.GetEntityById(request.IDCliente);

            if (cliente is null)
                request.AddNotification("Cliente", "Cliente não encontrado no banco de dados.");

            var comanda = _comandaRepository.GetEntityById(request.IDComanda);

            if (comanda is null)
                request.AddNotification("Comanda", "Comanda não encontrado no banco de dados.");
            else
            {
                var ultimoHistoricoPedidoComanda = await _mediator.Send(new ObterUltimoHistoricoPedidoComandaQuery(comanda.Id));

                if (ultimoHistoricoPedidoComanda is not null)
                    if (SituacaoPedido.SituacoesPermiteAberturaComanda.Any(situacao => situacao == ultimoHistoricoPedidoComanda.Situacao) is not true)
                        request.AddNotification("Comanda", $"Comanda não pode ser aberta devido ao ultimo pedido estar com a situação({ultimoHistoricoPedidoComanda.Situacao}).");
            }

            pedido = new Pedido(garcom, comanda, cliente);

            request.Produtos.ToList().ForEach(produtoPedido => pedido.AdicionarProduto(produtoPedido));

            if (pedido.IsValid is not true || request.IsValid is not true)
            {
                pedido.AddNotifications(request.Notifications);

                await _mediator.Publish(new DomainNotification
                {
                    Erros = pedido.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            var historicoPedido = new HistoricoPedido(Enums.EnumSituacaoPedido.Aberto, pedido.Id);
            pedido.AdicionarHistorico(historicoPedido);

            _pedidoRepository.Add(pedido);

            return await Task.FromResult(pedido.Id);
        }

        public async Task<Guid> Handle(AlterarSituacaoPedidoCommand request, CancellationToken cancellationToken)
        {
            var historicoPedido = new HistoricoPedido();

            var pedido = _pedidoRepository.GetEntityById(request.IDPedido);

            if (pedido is null)
                request.AddNotification("Pedido", $"Pedido({request.IDPedido}) não encontrado no banco de dados.");
            else
                historicoPedido = new HistoricoPedido(request.Situacao, pedido.Id);

            if (historicoPedido.IsValid is not true || request.IsValid is not true)
            {
                historicoPedido.AddNotifications(request.Notifications);

                await _mediator.Publish(new DomainNotification
                {
                    Erros = historicoPedido.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            _historicoPedidoRepository.Add(historicoPedido);

            return await Task.FromResult(historicoPedido.Id);
        }

        public async Task<bool> Handle(RemoverProdutoPedidoCommand request, CancellationToken cancellationToken)
        {
            var produtoPedido = _produtoPedidoRepository.GetEntityById(request.IDProdutoPedido);

            if (produtoPedido == null)
                request.AddNotification("RemoverProdutoPedidoCommand", $"Produto ({request.IDProdutoPedido}) não encontrado no banco de dados.");
            else
            {
                var pedido = _pedidoRepository.GetEntityById(produtoPedido.IDPedido);

                if (pedido.Produtos.Count() == 1)
                    request.AddNotification("RemoverProdutoPedidoCommand", $"Não é permitido remover todos os produtos. Feche a comanda ou adicione outro produto para remover este.");
            }

            if (request.IsValid is not true)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(false);
            }

            _produtoPedidoRepository.Remove(produtoPedido.Id);

            return await Task.FromResult(true);
        }

        public async Task<Guid> Handle(AdicionarProdutoPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = _pedidoRepository.GetEntityById(request.IDPedido);

            if (pedido == null)
                request.AddNotification("AdicionarProdutoPedidoCommand", $"pedido ({request.IDPedido}) não encontrado no banco de dados.");

            var produtoPedido = new ProdutoPedido(request.IDProduto, request.Quantidade);
            produtoPedido.VincularAoPedido(request.IDPedido);

            if (produtoPedido.IsValid is not true || request.IsValid is not true)
            {
                produtoPedido.AddNotifications(request.Notifications);

                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            _produtoPedidoRepository.Add(produtoPedido);

            return await Task.FromResult(produtoPedido.Id);
        }
    }
}
