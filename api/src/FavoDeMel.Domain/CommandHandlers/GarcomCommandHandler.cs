using FavoDeMel.Domain.Command.Garcom;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.CommandHandlers
{

    public class GarcomCommandHandler
        : IRequestHandler<CriarGarcomCommand, Guid>
    {
        private readonly IGarcomRepository _garcomRepository;
        private readonly IMediator _mediator;

        public GarcomCommandHandler(
            IGarcomRepository garcomRepository,
            IMediator mediator)
        {
            _garcomRepository = garcomRepository;
            _mediator = mediator;
        }

        public async Task<Guid> Handle(CriarGarcomCommand request, CancellationToken cancellationToken)
        {
            var garcom = new Garcom(request.Nome, request.Telefone);

            if (_garcomRepository.PossuiNomeCadastrado(garcom))
                garcom.AddNotification("Garcom.Nome", "O nome do garcom ja esta cadastrado no banco.");

            if (garcom.IsValid is not true)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = garcom.Notifications
                }, cancellationToken);

                return await Task.FromResult(Guid.Empty);
            }

            _garcomRepository.Add(garcom);

            return await Task.FromResult(garcom.Id);
        }
    }
}
