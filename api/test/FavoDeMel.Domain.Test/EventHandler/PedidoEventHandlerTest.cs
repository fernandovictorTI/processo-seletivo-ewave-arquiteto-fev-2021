using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FavoDeMel.Domain.Core.Messaging;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.EventeHandler;
using FavoDeMel.Domain.Repositories;
using Moq;
using Xunit;

namespace FavoDeMel.Domain.Test.EventHandler
{
    public class PedidoEventHandlerTest
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPublisherMessagin _publisher;

        public PedidoEventHandlerTest()
        {
            var _helperEntitiesTest = new HelperEntitiesTest();

            var repositoryPedidoMoq = new Mock<IPedidoRepository>();

            repositoryPedidoMoq
               .Setup(x => x.GetEntityById(It.IsAny<Guid>()))
               .Returns(_helperEntitiesTest.Pedido);

            var publisherMoq = new Mock<IPublisherMessagin>();

            publisherMoq
                .Setup(x => x.Publish(It.IsAny<NovoPedidoCriadoComSucessoEvent>()))
                .Returns(Task.CompletedTask);

            _publisher = publisherMoq.Object;
            _pedidoRepository = repositoryPedidoMoq.Object;
        }

        [Fact]

        public async Task DeveCriarNovoPedidoCorretamente()
        {
            var handler = new PedidoEventHandler(_pedidoRepository, _publisher);
            var command = new NovoPedidoEvent(Guid.NewGuid());

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(true, retorno);
        }

        [Fact]

        public async Task DeveAlterarSituacaoPedidoCorretamente()
        {
            var handler = new PedidoEventHandler(_pedidoRepository, _publisher);
            var command = new SituacaoPedidoAlteradaEvent(Guid.NewGuid(), Enums.EnumSituacaoPedido.Aberto);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(true, retorno);
        }

        [Fact]

        public async Task DeveAdicionarProdutoAoPedidoCorretamente()
        {
            var handler = new PedidoEventHandler(_pedidoRepository, _publisher);
            var command = new AdicionadoProdutoPedidoEvent(Guid.NewGuid());

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(true, retorno);
        }

        [Fact]

        public async Task DeveRemoverProdutoDoPedidoCorretamente()
        {
            var handler = new PedidoEventHandler(_pedidoRepository, _publisher);
            var command = new RemovidoProdutoPedidoEvent(Guid.NewGuid());

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(true, retorno);
        }
    }
}