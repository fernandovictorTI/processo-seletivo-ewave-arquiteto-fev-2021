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
    [Route("clientes")]
    [ApiController]
    public class ClienteController : ApiController
    {
        private readonly IClienteService _clienteService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="clienteService"></param>
        /// <param name="unitOfWork"></param>
        public ClienteController(
            INotificationHandler<DomainNotification> notifications,
            IClienteService clienteService,
            IUnitOfWork unitOfWork
            ) : base(notifications, unitOfWork)
        {
            _clienteService = clienteService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cria um cliente
        /// </summary>
        /// <param name="clienteViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(ClienteViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(clienteViewModel);
            }

            var idCriado = await _clienteService.Criar(clienteViewModel);

            if (IsValidOperation() is not true)
                return Response();

            _unitOfWork.Commit();

            clienteViewModel.Id = idCriado;
            return CreatedAtRoute(routeName: "ClienteGetById", routeValues: new { id = idCriado }, clienteViewModel);
        }

        /// <summary>
        /// Obtem clientes por paginacao
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<ClienteDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] ClienteQueryModel query)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(query);
            }

            var clientes = await _clienteService.ObterListaPaginados(query);

            if (clientes.Any() is not true && IsValidOperation())
                return NoContent();

            return Response(clientes);
        }

        /// <summary>
        /// Obtem cliente por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "ClienteGetById")]
        [ProducesResponseType(typeof(ClienteDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.Obter(id);

            if (cliente is null && IsValidOperation())
                return NoContent();

            return Response(cliente);
        }
    }
}