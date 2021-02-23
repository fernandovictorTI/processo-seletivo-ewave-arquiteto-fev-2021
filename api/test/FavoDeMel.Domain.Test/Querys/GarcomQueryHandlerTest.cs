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
                .ReturnsAsync((new List<GarcomDto>() { new GarcomDto() }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _garcomDapper = dapperMoq.Object;
        }

        [Fact]
        public async Task DeveRetornarErroAoConsultarClintesComParametrosIncorretos()
        {
            var handler = new GarcomQueryHandler(_garcomDapper, _mediator, _garcomRepository);
            var command = new ObterGarconsQuery(-1, 4);
            
            await handler.Handle(command, new CancellationToken());

            Assert.True(!command.IsValid);
        }

        [Theory]
        [InlineData(null)]
        public async Task DeveRetornarErroAoConsultarGarcomPorIdComIdsIncorretos(Guid id)
        {
            var handler = new GarcomQueryHandler(_garcomDapper, _mediator, _garcomRepository);
            var command = new ObterGarcomQuery(id);

            await handler.Handle(command, new CancellationToken());

            Assert.True(!command.IsValid);
        }
    }
}
