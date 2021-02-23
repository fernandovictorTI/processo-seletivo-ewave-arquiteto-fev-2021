using AutoMapper;
using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Command;
using FavoDeMel.Domain.Command.Produto;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Querys.Produto.Consultas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProdutoService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Criar(ProdutoViewModel viewModel)
        {
            var registerCommand = _mapper.Map<CriarProdutoCommand>(viewModel);
            return (await _mediator.Send(registerCommand));
        }

        public async Task<ProdutoDto> Obter(Guid id)
        {
            var command = new ObterProdutoQuery(id);
            return (await _mediator.Send(command));
        }

        public async Task<IEnumerable<ProdutoDto>> ObterListaPaginados(ProdutoQueryModel queryModel)
        {
            var command = _mapper.Map<ObterProdutosQuery>(queryModel);
            return (await _mediator.Send(command));
        }
    }
}
