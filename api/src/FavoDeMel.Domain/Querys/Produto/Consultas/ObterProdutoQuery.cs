using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Querys.Base;
using System;

namespace FavoDeMel.Domain.Querys.Produto.Consultas
{
    public class ObterProdutoQuery : ObterPorIdQuery<ProdutoDto>
    {
        public ObterProdutoQuery(Guid id) : base(id)
        {
        }
    }
}
