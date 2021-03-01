using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Enums;
using FavoDeMel.Domain.Notifications;
using FavoDeMel.Domain.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoDeMel.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("pedidos")]
    [ApiController]
    public class PedidoController : ApiController
    {
        private readonly IPedidoService _pedidoService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="pedidoService"></param>
        /// <param name="unitOfWork"></param>
        public PedidoController(
            INotificationHandler<DomainNotification> notifications,
            IPedidoService pedidoService,
            IUnitOfWork unitOfWork
            ) : base(notifications, unitOfWork)
        {
            _pedidoService = pedidoService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cria um pedido
        /// </summary>
        /// <param name="pedidoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(PedidoViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] PedidoViewModel pedidoViewModel)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(pedidoViewModel);
            }

            var idCriado = await _pedidoService.Criar(pedidoViewModel);

            if (IsValidOperation() is not true)
                return Response(idCriado);

            _unitOfWork.Commit();

            await _pedidoService.NotificarPedidoCriado(idCriado);

            pedidoViewModel.Id = idCriado;
            return CreatedAtRoute(routeName: "PedidoGetById", routeValues: new { id = idCriado }, pedidoViewModel);
        }

        /// <summary>
        /// Obtem pedidos por paginacao
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<PedidoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] PedidoQueryModel query)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(query);
            }

            var pedidos = await _pedidoService.ObterListaPaginados(query);

            if (pedidos.Any() is not true && IsValidOperation())
                return NoContent();

            return Response(pedidos);
        }

        /// <summary>
        /// Obtem pedido por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "PedidoGetById")]
        [ProducesResponseType(typeof(PedidoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var pedido = await _pedidoService.Obter(id);

            if (pedido is null && IsValidOperation())
                return NoContent();

            return Response(pedido);
        }

        /// <summary>
        /// Altera situação do pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPut("{id}/alterar-situacao")]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AlterarSituacao(Guid id, [FromBody] AlterarSituacaoPedidoViewModel viewModel)
        {
            var pedido = await _pedidoService.AlterarSituacao(viewModel);

            if (IsValidOperation() is not true)
                return Response(pedido);

            _unitOfWork.Commit();

            var enumSituacao = Enum.Parse<EnumSituacaoPedido>(viewModel.Situacao.ToString());
            await _pedidoService.NotificarSituacaoPedidoAlterada(viewModel.IDPedido, enumSituacao);

            return Response(pedido);
        }

        /// <summary>
        /// Remove produto do pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idProdutoPedido"></param>
        /// <returns></returns>
        [HttpDelete("{id}/produtos/{idProdutoPedido}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoverProdutoPedido(Guid id, Guid idProdutoPedido)
        {
            var removido = await _pedidoService.RemoverProdutoPedido(idProdutoPedido);

            if (IsValidOperation() is not true)
                return Response();

            _unitOfWork.Commit();

            await _pedidoService.NotificarRemovidoProdutoPedido(id);

            return Response(removido);
        }

        /// <summary>
        /// Adiciona produto ao pedido
        /// </summary>
        /// <param name="id"></param>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost("{id}/produtos")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionaProdutoPedido(Guid id, [FromBody] ProdutoPedidoViewModel viewModel)
        {
            var idProdutoPedido = await _pedidoService.AdicionarProdutoPedido(id, viewModel);

            if (IsValidOperation() is not true)
                return Response();

            _unitOfWork.Commit();

            await _pedidoService.NotificarAdicionadoProdutoPedido(id);

            return Response(idProdutoPedido);
        }
    }
}