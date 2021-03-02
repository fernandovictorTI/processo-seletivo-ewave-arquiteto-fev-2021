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
                .ReturnsAsync((new List<ClienteDto>() { new ClienteDto(Guid.NewGuid(), "Fernando", DateTime.Now) }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _clienteDapper = dapperMoq.Object;
            _clienteRepository = null;
        }

        [Fact]
        public void DeveRetornarErroAoConsultarClintesComParametrosIncorretos()
        {
            var handler = new ClienteQueryHandler(_clienteDapper, _mediator, _clienteRepository);
            Assert.Throws<ArgumentNullException>(() => new ObterClientesQuery(-1, 4));
        }

        [Theory]
        [MemberData(nameof(GuidsNullOrEmpty))]
        public void DeveRetornarErroAoConsultarClintePorIdComIdsIncorretos(Guid id)
        {
            var handler = new ClienteQueryHandler(_clienteDapper, _mediator, _clienteRepository);
            Assert.Throws<ArgumentNullException>(() => new ObterClienteQuery(id));
        }

        public static IEnumerable<object[]> GuidsNullOrEmpty =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { default(Guid) }
        };
    }
}
