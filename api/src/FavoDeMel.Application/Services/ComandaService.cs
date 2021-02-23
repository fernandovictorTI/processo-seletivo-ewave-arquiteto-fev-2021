using AutoMapper;
using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Command.Comanda;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Comanda.Consultas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Services
{
    public class ComandaService : IComandaService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ComandaService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Criar(ComandaViewModel viewModel)
        {
            var registerCommand = new CriarComandaCommand(viewModel.Numero);
            return (await _mediator.Send(registerCommand));
        }

        public async Task<ComandaDto> Obter(Guid id)
        {
            var command = new ObterComandaQuery(id);
            return (await _mediator.Send(command));
        }

        public async Task<IEnumerable<ComandaDto>> ObterListaPaginados(ComandaQueryModel queryModel)
        {
            var command = _mapper.Map<ObterComandasQuery>(queryModel);
            return (await _mediator.Send(command));
        }

        public async Task<IEnumerable<PedidosComandaDto>> ObterPedidosComandasAbertas()
        {
            var command = new ObterPedidosComandasAbertasQuery();
            return (await _mediator.Send(command));
        }
    }
}
