using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Garcom;
using FavoDeMel.Domain.Querys.Garcom.Consultas;
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
    public class GarcomQueryHandlerTest
    {
        private readonly IGarcomDapper _garcomDapper;
        private readonly IGarcomRepository _garcomRepository;
        private readonly IMediator _mediator;

        public GarcomQueryHandlerTest()
        {
            var dapperMoq = new Mock<IGarcomDapper>();

            dapperMoq
                .Setup(x => x.ObterGarcons(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<GarcomDto>() { new GarcomDto(Guid.NewGuid(), "Fernando", "65 999999999") }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var repositoryMoq = new Mock<IGarcomRepository>();

            _mediator = mediatorMoq.Object;
            _garcomDapper = dapperMoq.Object;
            _garcomRepository = repositoryMoq.Object;
        }

        [Fact]
        public async Task DeveRetornarErroAoConsultarClintesComParametrosIncorretos()
        {
            var handler = new GarcomQueryHandler(_garcomDapper, _mediator, _garcomRepository);
            var command = new ObterGarconsQuery(-1, 4);

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.IsValid is not true);
        }

        [Fact]
        public async Task DeveRetornarErroAoConsultarGarcomPorIdComIdsIncorretos()
        {
            Guid id = default;

            var handler = new GarcomQueryHandler(_garcomDapper, _mediator, _garcomRepository);
            var command = new ObterGarcomQuery(id);

            await handler.Handle(command, new CancellationToken());

            Assert.True(command.IsValid is not true);
        }
    }
}
