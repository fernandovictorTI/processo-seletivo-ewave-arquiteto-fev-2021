using FavoDeMel.Domain.ValueObjects;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Cliente
{
    public class CriarClienteCommand : IRequest<Guid>
    {
        public CriarClienteCommand(string nome)
        {
            Nome = new NomeVo(nome);
        }

        public CriarClienteCommand()
        {
        }

        public NomeVo Nome { get; set; }
    }
}
