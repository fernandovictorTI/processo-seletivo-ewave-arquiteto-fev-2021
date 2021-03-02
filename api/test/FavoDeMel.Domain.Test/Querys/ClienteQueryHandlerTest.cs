using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Querys.Cliente;
using FavoDeMel.Domain.Querys.Cliente.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            var helperEntitiesTest = new HelperEntitiesTest();

            dapperMoq
                .Setup(x => x.ObterClientes(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<ClienteDto>() { new ClienteDto(Guid.NewGuid(), "Fernando", DateTime.Now) }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var repositoryMoq = new Mock<IClienteRepository>();

            repositoryMoq
                .Setup(x => x.GetAll())
                .Returns((new List<Cliente>() { new Cliente(helperEntitiesTest.Nome) }).AsQueryable());

            repositoryMoq
                .Setup(x => x.PossuiNomeCadastrado(It.IsAny<Cliente>()))
                .Returns((Cliente c) => repositoryMoq.Object.GetAll().Where(c => c.Nome.Nome == c.Nome.Nome).Any());

            _mediator = mediatorMoq.Object;
            _clienteDapper = dapperMoq.Object;
            _clienteRepository = repositoryMoq.Object;
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



        [Fact]
        public async Task DeveRetornarConsultarClintesComParametros()
        {
            var handler = new ClienteQueryHandler(_clienteDapper, _mediator, _clienteRepository);
            var command = new ObterClientesQuery(1, 24);

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.IsValid);
        }

        [Fact]
        public async Task DeveConsultarClintePorId()
        {
            var handler = new ClienteQueryHandler(_clienteDapper, _mediator, _clienteRepository);
            var command = new ObterClienteQuery(Guid.NewGuid());

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.IsValid);
        }

        public static IEnumerable<object[]> GuidsNullOrEmpty =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { default(Guid) }
        };
    }
}
