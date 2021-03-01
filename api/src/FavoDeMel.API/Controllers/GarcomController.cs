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
    [Route("garcons")]
    [ApiController]
    public class GarcomController : ApiController
    {
        private readonly IGarcomService _garcomService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="garcomService"></param>
        /// <param name="unitOfWork"></param>
        public GarcomController(
            INotificationHandler<DomainNotification> notifications,
            IGarcomService garcomService,
            IUnitOfWork unitOfWork
            ) : base(notifications, unitOfWork)
        {
            _garcomService = garcomService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cria um garcom
        /// </summary>
        /// <param name="garcomViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(GarcomViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody] GarcomViewModel garcomViewModel)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(garcomViewModel);
            }

            var idCriado = await _garcomService.Criar(garcomViewModel);

            if (IsValidOperation() is not true)
                return Response(idCriado);

            _unitOfWork.Commit();

            garcomViewModel.Id = idCriado;
            return CreatedAtRoute(routeName: "GarcomGetById", routeValues: new { id = idCriado }, garcomViewModel);
        }

        /// <summary>
        /// Obtem garcoms por paginacao
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<GarcomDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] GarcomQueryModel query)
        {
            if (ModelState.IsValid is not true)
            {
                return Response(query);
            }

            var garcoms = await _garcomService.ObterListaPaginados(query);

            if (garcoms.Any() is not true && IsValidOperation())
                return NoContent();

            return Response(garcoms);
        }

        /// <summary>
        /// Obtem Garcom por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GarcomGetById")]
        [ProducesResponseType(typeof(GarcomDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var garcom = await _garcomService.Obter(id);

            if (garcom is null && IsValidOperation())
                return NoContent();

            return Response(garcom);
        }
    }
}