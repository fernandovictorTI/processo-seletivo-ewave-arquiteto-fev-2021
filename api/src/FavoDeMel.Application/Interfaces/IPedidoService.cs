using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Enums;
using System;
using System.Threading.Tasks;

namespace FavoDeMel.Application.Interfaces
{
    public interface IPedidoService : IServiceBase<PedidoViewModel, PedidoQueryModel, PedidoDto>
    {
        Task<Guid> AlterarSituacao(AlterarSituacaoPedidoViewModel alterarSituacaoPedidoViewModel);
        Task<bool> RemoverProdutoPedido(Guid idProdutoPedido);
        Task<Guid> AdicionarProdutoPedido(Guid id, ProdutoPedidoViewModel viewModel);
        Task<bool> NotificarPedidoCriado(Guid idPedido);
        Task<bool> NotificarSituacaoPedidoAlterada(Guid idPedido, EnumSituacaoPedido situacaoPedido);
        Task<bool> NotificarAdicionadoProdutoPedido(Guid idPedido);
        Task<bool> NotificarRemovidoProdutoPedido(Guid idPedido);
    }
}
