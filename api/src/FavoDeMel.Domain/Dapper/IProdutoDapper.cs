using FavoDeMel.Domain.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FavoDeMel.Domain.Dapper
{
    public interface IProdutoDapper
    {
        Task<IEnumerable<ProdutoDto>> ObterProdutos(int quantidade, int pagina);
    }
}
