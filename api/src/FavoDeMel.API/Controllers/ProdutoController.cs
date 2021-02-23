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
    [Route("produtos")]
    [ApiController]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoService _produtoService;
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifications"></param>
        /// <param name="produtoService"></param>
        /// <param name="unitOfWork"></param>
        public ProdutoController(
            INotificationHandler<DomainNotification> notifications,
            IProdutoService produtoService,
            IUnitOfWork unitOfWork
            ) : base(notifications, unitOfWork)
        {
            _produtoService = produtoService;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Cria um produto
        /// </summary>
        /// <param name="produtoViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(typeof(ProdutoViewModel), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post([FromBody]ProdutoViewModel produtoViewModel)
        {
            if (!ModelState.IsValid)
            {
                return Response(produtoViewModel);
            }

            var idCriado = await _produtoService.Criar(produtoViewModel);

            if (!IsValidOperation())
                return Response(idCriado);

            _unitOfWork.Commit();

            produtoViewModel.Id = idCriado;
            return CreatedAtRoute(routeName: "ProdutoGetById", routeValues: new { id = idCriado }, produtoViewModel);
        }

        /// <summary>
        /// Obtem produtos por paginacao
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(IEnumerable<ProdutoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get([FromQuery] ProdutoQueryModel query)
        {
            if (!ModelState.IsValid)
            {
                return Response(query);
            }

            var produtos = await _produtoService.ObterListaPaginados(query);

            if (!produtos.Any() && IsValidOperation())
                return NoContent();

            return Response(produtos);
        }

        /// <summary>
        /// Obtem Produto por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "ProdutoGetById")]
        [ProducesResponseType(typeof(ProdutoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(List<DomainNotification>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var produto = await _produtoService.Obter(id);

            if (produto == null && IsValidOperation())
                return NoContent();

            return Response(produto);
        }
    }
}