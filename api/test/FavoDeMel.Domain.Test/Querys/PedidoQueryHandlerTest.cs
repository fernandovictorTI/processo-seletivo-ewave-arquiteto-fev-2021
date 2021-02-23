using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Pedido;
using FavoDeMel.Domain.Querys.Pedido.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
namespace FavoDeMel.Domain.Test.Querys
{
    public class PedidoQueryHandlerTest
    {
        private readonly IPedidoDapper _pedidoDapper;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMediator _mediator;

        public PedidoQueryHandlerTest()
        {
            var dapperMoq = new Mock<IPedidoDapper>();

            dapperMoq
                .Setup(x => x.ObterPedidos(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<PedidoDto>() { new PedidoDto() }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _pedidoDapper = dapperMoq.Object;
            _pedidoRepository = null;
        }

        [Fact]
        public async Task DeveRetornarErroAoConsultarClintesComParametrosIncorretos()
        {
            var handler = new PedidoQueryHandler(_pedidoDapper, _mediator, _pedidoRepository);
            var command = new ObterPedidosQuery(-1, 4);

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.Invalid);
        }

        [Theory]
        [MemberData(nameof(GuidsNullOrEmpty))]
        public async Task DeveRetornarErroAoConsultarClintePorIdComIdsIncorretos(Guid id)
        {
            var handler = new PedidoQueryHandler(_pedidoDapper, _mediator, _pedidoRepository);
            var command = new ObterPedidoQuery(id);

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.Invalid);
        }

        public static IEnumerable<object[]> GuidsNullOrEmpty =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { default(Guid) }
        };
    }
}
