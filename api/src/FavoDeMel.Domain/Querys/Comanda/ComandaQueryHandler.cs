using FavoDeMel.Domain.Dapper;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.Querys.Comanda.Consultas;
using FavoDeMel.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Querys.Comanda
{
    public class ComandaQueryHandler :
        IRequestHandler<ObterComandasQuery, IEnumerable<ComandaDto>>,
        IRequestHandler<ObterComandaQuery, ComandaDto>,
        IRequestHandler<ObterUltimoHistoricoPedidoComandaQuery, HistoricoPedidoDto>,
        IRequestHandler<ObterPedidosComandasAbertasQuery, IEnumerable<PedidosComandaDto>>
    {
        private readonly IComandaDapper _comandaDapper;
        private readonly IComandaRepository _comandaRepository;
        private readonly IMediator _mediator;

        public ComandaQueryHandler(
            IComandaDapper comandaDapper,
            IMediator mediator,
            IComandaRepository comandaRepository
            )
        {
            _comandaDapper = comandaDapper;
            _mediator = mediator;
            _comandaRepository = comandaRepository;
        }

        public async Task<IEnumerable<ComandaDto>> Handle(ObterComandasQuery request, CancellationToken cancellationToken)
        {
            if (request.Pagina < 0)
                request.AddNotification("ObterComandasQuery.Pagina", "Pagina deve ser maior que 0.");

            if (request.Quantidade < 5)
                request.AddNotification("ObterComandasQuery.Quantidade", "Quantidade deve ser maior ou igual que 5.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                return await Task.FromResult(new List<ComandaDto>());
            }

            return await _comandaDapper.ObterComandas(request.Quantidade, request.Pagina);
        }

        public async Task<ComandaDto> Handle(ObterComandaQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == null || request.Id == Guid.Empty)
                request.AddNotification("ObterComandaQuery.Id", "Id é obrigatório.");

            if (request.Invalid)
            {
                await _mediator.Publish(new DomainNotification
                {
                    Erros = request.Notifications
                }, cancellationToken);

                ComandaDto comandaNull = null;

                return await Task.FromResult(comandaNull);
            }

            return _comandaRepository.GetById(request.Id);
        }

        public async Task<HistoricoPedidoDto> Handle(ObterUltimoHistoricoPedidoComandaQuery request, CancellationToken cancellationToken)
        {
            if(request.IDComanda == null || request.IDComanda == Guid.Empty)
                request.AddNotification("ObterUltimoHistoricoPedidoComandaQuery.IDComanda", "Id da comanda é obrigatório.");

            return await _comandaDapper.ObterUltimoHistoricoPedidoComanda(request.IDComanda);
        }

        public async Task<IEnumerable<PedidosComandaDto>> Handle(ObterPedidosComandasAbertasQuery request, CancellationToken cancellationToken)
        {
            return await _comandaDapper.ObterPedidosComandasAbertas();
        }
    }
}