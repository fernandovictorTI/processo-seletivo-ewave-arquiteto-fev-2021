using System;

namespace FavoDeMel.Domain.Dto
{
    public class ProdutoDto : DtoBase
    {
        public Guid IDProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
