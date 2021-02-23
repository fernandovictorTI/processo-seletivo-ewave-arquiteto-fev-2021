using FavoDeMel.Domain.Core.Messaging;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.EventeHandler
{
    public class PedidoEventHandler :
        IRequestHandler<NovoPedidoEvent, bool>,
        IRequestHandler<SituacaoPedidoAlteradaEvent, bool>,
        IRequestHandler<AdicionadoProdutoPedidoEvent, bool>,
        IRequestHandler<RemovidoProdutoPedidoEvent, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPublisher _publisher;

        public PedidoEventHandler(
            IPedidoRepository pedidoRepository,
            IPublisher publisher)
        {
            _pedidoRepository = pedidoRepository;
            _publisher = publisher;
        }

        public async Task<bool> Handle(NovoPedidoEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = _pedidoRepository.GetEntityById(request.IDPedido);

                await _publisher.Publish(new NovoPedidoCriadoComSucessoEvent(pedido.Id));

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Handle(SituacaoPedidoAlteradaEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = _pedidoRepository.GetEntityById(request.IDPedido);

                await _publisher.Publish(new SituacaoPedidoAlteradaComSucessoEvent(pedido.Id, request.EnumSituacao));

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Handle(AdicionadoProdutoPedidoEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = _pedidoRepository.GetEntityById(request.IDPedido);

                await _publisher.Publish(new AdicionadoProdutoPedidoComSucessoEvent(pedido.Id));

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<bool> Handle(RemovidoProdutoPedidoEvent request, CancellationToken cancellationToken)
        {
            try
            {
                var pedido = _pedidoRepository.GetEntityById(request.IDPedido);

                await _publisher.Publish(new RemovidoProdutoPedidoComSucessoEvent(pedido.Id));

                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
    }
}
