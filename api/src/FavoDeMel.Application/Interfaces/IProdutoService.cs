using FavoDeMel.Application.QueryModels;
using FavoDeMel.Application.ViewModels;
using FavoDeMel.Domain.Dto;

namespace FavoDeMel.Application.Interfaces
{
    public interface IProdutoService : IServiceBase<ProdutoViewModel, ProdutoQueryModel, ProdutoDto>
    {
    }
}
