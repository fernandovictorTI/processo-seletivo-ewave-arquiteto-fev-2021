using FavoDeMel.Domain.Core.Entities;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FavoDeMel.Domain.Entities
{
    public class Pedido : Entity
    {
        public Pedido()
        {
            Produtos = new List<ProdutoPedido>();
            HistoricoPedido = new List<HistoricoPedido>();
        }

        public Pedido(Garcom garcom, Comanda comanda, Cliente cliente)
        {
            DataPedido = DateTime.Now;
            Garcom = garcom;
            Comanda = comanda;
            Cliente = cliente;
            Produtos = new List<ProdutoPedido>();
            HistoricoPedido = new List<HistoricoPedido>();

            AddNotifications(
                new Contract<object>()
                .IsNotNull(garcom, "Pedido.Garcom", "Garcom é obrigatorio")
                .IsNotNull(comanda, "Pedido.Comanda", "Comanda é obrigatorio")
                .Join(garcom == null ? new Garcom() : garcom)
                .Join(comanda == null ? new Comanda() : comanda)
                .Join(cliente == null ? new Cliente() : cliente));
        }

        public DateTime DataPedido { get; private set; }
        public virtual Garcom Garcom { get; private set; }
        public Guid IDGarcom { get; private set; }
        public virtual Comanda Comanda { get; private set; }
        public Guid IDComanda { get; private set; }
        public virtual Cliente Cliente { get; private set; }
        public Guid IDCliente { get; private set; }

        public virtual ICollection<ProdutoPedido> Produtos { get; private set; }
        public virtual ICollection<HistoricoPedido> HistoricoPedido { get; private set; }

        public void AdicionarProduto(ProdutoPedido produto)
        {
            var produtoJaAdicionado = Produtos.Any(prod => prod.Id == produto.Id);

            AddNotifications(
                new Contract<bool>()
                    .Requires()
                    .IsFalse(produtoJaAdicionado, "Produto", "Produto ja adicionado, só aumente a quantidade.")
                );

            if (IsValid)
            {
                produto.VincularAoPedido(Id);
                Produtos.Add(produto);
            }
        }

        public void AumentarQuantidadeProduto(ProdutoPedido produto, int quantidade)
        {
            AddNotifications(
                new Contract<int>()
                    .Requires()
                    .IsGreaterThan(quantidade, 0, "Produto.Quantidade", "A quantidade deve ser maior que 0.")
                );

            if (IsValid)
                this.Produtos.FirstOrDefault(prod => prod.Id == produto.Id).AumentarQuantidade(quantidade);
        }

        public void AdicionarHistorico(HistoricoPedido historico)
        {
            HistoricoPedido.Add(historico);
        }
    }
}
