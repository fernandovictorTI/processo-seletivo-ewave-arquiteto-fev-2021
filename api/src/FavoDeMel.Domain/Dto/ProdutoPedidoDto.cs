using System;

namespace FavoDeMel.Domain.Dto
{
    public class ProdutoPedidoDto : DtoBase
    {
        public Guid IDProdutoPedido { get; set; }
        public Guid IDProduto { get; set; }
        public int Quantidade { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }

        public ProdutoPedidoDto(Guid idProdutoPedido, Guid idProduto, int quantidade, string nome, decimal valor) =>
            (IDProdutoPedido, IDProduto, Quantidade, Nome, Valor) = (idProdutoPedido, idProduto, quantidade, nome, valor);
    }
}
