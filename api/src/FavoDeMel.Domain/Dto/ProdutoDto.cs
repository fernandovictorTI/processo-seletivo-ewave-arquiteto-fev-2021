using System;

namespace FavoDeMel.Domain.Dto
{
    public class ProdutoDto : DtoBase
    {
        public Guid IDProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public ProdutoDto() { }

        public ProdutoDto(Guid idProduto, string nome, decimal valor) =>
            (IDProduto, Nome, Valor) = (idProduto, nome, valor);
    }
}
