using FavoDeMel.Domain.Dto;
using FavoDeMel.Domain.Entities;
using FavoDeMel.Domain.Repositories.Base;

namespace FavoDeMel.Domain.Repositories
{
    public interface IGarcomRepository : IRepository<Garcom, GarcomDto>
    {
        bool PossuiNomeCadastrado(Garcom garcom);
    }
}
