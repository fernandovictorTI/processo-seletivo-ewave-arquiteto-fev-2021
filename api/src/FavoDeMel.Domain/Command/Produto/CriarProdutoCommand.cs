using FavoDeMel.Domain.ValueObjects;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Produto
{
    public class CriarProdutoCommand : IRequest<Guid>
    {
        public CriarProdutoCommand() { }

        public CriarProdutoCommand(string nome, decimal valor)
        {
            Nome = new NomeVo(nome);
            Valor = valor;
        }

        public NomeVo Nome { get; set; }
        public decimal Valor { get; set; }
    }
}
