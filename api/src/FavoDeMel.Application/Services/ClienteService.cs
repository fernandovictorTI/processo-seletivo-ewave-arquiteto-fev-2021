using AutoMapper;
using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Command.Cliente;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Cliente.Consultas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ClienteService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Criar(ClienteViewModel viewModel)
        {
            var registerCommand = _mapper.Map<CriarClienteCommand>(viewModel);
            return (await _mediator.Send(registerCommand));
        }

        public async Task<ClienteDto> Obter(Guid id)
        {
            var command = new ObterClienteQuery(id);
            return (await _mediator.Send(command));
        }

        public async Task<IEnumerable<ClienteDto>> ObterListaPaginados(ClienteQueryModel queryModel)
        {
            var command = _mapper.Map<ObterClientesQuery>(queryModel);
            return (await _mediator.Send(command));
        }
    }
}
