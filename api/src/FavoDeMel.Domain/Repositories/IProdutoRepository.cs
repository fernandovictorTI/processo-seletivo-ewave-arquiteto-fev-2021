using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories.Base;

namespace FavoDeMel.Domain.Repositories
{
    public interface IProdutoRepository : IRepository<Produto, ProdutoDto>
    {
        bool PossuiProdutoCadastrado(Produto cliente);
    }
}
