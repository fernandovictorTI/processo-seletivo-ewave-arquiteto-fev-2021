using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Cliente;
using FavoDeMel.Domain.Querys.Cliente.Consultas;
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
    public class ClienteQueryHandlerTest
    {
        private readonly IClienteDapper _clienteDapper;
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;

        public ClienteQueryHandlerTest()
        {
            var dapperMoq = new Mock<IClienteDapper>();

            dapperMoq
                .Setup(x => x.ObterClientes(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<ClienteDto>() { new ClienteDto() }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _clienteDapper = dapperMoq.Object;
            _clienteRepository = null;
        }

        [Fact]
        public async Task DeveRetornarErroAoConsultarClintesComParametrosIncorretos()
        {
            var handler = new ClienteQueryHandler(_clienteDapper, _mediator, _clienteRepository);
            var command = new ObterClientesQuery(-1, 4);

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.Invalid);
        }

        [Theory]
        [MemberData(nameof(GuidsNullOrEmpty))]
        public async Task DeveRetornarErroAoConsultarClintePorIdComIdsIncorretos(Guid id)
        {
            var handler = new ClienteQueryHandler(_clienteDapper, _mediator, _clienteRepository);
            var command = new ObterClienteQuery(id);

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
