using FavoDeMel.Domain.Command.Garcom;
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
    public class GarcomCommandHandlerTest
    {
        private readonly IGarcomRepository _garcomRepository;
        private readonly IMediator _mediator;
        private readonly HelperEntitiesTest _helperEntitiesTest;

        public GarcomCommandHandlerTest()
        {
            _helperEntitiesTest = new HelperEntitiesTest();

            var repositoryMoq = new Mock<IGarcomRepository>();

            repositoryMoq
                .Setup(x => x.GetAll())
                .Returns((new List<Garcom>() { new Garcom(_helperEntitiesTest.Nome, "65 984143977") }).AsQueryable());

            repositoryMoq
                .Setup(x => x.PossuiNomeCadastrado(It.IsAny<Garcom>()))
                .Returns((Garcom c) => repositoryMoq.Object.GetAll().Where(c => c.Nome.Nome == c.Nome.Nome).Any());

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _garcomRepository = repositoryMoq.Object;
        }

        [Fact]

        public async Task DeveRetornarErroSeNomeJaExisteNoBanco()
        {
            var handler = new GarcomCommandHandler(_garcomRepository, _mediator);
            var command = new CriarGarcomCommand(_helperEntitiesTest.Nome.Nome, "65 984143977");

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }
    }
}
