using FavoDeMel.Domain.Command.Pedido;
using FavoDeMel.Domain.CommandHandlers;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Repositories;
using MediatR;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FavoDeMel.Domain.Test.CommandHandlers
{
    public class PedidoCommandHandlerTest
    {
        private readonly IPedidoRepository _pedidoGetEntityNullRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IGarcomRepository _garcomRepository;
        private readonly IComandaRepository _comandaRepository;
        private readonly IHistoricoPedidoRepository _historicoPedidoRepository;
        private readonly IProdutoPedidoRepository _produtoPedidoRepository;
        private readonly IClienteRepository _clienteRepository;        
        private readonly IMediator _mediator;
        private readonly HelperEntitiesTest _helperEntitiesTest;

        public PedidoCommandHandlerTest()
        {
            _helperEntitiesTest = new HelperEntitiesTest();

            var repositoryPedidoGetEntityNullMoq = new Mock<IPedidoRepository>();
            var repositoryPedidoMoq = new Mock<IPedidoRepository>();
            var repositoryGarcomMoq = new Mock<IGarcomRepository>();
            var repositoryComandaMoq = new Mock<IComandaRepository>();
            var repositoryHistoricoPedidoMoq = new Mock<IHistoricoPedidoRepository>();
            var repositoryProdutoPedidoMoq = new Mock<IProdutoPedidoRepository>();
            var repositoryClientePedidoMoq = new Mock<IClienteRepository>();

            Garcom garcomNull = null;

            repositoryGarcomMoq
               .Setup(x => x.GetEntityById(It.IsAny<Guid>()))
               .Returns(garcomNull);

            Pedido pedidoNull = null;

            repositoryPedidoGetEntityNullMoq
               .Setup(x => x.GetEntityById(It.IsAny<Guid>()))
               .Returns(pedidoNull);

            repositoryPedidoMoq
               .Setup(x => x.GetEntityById(It.IsAny<Guid>()))
               .Returns(_helperEntitiesTest.Pedido);

            Comanda comandaNull = null;

            repositoryComandaMoq
               .Setup(x => x.GetEntityById(It.IsAny<Guid>()))
               .Returns(comandaNull);

            ProdutoPedido produtoPedidoNull = null;

            repositoryProdutoPedidoMoq
               .Setup(x => x.GetEntityById(It.IsAny<Guid>()))
               .Returns(produtoPedidoNull);

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);            

            _mediator = mediatorMoq.Object;
            _pedidoGetEntityNullRepository = repositoryPedidoGetEntityNullMoq.Object;
            _pedidoRepository = repositoryPedidoMoq.Object;
            _comandaRepository = repositoryComandaMoq.Object;
            _garcomRepository = repositoryGarcomMoq.Object;
            _historicoPedidoRepository = repositoryHistoricoPedidoMoq.Object;
            _produtoPedidoRepository = repositoryProdutoPedidoMoq.Object;
            _clienteRepository = repositoryClientePedidoMoq.Object;
        }

        [Fact]
        public async Task DeveRetornarErroSeGarcomComandaNaoExisteNoBanco()
        {
            var handler = new PedidoCommandHandler(
                _pedidoRepository, 
                _garcomRepository, 
                _comandaRepository, 
                _historicoPedidoRepository,
                _produtoPedidoRepository,
                _clienteRepository,
                _mediator);
            var command = new CriarPedidoCommand(Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), _helperEntitiesTest.ProdutosPedido);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }

        [Fact]
        public async Task DeveRetornarErroSePedidoNaoExistirAoAlterarSituacao()
        {
            var handler = new PedidoCommandHandler(
                _pedidoGetEntityNullRepository,
                _garcomRepository,
                _comandaRepository,
                _historicoPedidoRepository,
                _produtoPedidoRepository,
                _clienteRepository,
                _mediator);
            var command = new AlterarSituacaoPedidoCommand(Guid.NewGuid(), Enums.EnumSituacaoPedido.Aberto);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }

        [Fact]
        public async Task DeveRetornarErroSeInformarSituacaoInvalidaAoAlterarSituacao()
        {
            var handler = new PedidoCommandHandler(
                _pedidoRepository,
                _garcomRepository,
                _comandaRepository,
                _historicoPedidoRepository,
                _produtoPedidoRepository,
                _clienteRepository,
                _mediator);

            EnumSituacaoPedido enumSituacaoPedido = Enum.Parse<EnumSituacaoPedido>("9999");

            var command = new AlterarSituacaoPedidoCommand(Guid.NewGuid(), enumSituacaoPedido);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }

        [Fact]
        public async Task DeveRetornarErroSePedidoNaoExistirAoRemoverProdutoPedido()
        {
            var handler = new PedidoCommandHandler(
                _pedidoGetEntityNullRepository,
                _garcomRepository,
                _comandaRepository,
                _historicoPedidoRepository,
                _produtoPedidoRepository,
                _clienteRepository,
                _mediator);

            var command = new RemoverProdutoPedidoCommand(Guid.NewGuid());

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.False(retorno);
        }

        [Fact]
        public async Task DeveRetornarErroSePedidoNaoExistirAoAdicionarProdutoPedido()
        {
            var handler = new PedidoCommandHandler(
                _pedidoGetEntityNullRepository,
                _garcomRepository,
                _comandaRepository,
                _historicoPedidoRepository,
                _produtoPedidoRepository,
                _clienteRepository,
                _mediator);

            var command = new AdicionarProdutoPedidoCommand(Guid.NewGuid(), Guid.NewGuid(), 10);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }

        [Fact]
        public async Task DeveRetornarErroQuantidadeProdutoIncorretaAdicionarProdutoPedido()
        {
            var handler = new PedidoCommandHandler(
                _pedidoRepository,
                _garcomRepository,
                _comandaRepository,
                _historicoPedidoRepository,
                _produtoPedidoRepository,
                _clienteRepository,
                _mediator);

            var command = new AdicionarProdutoPedidoCommand(Guid.NewGuid(), Guid.NewGuid(), 0);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }
    }
}
