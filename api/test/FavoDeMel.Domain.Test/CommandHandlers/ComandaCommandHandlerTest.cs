using FavoDeMel.Domain.Command.Comanda;
using FavoDeMel.Domain.CommandHandlers;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace FavoDeMel.Domain.Test.CommandHandlers
{
    public class ComandaCommandHandlerTest
    {

        private readonly IComandaRepository _comandaRepository;
        private readonly IMediator _mediator;
        private readonly HelperEntitiesTest _helperEntitiesTest;

        public ComandaCommandHandlerTest()
        {
            _helperEntitiesTest = new HelperEntitiesTest();

            var repositoryMoq = new Mock<IComandaRepository>();

            repositoryMoq
                .Setup(x => x.GetAll())
                .Returns((new List<Comanda>() { new Comanda(_helperEntitiesTest.ComandaVo) }).AsQueryable());

            repositoryMoq
                .Setup(x => x.PossuiNumeroComandaCadastrada(It.IsAny<Comanda>()))
                .Returns((Comanda c) => repositoryMoq.Object.GetAll().Where(c => c.NumeroComanda.Numero == c.NumeroComanda.Numero).Any());

            var mediatorMoq = new Mock<IMediator>();

            mediatorMoq
                .Setup(x => x.Publish(It.IsAny<object>(), It.IsAny<CancellationToken>()))
                .Returns(Task.CompletedTask);

            _mediator = mediatorMoq.Object;
            _comandaRepository = repositoryMoq.Object;
        }

        [Fact]
        public async Task DeveRetornarErroSeNumeroJaExisteNoBanco()
        {
            var handler = new ComandaCommandHandler(_comandaRepository, _mediator);
            var command = new CriarComandaCommand(_helperEntitiesTest.ComandaVo.Numero);

            var retorno = await handler.Handle(command, new CancellationToken());

            Assert.Equal(Guid.Empty, retorno);
        }
    }
}
