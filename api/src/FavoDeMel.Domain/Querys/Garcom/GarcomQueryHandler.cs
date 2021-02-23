using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Garcom.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Querys.Garcom
{
    public class GarcomQueryHandler :
        IRequestHandler<ObterGarconsQuery, IEnumerable<GarcomDto>>,
        IRequestHandler<ObterGarcomQuery, GarcomDto>
    {
        private readonly IGarcomDapper _clienteDapper;
        private readonly IMediator _mediator;
        private readonly IGarcomRepository _garcomRepository;

        public GarcomQueryHandler(
            IGarcomDapper clienteDapper,
            IMediator mediator,
            IGarcomRepository garcomRepository
            )
        {
            _clienteDapper = clienteDapper;
            _mediator = mediator;
            _garcomRepository = garcomRepository;
        }

        public async Task<IEnumerable<GarcomDto>> Handle(ObterGarconsQuery request, CancellationToken cancellationToken)
        {
            if (request.Pagina < 0)
                request.AddNotification("ObterGarconsQuery.Pagina", "Pagina deve ser maior que 0.");

            if (request.Quantidade < 5)
                request.AddNotification("ObterGarconsQuery.Quantidade", "Quantidade deve ser maior ou igual que 5.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(new List<GarcomDto>());
            }

            return await _clienteDapper.ObterGarcons(request.Quantidade, request.Pagina);
        }

        public async Task<GarcomDto> Handle(ObterGarcomQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.Id == Guid.Empty)
                request.AddNotification("ObterCarcomQuery.Id", "Id é obrigatório.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                GarcomDto clienteNull = null;

                return await Task.FromResult(clienteNull);
            }

            return _garcomRepository.GetById(request.Id);
        }
    }
}
