using FavoDeMel.Domain.ValueObjects;
using MediatR;
using System;

namespace FavoDeMel.Domain.Command.Comanda
{
    public class CriarComandaCommand : IRequest<Guid>
    {
        public CriarComandaCommand(int numeroComanda)
        {
            NumeroComanda = new ComandaVo(numeroComanda);
        }

        public ComandaVo NumeroComanda { get; set; }
    }
}
