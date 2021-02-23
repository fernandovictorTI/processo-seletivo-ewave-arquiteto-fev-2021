using FavoDeMel.Domain.ValueObjects;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Garcom
{
    public class CriarGarcomCommand : IRequest<Guid> 
    {
        public CriarGarcomCommand(string nome, string telefone)
        {
            Nome = new NomeVo(nome);
            Telefone = telefone;
        }

        public NomeVo Nome { get; set; }
        public string Telefone { get; set; }
    }
}
