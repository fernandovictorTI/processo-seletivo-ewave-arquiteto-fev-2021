using FavoDeMel.Domain.Command.Cliente;
using FavoDeMel.Domain.CommandHandlers;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FavoDeMel.Domain.Test.CommandHandlers
{
    public class ClienteCommandHandlerTest
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediator _mediator;
        private readonly HelperEntitiesTest _helperEntitiesTest;

        public ClienteCommandHandlerTest()
        {
            _helperEntitiesTest = new HelperEntitiesTest();

            var repositoryMoq = new Mock<IClienteRepository>();

            repositoryMoq
                .Setup(x => x.GetAll())
                .Returns((new List<Cliente>() { new Cliente(_helperEntitiesTest.Nome) }).AsQueryable());

            repositoryMoq
                .Setup(x => x.PossuiNomeCadastrado(It.IsAny<Cliente>()))
                .Returns((Cliente c) => repositoryMoq.Object.GetAll().Where(c=> c.Nome.Nome == c.Nome.Nome).Any());

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _clienteRepository = repositoryMoq.Object;
        }

        [Fact]

        public async Task DeveRetornarErroSeNomeJaExisteNoBanco()
        {
            var handler = new ClienteCommandHandler(_clienteRepository, _mediator);
            var command = new CriarClienteCommand(_helperEntitiesTest.Nome.Nome);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }
    }
}
