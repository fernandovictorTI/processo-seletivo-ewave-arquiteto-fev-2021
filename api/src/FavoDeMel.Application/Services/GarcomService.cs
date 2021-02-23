using AutoMapper;
using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Command.Garcom;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Garcom.Consultas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Services
{
    public class GarcomService : IGarcomService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GarcomService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Criar(GarcomViewModel viewModel)
        {
            var registerCommand = _mapper.Map<CriarGarcomCommand>(viewModel);
            return (await _mediator.Send(registerCommand));
        }

        public async Task<IEnumerable<GarcomDto>> ObterListaPaginados(GarcomQueryModel queryModel)
        {
            var command = _mapper.Map<ObterGarconsQuery>(queryModel);
            return (await _mediator.Send(command));
        }

        public async Task<GarcomDto> Obter(Guid id)
        {
            var command = new ObterGarcomQuery(id);
            return (await _mediator.Send(command));
        }
    }
}
