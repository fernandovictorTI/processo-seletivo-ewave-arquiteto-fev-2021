using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Produto;
using FavoDeMel.Domain.Querys.Produto.Consultas;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FavoDeMel.Domain.Test.Querys
{
    public class ProdutoQueryHandlerTest
    {
        private readonly IProdutoDapper _produtoDapper;
        private readonly IMediator _mediator;

        public ProdutoQueryHandlerTest()
        {
            var dapperMoq = new Mock<IProdutoDapper>();

            dapperMoq
                .Setup(x => x.ObterProdutos(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<ProdutoDto>() { new ProdutoDto() }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _produtoDapper = dapperMoq.Object;
        }

        [Fact]
        public async Task DeveRetornarErroAoConsultarProdutosComParametrosIncorretos()
        {
            var handler = new ProdutoQueryHandler(_produtoDapper, _mediator, null);
            var command = new ObterProdutosQuery(-1, 4);

            await handler.Handle(command, new CancellationToken());

            Assert.True(!command.IsValid);
        }

        [Theory]
        [InlineData(null)]
        public async Task DeveRetornarErroAoConsultarProdutoPorIdComIdsIncorretos(Guid id)
        {
            var handler = new ProdutoQueryHandler(_produtoDapper, _mediator, null);
            var command = new ObterProdutoQuery(id);

            await handler.Handle(command, new CancellationToken());

            Assert.True(!command.IsValid);
        }
    }
}
