using FavoDeMel.Domain.Command;
using FavoDeMel.Domain.Command.Produto;
using FavoDeMel.Domain.CommandHandlers;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using FavoDeMel.Infra.EF.Repositories;
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
    public class ProdutoCommandHandlerTest
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediator _mediator;
        private readonly HelperEntitiesTest _helperEntitiesTest;

        public ProdutoCommandHandlerTest()
        {
            _helperEntitiesTest = new HelperEntitiesTest();

            var repositoryMoq = new Mock<IProdutoRepository>();

            repositoryMoq
                .Setup(x => x.GetAll())
                .Returns((new List<Produto>() { new Produto(_helperEntitiesTest.Nome, 10.25m) }).AsQueryable());

            repositoryMoq
                .Setup(x => x.PossuiProdutoCadastrado(It.IsAny<Produto>()))
                .Returns((Produto c) => repositoryMoq.Object.GetAll().Where(c => c.Nome.Nome == c.Nome.Nome).Any());

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _produtoRepository = repositoryMoq.Object;
        }

        [Fact]

        public async Task DeveRetornarErroSeProdutoJaExisteNoBanco()
        {
            var handler = new ProdutoCommandHandler(_produtoRepository, _mediator);
            var command = new CriarProdutoCommand(_helperEntitiesTest.Nome.Nome, 10.25m);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }
    }
}
