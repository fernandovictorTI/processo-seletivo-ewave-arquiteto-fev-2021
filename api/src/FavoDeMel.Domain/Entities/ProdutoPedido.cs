using FavoDeMel.Domain.Core.Entities;
using Flunt.Validations;
using System;

namespace FavoDeMel.Domain.Entities
{
    public class ProdutoPedido : Entity
    {
        public ProdutoPedido()
        {

        }

        public ProdutoPedido(
            Guid idProduto,
            int quantidade)
        {
            IDProduto = idProduto;
            Quantidade = quantidade;

            AddNotifications(
                new Contract<object>()
                    .Requires()
                    .IsGreaterThan(quantidade, 0, "ProdutoPedido.Quantidade", "A quantidade deve ser maior que 0")
                    .IsNotEmpty(idProduto, "ProdutoPedido.IDProduto", "Id do produto é obrigatório")
                );
        }

        public virtual Guid IDProduto { get; private set; }
        public virtual Produto Produto { get; private set; }
        public virtual Pedido Pedido { get; private set; }
        public virtual Guid IDPedido { get; private set; }
        public int Quantidade { get; private set; }

        public void VincularAoPedido(Guid idPedido)
        {
            this.IDPedido = idPedido;
        }

        public void AumentarQuantidade(int quantidade)
        {
            Quantidade += quantidade;
        }
    }
}
