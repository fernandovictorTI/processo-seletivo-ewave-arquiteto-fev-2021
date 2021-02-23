using AutoMapper;
using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Command.Pedido;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Event.Pedido;
using FavoDeMel.Domain.Querys.Pedido.Consultas;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PedidoService(IMapper mapper,
                              IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<Guid> Criar(PedidoViewModel viewModel)
        {
            var registerCommand = _mapper.Map<CriarPedidoCommand>(viewModel);
            return (await _mediator.Send(registerCommand));
        }

        public async Task<PedidoDto> Obter(Guid id)
        {
            var command = new ObterPedidoQuery(id);
            return (await _mediator.Send(command));
        }

        public async Task<IEnumerable<PedidoDto>> ObterListaPaginados(PedidoQueryModel queryModel)
        {
            var command = _mapper.Map<ObterPedidosQuery>(queryModel);
            return (await _mediator.Send(command));
        }

        public async Task<Guid> AlterarSituacao(AlterarSituacaoPedidoViewModel alterarSituacaoPedidoViewModel)
        {
            var enumSituacao = Enum.Parse<EnumSituacaoPedido>(alterarSituacaoPedidoViewModel.Situacao.ToString());

            var command = new AlterarSituacaoPedidoCommand(alterarSituacaoPedidoViewModel.IDPedido, enumSituacao);
            return (await _mediator.Send(command));
        }

        public async Task<bool> RemoverProdutoPedido(Guid idProdutoPedido)
        {
            var command = new RemoverProdutoPedidoCommand(idProdutoPedido);
            return (await _mediator.Send(command));
        }

        public async Task<Guid> AdicionarProdutoPedido(Guid id, ProdutoPedidoViewModel viewModel)
        {
            var command = new AdicionarProdutoPedidoCommand(id, viewModel.IDProduto, viewModel.Quantidade);
            return (await _mediator.Send(command));
        }

        public async Task<bool> NotificarPedidoCriado(Guid idPedido)
        {
            var command = new NovoPedidoEvent(idPedido);
            return (await _mediator.Send(command));
        }

        public async Task<bool> NotificarSituacaoPedidoAlterada(Guid idPedido, EnumSituacaoPedido situacaoPedido)
        {
            var command = new SituacaoPedidoAlteradaEvent(idPedido, situacaoPedido);
            return (await _mediator.Send(command));
        }

        public async Task<bool> NotificarAdicionadoProdutoPedido(Guid idPedido)
        {
            var command = new AdicionadoProdutoPedidoEvent(idPedido);
            return (await _mediator.Send(command));
        }

        public async Task<bool> NotificarRemovidoProdutoPedido(Guid idPedido)
        {
            var command = new RemovidoProdutoPedidoEvent(idPedido);
            return (await _mediator.Send(command));
        }
    }
}
