using FavoDeMel.Domain.ValueObjects;
using FavoDeMel.Domain.Core.Entities;
using Flunt.Validations;
using System.Collections.Generic;

namespace FavoDeMel.Domain.Entities
{
    public class Produto : Entity
    {
        public Produto() { }

        public Produto(NomeVo nome, decimal valor)
        {
            Nome = nome;
            Valor = valor;

            AddNotifications(
                new Contract()
                    .Requires()
                    .IsGreaterThan(valor, 0, "Produto.Valor", "O valor do produto deve ser maior que 0."),
                nome
                );
        }

        public virtual NomeVo Nome { get; private set; }
        public decimal Valor { get; private set; }

        public virtual ICollection<ProdutoPedido> ProdutosPedido { get; private set; }
    }
}
