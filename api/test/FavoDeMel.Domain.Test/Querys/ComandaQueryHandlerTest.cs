using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Comanda;
using FavoDeMel.Domain.Querys.Comanda.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FavoDeMel.Domain.Test.Querys
{
    public class ComandaQueryHandlerTest
    {
        private readonly IComandaDapper _comandaDapper;
        private readonly IComandaRepository _comandaRepository;
        private readonly HelperEntitiesTest _helperEntitiesTest;
        private readonly IMediator _mediator;

        public ComandaQueryHandlerTest()
        {
            _helperEntitiesTest = new HelperEntitiesTest();
            var dapperMoq = new Mock<IComandaDapper>();

            dapperMoq
                .Setup(x => x.ObterComandas(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<ComandaDto>() { new ComandaDto(Guid.NewGuid(), 1) }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _comandaDapper = dapperMoq.Object;
            _comandaRepository = null;
        }

        [Fact]
        public void DeveRetornarErroAoConsultarComandasComParametrosIncorretos()
        {
            var handler = new ComandaQueryHandler(_comandaDapper, _mediator, _comandaRepository);
            Assert.Throws<ArgumentNullException>(() => new ObterComandasQuery(-1, 4));
        }

        [Theory]
        [MemberData(nameof(GuidsNullOrEmpty))]
        public void DeveRetornarErroAoConsultarComandaPorIdComIdsIncorretos(Guid id)
        {
            var handler = new ComandaQueryHandler(_comandaDapper, _mediator, _comandaRepository);
            Assert.Throws<ArgumentNullException>(() => new ObterComandaQuery(id));
        }

        [Theory]
        [MemberData(nameof(GuidsNullOrEmpty))]
        public void DeveRetornarErroAoConsultarUltimoHistoricoPedidoComandaComIdsIncorretos(Guid id)
        {
            var handler = new ComandaQueryHandler(_comandaDapper, _mediator, _comandaRepository);
            Assert.Throws<ArgumentNullException>(() => new ObterUltimoHistoricoPedidoComandaQuery(id));
        }
        public static IEnumerable<object[]> GuidsNullOrEmpty =>
        new List<object[]>
        {
            new object[] { Guid.Empty },
            new object[] { default(Guid) }
        };
    }
}
