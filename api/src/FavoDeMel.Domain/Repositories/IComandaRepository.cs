using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories.Base;

namespace FavoDeMel.Domain.Repositories
{
    public interface IComandaRepository : IRepository<Comanda, ComandaDto>
    {
        bool PossuiNumeroComandaCadastrada(Comanda comanda);
    }
}
