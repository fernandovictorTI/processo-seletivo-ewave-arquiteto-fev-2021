using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;

namespace FavoDeMel.Domain.Querys.Produto.Consultas
{
    public class ObterProdutosQuery : PaginacaoQuery<ProdutoDto>
    {
        public ObterProdutosQuery(int pagina, int quantidade) : base(pagina, quantidade)
        {
        }
    }
}
