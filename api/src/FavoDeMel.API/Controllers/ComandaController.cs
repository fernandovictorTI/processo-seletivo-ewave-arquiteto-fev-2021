using FavoDeMel.Application.Interfaces;
using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Dto;
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
    [Route("comandas")]
    [ApiController]
    public class ComandaController : ApiController
    {
        private readonly IComandaService _comandaService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="comandaService"></param>
        /// <param name="unitOfWork"></param>
        public ComandaController(
            INotificationHandler<DomainNotification> notifications,
            IComandaService comandaService,
            IUnitOfWork unitOfWork
            ) : base(notifications, unitOfWork)
        {
            _comandaService = comandaService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cria um comanda
        /// </summary>
        /// <param name="comandaViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(ComandaViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ComandaViewModel comandaViewModel)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(comandaViewModel);
            }

            var idCriado = await _comandaService.Criar(comandaViewModel);

            if (IsValidOperation() is not true)
                return Response();

            _unitOfWork.Commit();

            comandaViewModel.Id = idCriado;
            return CreatedAtRoute(routeName: "ComandaGetById", routeValues: new { id = idCriado }, comandaViewModel);
        }

        /// <summary>
        /// Obtem comandas por paginacao
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<ComandaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Get([FromQuery] ComandaQueryModel query)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(query);
            }

            var comandas = await _comandaService.ObterListaPaginados(query);

            if (comandas.Any() is not true && IsValidOperation())
                return NoContent();

            return Response(comandas);
        }

        /// <summary>
        /// Obtem comandas abertas com seus pedidos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("abertas")]
        [ProducesResponseType(typeof(IEnumerable<PedidosComandaDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterPedidosComandasAbertas()
        {
            var comandas = await _comandaService.ObterPedidosComandasAbertas();

            if (comandas.Any() is not true && IsValidOperation())
                return NoContent();

            return Response(comandas);
        }

        /// <summary>
        /// Obtem comanda por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "ComandaGetById")]
        [ProducesResponseType(typeof(ComandaDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var comanda = await _comandaService.Obter(id);

            if (comanda is null && IsValidOperation())
                return NoContent();

            return Response(comanda);
        }
    }
}