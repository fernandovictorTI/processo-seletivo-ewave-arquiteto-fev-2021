using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Querys.Produto;
using FavoDeMel.Domain.Querys.Produto.Consultas;
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
    public class ProdutoQueryHandlerTest
    {
        private readonly IProdutoDapper _produtoDapper;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediator _mediator;

        public ProdutoQueryHandlerTest()
        {
            var _helperEntitiesTest = new HelperEntitiesTest();
            var dapperMoq = new Mock<IProdutoDapper>();

            dapperMoq
                .Setup(x => x.ObterProdutos(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync((new List<ProdutoDto>() { new ProdutoDto(Guid.NewGuid(), "Coca-cola", 10M) }));

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            var repositoryMoq = new Mock<IProdutoRepository>();

            repositoryMoq
                .Setup(x => x.GetById(It.IsAny<Guid>()))
                .Returns(new ProdutoDto(Guid.NewGuid(), "Fernando", 10.25m));

            _mediator = mediatorMoq.Object;
            _produtoDapper = dapperMoq.Object;
            _produtoRepository = repositoryMoq.Object;
        }

        [Fact]
        public void DeveRetornarErroAoConsultarProdutosComParametrosIncorretos()
        {
            var handler = new ProdutoQueryHandler(_produtoDapper, _mediator, null);

            Assert.Throws<ArgumentNullException>(() => new ObterProdutosQuery(-1, 4));
        }

        [Fact]
        public async Task DeveRetornarProdutoPorId()
        {
            var handler = new ProdutoQueryHandler(_produtoDapper, _mediator, _produtoRepository);
            var command = new ObterProdutoQuery(Guid.NewGuid());

            await handler.Handle(command, new CancellationToken());
            Assert.True(command.IsValid);
        }

        [Fact]
        public async Task DeveRetornarProdutosPorParametros()
        {
            var handler = new ProdutoQueryHandler(_produtoDapper, _mediator, _produtoRepository);
            var command = new ObterProdutosQuery(1, 10);

            await handler.Handle(command, new CancellationToken());
            Assert.True(command.IsValid);
        }


        [Fact]
        public void DeveRetornarErroAoConsultarProdutoPorIdComIdsIncorretos()
        {
            Guid id = default;

            var handler = new ProdutoQueryHandler(_produtoDapper, _mediator, null);
            Assert.Throws<ArgumentNullException>(() => new ObterProdutoQuery(id));
        }
    }
}
